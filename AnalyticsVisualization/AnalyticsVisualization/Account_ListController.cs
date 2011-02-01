
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataLayer;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace AnalyticsVisualization
{
	public partial class Account_ListController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors

		// Called when created from unmanaged code
		public Account_ListController(IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public Account_ListController(NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		// Call to load from the XIB/NIB file
		public Account_ListController(ReadOnlyCollection<DataFeed> feeds) : base("Account_List")
		{
			_feeds = feeds;
			Initialize ();
		}

		#endregion

		//strongly typed window accessor
		public new Account_List Window {
			get { return (Account_List)base.Window; }
		}
		
		public override void AwakeFromNib ()
		{
			_accountList.DataSource = new AccountListDataSource(_feeds);
			_accountList.DoubleClick += Handle_accountListDoubleClick;
		}

		private void Handle_accountListDoubleClick (object sender, EventArgs e)
		{
			int selectedIndex = _accountList.SelectedRow;
			if (selectedIndex >= 0 && selectedIndex < _feeds.Count)
			{
				new VisualizationWindowController(_feeds[selectedIndex]).ShowWindow(this);
			}
		}
		
		// Shared initialization code
		private void Initialize()
		{
			
		}		

		readonly ReadOnlyCollection<DataFeed> _feeds;
	}
}

