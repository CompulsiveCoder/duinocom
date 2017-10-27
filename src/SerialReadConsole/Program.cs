using System;
using duinocom;
using System.Threading;

namespace SerialReadConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var detector = new DuinoPortDetector ();
			var port = detector.Guess ();

			using (var communicator = new DuinoCommunicator (port.PortName))//"/dev/ttyUSB0", 115200))
			{
				communicator.Open ();

				var isRunning = true;

				while (isRunning) {
					var output = communicator.Read ();

					if (!String.IsNullOrEmpty(output.Trim()))
						Console.WriteLine(output);
					
					Thread.Sleep (1);
				}

				communicator.Close ();
			}
		}
	}
}
