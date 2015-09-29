﻿using System;
using System.IO;
using System.Diagnostics;

namespace duinocom.Upload
{
  public class DuinoUploader
  {
    public string Error = "";
    public bool IsError { get { return Error.Length > 0; } }

    public DuinoUploader ()
    {
    }

    public void InstallOnUbuntu()
    {
      // TODO: Move to configuration file
      ExecuteCommand ("apt-get mono-runtime");
    }

    public string UploadCode(string code, string port, string board)
    {
      var tmpDir = Path.GetFullPath ("_tmp");

      var uniqueDir = Path.Combine (tmpDir, Guid.NewGuid ().ToString ());

      var sketchDir = Path.Combine (uniqueDir, "sketch");

      var srcDir = Path.Combine (sketchDir, "src");

      var sketchPath = Path.Combine (srcDir, "sketch.ino");

      Directory.CreateDirectory (tmpDir);
      Directory.CreateDirectory (uniqueDir);
      Directory.CreateDirectory (sketchDir);
      Directory.CreateDirectory (srcDir);

      Directory.SetCurrentDirectory (sketchDir);

      var output = "";

      output += ExecuteInit();

      File.WriteAllText(sketchPath, code);

      if (!IsError)
        output += ExecuteBuild(board);

      // TODO: Enable port parameter
      if (!IsError)
        output += ExecuteUpload (board, port);

      CheckOutput (output);

      //Directory.Delete (uniqueDir, true);

      return output;
    }


    public string UploadSketch(string sketchDirectoryPath, string port, string board)
    {

      var srcDir = Path.Combine (sketchDirectoryPath, "src");
      Directory.CreateDirectory (srcDir);

      var output = "";

      output += ExecuteInit();

      if (output.IndexOf ("No project found in this directory.") == -1) {
        if (!IsError)
          output += ExecuteBuild (board);

        // TODO: Enable port parameter
        if (!IsError)
          output += ExecuteUpload (port, board);
    
        CheckOutput (output);
      }

      return output;
    }

    public void CheckOutput(string output)
    {
      if (output.IndexOf("No device matching following was found") > -1)
      {
        Error = "No duino compatible device deteceted. Is it plugged in?";
      }

      if (!IsError) {
        Console.WriteLine ("Finished");
      } else {
        Console.WriteLine("Error");
      }
    }

    public string ExecuteInit()
    {
      return ExecuteCommand("ino init");
    }

    public string ExecuteBuild(string board)
    {
      return ExecuteCommand ("ino build -m " + board);
    }

    public string ExecuteUpload(string board, string port)
    {
      return ExecuteCommand ("ino upload -m " + board);// + " -b " + baudRate);// + " -p " + port;
    }

    public string ExecuteCommand(string command)
    {
      try
      {
        var spacePos = command.IndexOf (" ");
        var firstPart = command.Substring (0, spacePos);
        var secondPart = command.Substring (spacePos+1, command.Length - spacePos-1);

        var startInfo = new ProcessStartInfo(firstPart, secondPart);
        startInfo.UseShellExecute = false;
        startInfo.RedirectStandardOutput = true;
        startInfo.RedirectStandardError = true;
        var process = Process.Start(startInfo);
        process.WaitForExit();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        Console.WriteLine(output);
        Console.WriteLine(error);
        output += error;
        output += Environment.NewLine;
        return output;
      }
      catch(Exception ex)
      {
        string output = "Error" + Environment.NewLine;
        output += ex.ToString () + Environment.NewLine;
        Error += ex.ToString ();
        return output + Environment.NewLine;
      }
    }
  }
}

