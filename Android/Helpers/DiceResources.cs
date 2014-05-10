using System;

namespace LB
{
	public static class DiceResources
	{
		public static int GetWhiteBlack(int die)
		{
			int res = Resource.Drawable.whiteb1;
			switch (die)
			{
				case 2:
					res = Resource.Drawable.whiteb2;
					break;
				case 3:
					res = Resource.Drawable.whiteb3;
					break;
				case 4:
					res = Resource.Drawable.whiteb4;
					break;
				case 5:
					res = Resource.Drawable.whiteb5;
					break;
				case 6:
					res = Resource.Drawable.whiteb6;
					break;
				case 1:					
				default:
					break;
			}
			return res;
		}
	
		public static int GetRedWhite(int die)
		{
			int res = Resource.Drawable.redw1;
			switch (die)
			{
				case 2:
					res = Resource.Drawable.redw2;
					break;
				case 3:
					res = Resource.Drawable.redw3;
					break;
				case 4:
					res = Resource.Drawable.redw4;
					break;
				case 5:
					res = Resource.Drawable.redw5;
					break;
				case 6:
					res = Resource.Drawable.redw6;
					break;
				case 1:					
				default:
					break;
			}
			return res;
		}
		
		public static int GetBlackWhite(int die)
		{
			int res = Resource.Drawable.blackw1;
			switch (die)
			{
				case 2:
					res = Resource.Drawable.blackw2;
					break;
				case 3:
					res = Resource.Drawable.blackw3;
					break;
				case 4:
					res = Resource.Drawable.blackw4;
					break;
				case 5:
					res = Resource.Drawable.blackw5;
					break;
				case 6:
					res = Resource.Drawable.blackw6;
					break;
				case 1:					
				default:
					break;
			}
			return res;
		}
		
		public static int GetBlackRed(int die)
		{
			int res = Resource.Drawable.blackr1;
			switch (die)
			{
				case 2:
					res = Resource.Drawable.blackr2;
					break;
				case 3:
					res = Resource.Drawable.blackr3;
					break;
				case 4:
					res = Resource.Drawable.blackr4;
					break;
				case 5:
					res = Resource.Drawable.blackr5;
					break;
				case 6:
					res = Resource.Drawable.blackr6;
					break;
				case 1:					
				default:
					break;
			}
			return res;
		}
	
		public static int GetBlue(int die)
		{
			int res = Resource.Drawable.blue1;
			switch (die)
			{
				case 2:
					res = Resource.Drawable.blue2;
					break;
				case 3:
					res = Resource.Drawable.blue3;
					break;
				case 4:
					res = Resource.Drawable.blue4;
					break;
				case 5:
					res = Resource.Drawable.blue5;
					break;
				case 6:
					res = Resource.Drawable.blue6;
					break;
				case 1:					
				default:
					break;
			}
			return res;
		}
	}
}

