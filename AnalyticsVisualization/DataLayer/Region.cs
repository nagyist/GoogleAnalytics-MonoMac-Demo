using System;
namespace DataLayer
{
	public class Region
	{
		public Region (string name)
		{
			_name = name;
		}

		public string Name { get { return _name; } }

		public int MacUsers { get; set; }
		public int WindowsUsers { get; set; }
		
		readonly string _name;
	}
}

