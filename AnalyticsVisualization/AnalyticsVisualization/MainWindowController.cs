
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataLayer;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace AnalyticsVisualization
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		public MainWindowController()
			: base("MainWindow")
		{
		}

		public MainWindowController(IntPtr handle)
			: base(handle)
		{
		}

		[Export("initWithCoder:")]
		public MainWindowController(NSCoder coder) 
			: base(coder)
		{
		}

		public new MainWindow Window
		{
			get { return (MainWindow) base.Window; }
		}
		
		partial void login(NSObject sender)
		{
			ReadOnlyCollection<DataFeed> feeds;

			try
			{
				Account account = new Account(_userNameField.StringValue, _passwordField.StringValue);
				feeds = account.GetDataFeeds();
			}
			catch (InvalidOperationException)
			{
				NSAlert.WithMessage("Unable to log in", "OK", "", "", "").BeginSheet(this.Window);
				feeds = null;
			}
					
			if (feeds != null)
			{
				new Account_ListController(feeds).ShowWindow(sender);
				Close();
			}
		}
	}
}

