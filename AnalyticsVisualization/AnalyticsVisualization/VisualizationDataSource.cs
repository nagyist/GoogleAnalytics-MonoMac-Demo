
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataLayer;
using MonoMac.AppKit;
using MonoMac.Foundation;

namespace AnalyticsVisualization
{
	internal sealed class VisualizationDataSource : NSTableViewDataSource
	{
		public VisualizationDataSource (IEnumerable<Region> regions)
		{
			_regions = regions.ToList().AsReadOnly();
		}
		
		public override int GetRowCount (NSTableView tableView)
		{
			return _regions.Count;
		}
		
		public override NSObject GetObjectValue (NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			if (tableColumn.HeaderCell.StringValue == "Region")
				return new NSString(_regions[row].Name);
			if (tableColumn.HeaderCell.StringValue == "Mac Users")
				return new NSNumber(_regions[row].MacUsers);
			return new NSNumber(_regions[row].WindowsUsers);
		}
		
		ReadOnlyCollection<Region> _regions;
	}
}

