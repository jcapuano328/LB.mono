using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;


namespace LB.Core {
	/// <summary>
	/// The repository is responsible for providing an abstraction to actual data storage mechanism
	/// whether it be SQLite, XML or some other method
	/// </summary>
	public class BattleRepositoryXML {
		static List<Battle> battles;

		static BattleRepositoryXML ()
		{
			battles = new List<Battle> ();			
		}

		static void ReadXml (Stream strm)
		{
			XmlDocument d = new XmlDocument ();
			d.Load (strm);
				
			XmlNodeList nodes = d.SelectNodes("//Battles/Battle");
			foreach (XmlNode node in nodes)
			{
				Battle b = new Battle { 
					Id = Convert.ToInt32(node.SelectSingleNode("Id").InnerText), 
	                Name = node.SelectSingleNode("Name").InnerText, 
	                Publisher = node.SelectSingleNode("Publisher").InnerText, 
	                Sort = Convert.ToInt32(node.SelectSingleNode("Sort").InnerText)
	            };
				
				XmlNodeList snodes = node.SelectNodes("Scenarios/Scenario");
				foreach (XmlNode snode in snodes)
				{
					b.Scenarios.Add(new Scenario {
						Id = Convert.ToInt32(snode.SelectSingleNode("Id").InnerText), 
						Name = snode.SelectSingleNode("Name").InnerText, 
						StartYear  = Convert.ToInt32(snode.SelectSingleNode("StartYear").InnerText), 			
						StartMonth = Convert.ToInt32(snode.SelectSingleNode("StartMonth").InnerText), 
						StartDay  = Convert.ToInt32(snode.SelectSingleNode("StartDay").InnerText), 
						StartHour = Convert.ToInt32(snode.SelectSingleNode("StartHour").InnerText), 
						StartMinute = Convert.ToInt32(snode.SelectSingleNode("StartMinute").InnerText), 
						EndYear  = Convert.ToInt32(snode.SelectSingleNode("EndYear").InnerText), 
						EndMonth = Convert.ToInt32(snode.SelectSingleNode("EndMonth").InnerText), 
						EndDay  = Convert.ToInt32(snode.SelectSingleNode("EndDay").InnerText), 
						EndHour  = Convert.ToInt32(snode.SelectSingleNode("EndHour").InnerText), 
						EndMinute  = Convert.ToInt32(snode.SelectSingleNode("EndMinute").InnerText)
					});
				}
				
				battles.Add(b);
			}
		}
		
		public static string DatabaseFilePath {
			get { 
				return "BattleDB.xml";
			}
		}
		
		public static void Initialize(Stream strm)
		{
			ReadXml (strm);
		}
		
		public static Battle GetBattle(int id)
		{
			for (var t = 0; t< battles.Count; t++) {
				if (battles[t].Id == id)
					return battles[t];
			}
			return new Battle() {Id=id};
		}
		
		public static IEnumerable<Battle> GetBattles ()
		{
			return battles;
		}
	}
}