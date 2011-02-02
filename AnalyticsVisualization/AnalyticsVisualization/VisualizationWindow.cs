
using System;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace AnalyticsVisualization
{
	public partial class VisualizationWindow : MonoMac.AppKit.NSWindow
	{
		public VisualizationWindow(IntPtr handle)
			: base(handle)
		{
		}

		[Export("initWithCoder:")]
		public VisualizationWindow(NSCoder coder)
			: base(coder)
		{
		}
	}
}
