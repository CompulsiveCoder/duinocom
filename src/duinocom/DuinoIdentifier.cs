using System;
using System.IO.Ports;
using System.Threading;

namespace duinocom
{
	public class DuinoIdentifier
	{
		static public string IdentifyRequest = "I";

		public DuinoIdentifier ()
		{
		}

		public string Identify(SerialPort port)
		{
			string returnMessage = "";
			try {
				if (port.IsOpen)
					port.Close ();

				port.Open ();

				Thread.Sleep (1500); // Fails sometimes if this delay is any shorter

				port.Write (IdentifyRequest);
				port.Write (port.NewLine);

				Thread.Sleep (500); // Fails sometimes if this delay is any shorter

				int count = port.BytesToRead;
				int intReturnASCII = 0;
				while (count > 0) {
					intReturnASCII = port.ReadByte ();
					returnMessage = returnMessage + Convert.ToChar (intReturnASCII);
					count--;
				}
			} catch {
			} finally {
				port.Close ();
			}

			return returnMessage.Trim();
		}
	}
}

