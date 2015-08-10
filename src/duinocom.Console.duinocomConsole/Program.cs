using System;

namespace duinocom.duinocomConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Chatting to a duino...");

			var message = args [0];

			var detector = new Duinocom.DuinoPortDetector ("duinocom");

			var port = detector.Detect ();

			using (var communicator = new duinocom.DuinoCommunicator (port)) {
				Console.WriteLine("");
				Console.WriteLine ("Duino found at port: " + port);
				Console.WriteLine("");
				Console.WriteLine ("Sending message: " + message);
				Console.WriteLine("");

				var result = communicator.SendAndRead ("#");
				Console.WriteLine("Response received:");
				Console.WriteLine (result);
				Console.WriteLine("");
				Console.WriteLine("Finished successfully!!");
			}

			/*			using (var communicator = new duinocom.DuinoCommunicator (port)) {
				Console.WriteLine("");
				Console.WriteLine ("Asking the duino to identify itself by sending the command: #");
				Console.WriteLine("");

				var result = communicator.SendAndRead ("#");
				Console.WriteLine("Response received:");
				Console.WriteLine (result);
				Console.WriteLine("Demo successful!");
			}*/

		}
	}
}
