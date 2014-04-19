using System;
using System.Collections.Generic;
using System.IO;

namespace LB.Core {
	/// <summary>
	/// Manager classes are an abstraction on the data access layers
	/// </summary>
	public static class LbManager {

		static IList<Battle> battles;

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
			

		public static Game GetGame(int battleid, int scenarioid)
		{
			Battle battle = GetBattle(battleid);
			Scenario scenario = battle.GetScenario(scenarioid);
			Lb saved = LbRepositoryXML.GetLb();
			
			return new Game(battle, scenario, saved);
		}
		
		public static void SaveGame(Game game)
		{
			LbRepositoryXML.SaveLb(game.Saved);
		}
		
		public static IList<Battle> GetBattles() 
		{
			if (battles == null)
				battles = new List<Battle>(BattleRepositoryXML.GetBattles());
			return battles;
		}

		public static Battle GetBattle(int id)
		{
			foreach (Battle b in GetBattles()) {
				if (b.Id == id)
					return b;
			}
			return null;
		}			

	}
}