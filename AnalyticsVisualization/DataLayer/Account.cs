
using System;
using System.Collections.Generic;
using System.Linq;
using Google.GData.Analytics;
using Google.GData.Client;

namespace DataLayer
{
	public class Account
	{
		public Account (string username, string password)
		{
			if (username == null)
				throw new ArgumentNullException("username");
			if (username.Length == 0)
				throw new ArgumentException("username must not be empty.", "username");
			if (password == null)
				throw new ArgumentNullException("password");
			if (password.Length == 0)
				throw new ArgumentException("password must not be empty.", "password");
				
			_service = new AnalyticsService("MonoMac Demo");
			_service.setUserCredentials(username, password);
		}

		public IEnumerable<string> GetEntryNames()
		{
			var feedQuery = new AccountQuery("http://www.google.com/analytics/feeds/accounts/default");
			return _service.Query(feedQuery).Entries.Select(entry => entry.Title.Text).ToList().AsReadOnly();
		}

		readonly AnalyticsService _service;
	}
}
