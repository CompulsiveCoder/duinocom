using System;
using System.Threading;
using System.IO.Ports;
using System.Text;
using System.Collections.Generic;

namespace duinocom
{
	public class DuinoPortDetector
	{
		public string Identifier = "";

		public DuinoPortDetector (string identifier)
		{
			Identifier = identifier;
		}

		public string Detect()
		{
			try
			{
				SerialPort port;
				string[] portNames = SerialPort.GetPortNames();

				for (int i = portNames.Length-1; i > 0; i--) // Iterate backwards because the port is often at the end.
				{
					var portName = portNames[i];
					if (IsIdentified(portName))
					{
						return portName;
					}
				}
			}
			catch (Exception)
			{
			}

			return String.Empty;
		}



		public bool IsIdentified(string portName)
		{
			var broadcastIdentifier = new DuinoIdentifier ().Identify(portName);

			if (broadcastIdentifier.Contains (Identifier)) {
				return true;
			} else {
				return false;
			}
		}

	
	}
}
