﻿using System;
using System.Collections.Generic;

namespace LB.Core
{
	public class Battle
	{
		public Battle ()
		{
			Scenarios = new List<Scenario>();
		}

		public int Id {get;set;}
		public string Name {get;set;}
		public string Publisher {get;set;}
		public int Sort {get;set;}
		public IList<Scenario> Scenarios {get;set;}

		public Scenario GetScenario(int id)
		{
			foreach (Scenario s in this.Scenarios) 
			{
				if (s.Id == id)
					return s;
			}
			return null;
		}
	}
}

