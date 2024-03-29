
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Google.GData.Analytics;

namespace DataLayer
{
	public class DataFeed
	{
		internal DataFeed (AnalyticsService service, string title, string profileId)
		{
			_service = service;
			_title = title;
			_profileId = profileId;
		}
		
		public string Title { get { return _title; } }
		public string ProfileId { get { return _profileId; } }
		
		public ReadOnlyCollection<Region> GetRegionInfo()
		{
			var dataQuery = new DataQuery(_profileId, DateTime.Today - TimeSpan.FromDays(30), DateTime.Today, "ga:visitors", "ga:region,ga:operatingSystem", "-ga:visitors");

			return _service.Query(dataQuery).Entries
				.Cast<DataEntry>()
				.Select(
					entry => new Region(entry.Dimensions[0].Value) 
					{
						MacUsers = entry.Dimensions[1].Value == "Macintosh" ? entry.Metrics[0].IntegerValue : 0,
						WindowsUsers = entry.Dimensions[1].Value == "Windows" ? entry.Metrics[0].IntegerValue : 0,
					})
				.Aggregate(new Dictionary<string, Region>(),
					(dict, region) =>
					{
						Region existing;
						if (!dict.TryGetValue(region.Name, out existing))
						{
							existing = new Region(region.Name);
							dict[region.Name] = existing;
						}
						existing.MacUsers += region.MacUsers;
						existing.WindowsUsers += region.WindowsUsers;
						return dict;
					},
					dict => dict.Values.ToList().AsReadOnly());
		}
		
		readonly AnalyticsService _service;
		readonly string _title;
		readonly string _profileId;
	}
}
