using System;
using System.IO;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace duinocom
{
	public class DuinoCommunicator : IDisposable
	{
		public string CommandLogPath = Path.GetFullPath ("commandLog.txt");
		public SerialPort Port { get; set; }

		public DuinoCommunicator(string portName)
		{
			Port = new SerialPort(portName, 9600);
		}

		public void Open()
		{
			//if (Port.IsOpen)
			//	Port.Close ();
			Port.Open ();
		}

		public void Send(string arduinoCommand)
		{
			Thread.Sleep (1500);

			Port.Write (arduinoCommand);
			Port.Write (Port.NewLine);
		}

		public string SendAndRead(string arduinoCommand)
		{
			if (!Port.IsOpen)
				Open ();
			
			Thread.Sleep (1500); // Fails if this delay is any shorter

			Port.Write (arduinoCommand);
			Port.Write (Port.NewLine);

			Thread.Sleep (1000); // Fails if this delay is any shorter

			return Read ();
		}

		public string Read()
		{
			var returnMessage = String.Empty;
			int count = Port.BytesToRead;
			int intReturnASCII = 0;
			while (count > 0) {
				intReturnASCII = Port.ReadByte ();
				returnMessage = returnMessage + Convert.ToChar (intReturnASCII);
				count--;
				Thread.Sleep (20);
			}

			return returnMessage.Trim();
		}

		public void LogCommand(string arduinoCommand, string arduinoResult)
		{
			File.AppendAllText (CommandLogPath, "Command:" + Environment.NewLine);
			File.AppendAllText (CommandLogPath, arduinoCommand + Environment.NewLine);
			File.AppendAllText (CommandLogPath, "Result:" + Environment.NewLine);
			File.AppendAllText (CommandLogPath, arduinoResult + Environment.NewLine);
			File.AppendAllText (CommandLogPath, Environment.NewLine + Environment.NewLine);
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			Port.Close ();
		}

		#endregion
	}
}

