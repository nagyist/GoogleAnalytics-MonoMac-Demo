
using System;
using DataLayer;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace AnalyticsVisualization
{
	public partial class VisualizationWindowController : MonoMac.AppKit.NSWindowController
	{
		public VisualizationWindowController(DataFeed feed)
			: base("VisualizationWindow")
		{
			_feed = feed;
		}
		
		public VisualizationWindowController(IntPtr handle)
			: base(handle)
		{
		}

		[Export("initWithCoder:")]
		public VisualizationWindowController(NSCoder coder)
			: base(coder)
		{
		}

		
		public override void AwakeFromNib ()
		{
			if (_feed != null)
				_visualizationTable.DataSource = new VisualizationDataSource(_feed.GetRegionInfo());
		}

		public new VisualizationWindow Window
		{
			get { return (VisualizationWindow) base.Window; }
		}

		readonly DataFeed _feed;
	}
}
