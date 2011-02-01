
using System;
using System.Collections.Generic;
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
		public Account_ListController(string username, string password) : base("Account_List")
		{
			_account = new Account(username, password);
			Initialize ();
		}

		#endregion

		//strongly typed window accessor
		public new Account_List Window {
			get { return (Account_List)base.Window; }
		}

		// Shared initialization code
		private void Initialize ()
		{
		}

		readonly Account _account;
	}
}

