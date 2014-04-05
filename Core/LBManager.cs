using System;
using System.Collections.Generic;
using System.IO;

namespace LB.Core {
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public static class LbManager {

		static LbManager ()
		{
		}
		
		public static string BattlesAssetsPath
		{
			get{return BattleRepositoryXML.DatabaseFilePath;}
		}
		
		public static void Initialize(Stream s)
		{
			BattleRepositoryXML.Initialize(s);
		}
		
		public static Lb GetLb()
		{
			return LbRepositoryXML.GetLb();
		}
		
		public static void SaveLb()
		{
			LbRepositoryXML.SaveLb();
		}
		
		public static IList<Battle> GetBattles() 
		{
			return new List<Battle>(BattleRepositoryXML.GetBattles());
		}
	}
}