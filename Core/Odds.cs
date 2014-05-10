using System;
using System.Collections.Generic;

namespace LB.Core
{
	public class Odds
	{
		public Odds(double value, string name)
		{
			Value = value;
			Name = name;
		}
		
		public double Value {get;set;}
		public string Name {get;set;}
		
		public static Odds Calculate(IList<Odds> table, double att, double def, int shift) 
		{
			bool attadv = (att >= def);
			Odds entry = null;
			double odds = (attadv == true) ? (att / def) : (def / att);
			double o = odds * (attadv ? 1 : -1);
			int index = -1;
			for (int i=0; i<table.Count; i++) 
			{
	        	var tableentry = table[i];
	        	var value = tableentry.Value;
	            var nextvalue = (i+1 < table.Count) ? table[i+1].Value : value;
				
				if ((i+1 == table.Count && o >= value) || 
					(i == 0 && o < value) ||
					(o >= value && o < nextvalue)) 
				{
	                index = i;
					break;
				}
			}
	        
	        if (index > -1) 
			{
	        	index += shift;
	            if (index < 0) 
	            	index = 0;
	            else if (index >= table.Count) 
	            	index = table.Count - 1;
	        	entry = table[index];
	        }
	        
	        return entry;
		}                
	}
}

