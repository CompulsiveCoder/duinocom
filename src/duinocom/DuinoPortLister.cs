using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace duinocom
{
	public class DuinoPortLister
	{
		public DuinoPortLister ()
		{
		}

		public string[] GetList()
		{
			var list = new List<string> ();

			try
			{
				string[] portNames = SerialPort.GetPortNames();

				var identifier = new DuinoIdentifier();

				for (int i = portNames.Length-1; i > 0; i--) // Iterate backwards because the port is often at the end.
				{
					var portName = portNames[i];
					var port = new SerialPort(portName, 9600); // TODO: Move the baud rate to a property
					var id = identifier.Identify(port);
					if (!String.IsNullOrEmpty(id))
					{
						list.Add(id);
					}
				}
			}
			catch (Exception)
			{
			}

			return list.ToArray();

		}

		public Dictionary<string, string> GetDictionary()
		{
			var dict = new Dictionary<string, string> ();

			try
			{
				string[] portNames = SerialPort.GetPortNames();

				var identifier = new DuinoIdentifier();

				for (int i = portNames.Length-1; i > 0; i--) // Iterate backwards because the port is often at the end.
				{
					var portName = portNames[i];
					var port = new SerialPort(portName, 9600); // TODO: Move the baud rate to a property
					var id = identifier.Identify(port);
					if (!String.IsNullOrEmpty(id))
					{
						dict.Add(portName, id);
					}
				}
			}
			catch (Exception)
			{
			}

			return dict;
		}
	}
}

