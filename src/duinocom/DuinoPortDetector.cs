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

		public SerialPort Detect()
		{
			try
			{
				string[] portNames = SerialPort.GetPortNames();

				for (int i = portNames.Length-1; i > 0; i--) // Iterate backwards because the port is often at the end.
				{
					var portName = portNames[i];

					var port = new SerialPort(portName, 9600);

					if (IsIdentified(port))
					{
						return port;
					}
				}
			}
			catch (Exception)
			{
			}

			return null;
		}

		public string DetectName()
		{
			var port = Detect ();
			if (port != null)
				return port.PortName;

			return String.Empty;
		}



		public bool IsIdentified(SerialPort port)
		{
			var broadcastIdentifier = new DuinoIdentifier ().Identify(port);

			if (broadcastIdentifier.Contains (Identifier)) {
				return true;
			} else {
				return false;
			}
		}

	
	}
}
