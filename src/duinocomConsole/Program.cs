using System;

namespace duinocom.duinocomConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Communicating with arduino compatible device...");

			var message = args [0];

			var detector = new duinocom.DuinoPortDetector ("duinocom");

			var port = detector.Detect ();

			using (var communicator = new duinocom.DuinoCommunicator (port)) {
				Console.WriteLine("");
				Console.WriteLine ("Duino found at port: " + port.PortName);
				Console.WriteLine("");
				Console.WriteLine ("Sending message: " + message);
				Console.WriteLine("");

				var result = communicator.SendAndRead (message);
				Console.WriteLine("Response received:");
				Console.WriteLine (result);
				Console.WriteLine("");
				Console.WriteLine("Finished successfully!!");
			}

		}
	}
}
