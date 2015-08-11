using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports; //required for SerialPort class
using System.Threading;
using duinocom;

namespace DetectPort
{
	class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine (new DuinoPortDetector ("duinocom").Detect ());
		}

	}
}