
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace AnalyticsVisualization
{
	internal sealed class AccountListDataSource : NSTableViewDataSource
	{
		public AccountListDataSource(IEnumerable<string> accountNames)
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
			return new NSString(_accountNames[row]);
		}

		ReadOnlyCollection<string> _accountNames;
	}
}
