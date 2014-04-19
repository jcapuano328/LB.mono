using System;

namespace LB.Core
{
	public class Lb
	{
		public Lb ()
		{
			Battle = 0;
			Scenario = 0;
			Turn = 1;
			Phase = 0;
		}

		public int Battle {get;set;}
		public int Scenario {get;set;}
		public int Turn {get;set;}
		public int Phase {get;set;}
		
		public void Reset(Battle b, Scenario s)
		{
			this.Battle = b.Id;
			this.Scenario = s.Id;
			this.Turn = 1;
			this.Phase = 0;
		}
	}
}

