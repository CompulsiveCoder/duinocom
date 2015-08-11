using System;
using duinocom;

namespace duinocomListConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Looking for connected duinos...");
			showList ();
		}

		private static void showList()
		{
			//var list = new DuinoPortLister().GetList();
			var dict = new DuinoPortLister().GetDictionary();

			if (dict.Count == 0) {
				Console.WriteLine ("No duinos detected. Ensure it is plugged in.");
				Console.WriteLine ("Hit a key to retry...");
				Console.ReadKey ();
				showList ();
			} else {
				Console.WriteLine ("Found: " + dict.Count);
				Console.WriteLine ();
				foreach (var key in dict.Keys) {
					Console.WriteLine (key + "  \"" + dict[key] + "\"");
				}
			}
		}
	}
}
