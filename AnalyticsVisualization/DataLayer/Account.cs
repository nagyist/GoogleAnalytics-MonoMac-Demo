
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public ReadOnlyCollection<DataFeed> GetEntryNames()
		{
			var feedQuery = new AccountQuery("http://www.google.com/analytics/feeds/accounts/default");
			try
			{
				return _service.Query(feedQuery).Entries.Cast<AccountEntry>().Select(entry => new DataFeed(_service, entry.Title.Text, entry.ProfileId.Value)).ToList().AsReadOnly();
			}
			catch (GDataRequestException x)
			{
				throw new InvalidOperationException("Unable to log in.", x);
			}
		}

		readonly AnalyticsService _service;
	}
}
