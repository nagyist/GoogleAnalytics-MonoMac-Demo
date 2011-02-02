
using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace AnalyticsVisualization
{
	public partial class VisualizationWindowController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors

		// Called when created from unmanaged code
		public VisualizationWindowController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public VisualizationWindowController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		// Call to load from the XIB/NIB file
		public VisualizationWindowController (DataFeed feed) : base("VisualizationWindow")
		{
			_feed = feed;
			Initialize ();
		}
		
		public override void AwakeFromNib ()
		{
			_visualizationTable.DataSource = new VisualizationDataSource(_feed.DoSomething());
		}
		
		// Shared initialization code
		private void Initialize ()
		{
		}

		#endregion

		//strongly typed window accessor
		public new VisualizationWindow Window {
			get { return (VisualizationWindow)base.Window; }
		}

		readonly DataFeed _feed;
	}
}

