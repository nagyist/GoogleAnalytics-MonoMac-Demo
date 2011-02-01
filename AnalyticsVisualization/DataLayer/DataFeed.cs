using System;
namespace DataLayer
{
	public class DataFeed
	{
		internal DataFeed (Account account, string title, string profileId)
		{
			_account = account;
			_title = title;
			_profileId = profileId;
		}
		
		public string Title { get { return _title; } }
		public string ProfileId { get { return _profileId; } }
		
		readonly Account _account;
		readonly string _title;
		readonly string _profileId;
	}
}

