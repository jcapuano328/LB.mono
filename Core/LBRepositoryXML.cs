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
	public class LbRepositoryXML {
		static string storeLocation;	
		static Lb lb;

		static LbRepositoryXML ()
		{
			// set the db location
			storeLocation = DatabaseFilePath;
			
			// deserialize XML from file at dbLocation
			ReadXml ();
		}

		static void ReadXml ()
		{
			if (File.Exists (storeLocation)) {
				var serializer = new XmlSerializer (typeof(List<Battle>));
				using (var stream = new FileStream (storeLocation, FileMode.Open)) {
					lb = (Lb)serializer.Deserialize (stream);
				}
			}
		}
		static void WriteXml ()
		{
			var serializer = new XmlSerializer (typeof(Lb));
			using (var writer = new StreamWriter (storeLocation)) {
				serializer.Serialize (writer, lb);
			}
		}
		
		public static string DatabaseFilePath {
			get { 
				var storeFilename = "LbDB.xml";
				#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
				var path = sqliteFilename;
				#else
				
				#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
				string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
				#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
				#endif
				var path = Path.Combine (libraryPath, storeFilename);
				#endif		
				return path;	
			}
		}
		
		public static Lb GetLb()
		{
			if (lb == null)
			{
				lb = new Lb();
			}
			return lb;
		}
		
		public static void SaveLb()
		{ 
			WriteXml ();
		}
	}
}