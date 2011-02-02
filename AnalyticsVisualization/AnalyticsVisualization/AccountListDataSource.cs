
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataLayer;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace AnalyticsVisualization
{
	internal sealed class AccountListDataSource : NSTableViewDataSource
	{
		public AccountListDataSource(IEnumerable<DataFeed> accountNames)
		{
			if (accountNames == null)
				throw new ArgumentNullException("accountNames");
			_accountNames = accountNames.ToList().AsReadOnly();
		}

		public override int GetRowCount(NSTableView tableView)
		{
			return _accountNames.Count;
		}
		
		public override NSObject GetObjectValue (NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			return new NSString(_accountNames[row].Title);
		}

		readonly ReadOnlyCollection<DataFeed> _accountNames;
	}
}
