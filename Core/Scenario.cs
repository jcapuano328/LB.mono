using System;
using System.Globalization;

namespace LB.Core
{
	public class Scenario
	{
		public Scenario ()
		{
		}
		
		public int Id {get;set;}
		public string Name {get;set;}
		public int StartYear {get;set;}
		public int StartMonth {get;set;}
		public int StartDay {get;set;}
		public int StartHour {get;set;}
		public int StartMinute {get;set;}
		public int EndYear {get;set;}
		public int EndMonth {get;set;}
		public int EndDay {get;set;}
		public int EndHour {get;set;}
		public int EndMinute {get;set;}

		public string DisplayDate
		{
			get 
			{
				DateTime start = new DateTime (this.StartYear, this.StartMonth, this.StartDay, this.StartHour, this.StartMinute, 0);
				//DateTime end = new DateTime (this.EndYear, this.EndMonth, this.EndDay, this.EndHour, this.EndMinute, 0);

				//return start.ToShortDateString ()
				return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.StartMonth) 
					+ start.ToString(" dd, yyyy", CultureInfo.CurrentCulture) 
					+ "    " + string.Format ("{0:00}:{1:00} - {2:00}:{3:00}", this.StartHour, this.StartMinute, this.EndHour, this.EndMinute);
			}
		}
	}
}

