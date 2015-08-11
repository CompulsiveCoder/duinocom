﻿using System;
using duinocom;

namespace duinocom.duinocomInteractiveConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Starting duinocom interactive...");

			tryConnect ();
		}

		private static string getIdentifier()
		{
			Console.WriteLine ("Please enter the arduino identifier:");
			var identifier = Console.ReadLine ();

			return identifier;
		}

		private static string getPort(string identifier)
		{
			var detector = new DuinoPortDetector (identifier);

			var port = detector.Detect ();

			if (String.IsNullOrEmpty (port))
				port = portNotFound (identifier);

			return port;
		}

		private static void tryConnect()
		{
			var identifier = getIdentifier ();

			var port = getPort (identifier);

			connect (port);
		}

		private static void connect(string port)
		{
			Console.WriteLine ("duino found on port " + port);
			Console.WriteLine ("Ready...");

			bool isRunning = true;

			using (var communicator = new duinocom.DuinoCommunicator (port)) {
				while (isRunning) {
					var command = getCommand ();

					if (command == "X") {
						isRunning = false;
						break;
					}
					if (command == "cid") {
						changeIdentifier ();
					}

					var result = communicator.SendAndRead (command);

					Console.WriteLine (result);
				}
			}
		}

		private static string getCommand()
		{
			Console.Write("> ");
			var command = Console.ReadLine();
			return command;
		}

		private static string portNotFound(string identifier)
		{
			Console.WriteLine ("No duino was detected.");
			Console.WriteLine ("Please ensure it is plugged in.");
			Console.WriteLine ("Hit any key to retry...");
			Console.ReadLine ();

			return getPort (identifier);
		}

		private static void changeIdentifier()
		{
			//var identifier = getIdentifier ();
			tryConnect();
		}

	}
}
