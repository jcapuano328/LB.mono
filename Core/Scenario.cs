using System;

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
	}
}

