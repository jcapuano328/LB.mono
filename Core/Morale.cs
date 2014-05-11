using System;

namespace LB.Core
{
	public class Morale
	{
		public Morale()
		{
		}
		
		public string Resolve(int morale, int dice)
		{
			string result = "NE";
			if (dice > morale)
				result = "Pass";
			else
				result = "Fail";
			return result;
		}
	}
}