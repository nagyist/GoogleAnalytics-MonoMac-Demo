
using System;
using System.Collections.ObjectModel;
using DataLayer;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace AnalyticsVisualization
{
	public partial class Account_ListController : MonoMac.AppKit.NSWindowController
	{
		public Account_ListController(ReadOnlyCollection<DataFeed> feeds) : base("Account_List")
		{
			_feeds = feeds;
		}

		public Account_ListController(IntPtr handle)
			: base(handle)
		{
		}

		[Export("initWithCoder:")]
		public Account_ListController(NSCoder coder)
			: base(coder)
		{
		}

		public new Account_List Window
		{
			get { return (Account_List) base.Window; }
		}
		
		public override void AwakeFromNib()
		{
			if (_feeds != null)
			{
				_accountList.DataSource = new AccountListDataSource(_feeds);
				_accountList.DoubleClick += Handle_accountListDoubleClick;
			}
		}

		private void Handle_accountListDoubleClick(object sender, EventArgs e)
		{
			int selectedIndex = _accountList.SelectedRow;
			if (selectedIndex >= 0 && selectedIndex < _feeds.Count)
			{
				new VisualizationWindowController(_feeds[selectedIndex]).ShowWindow(this);
			}
		}

		readonly ReadOnlyCollection<DataFeed> _feeds;
	}
}

