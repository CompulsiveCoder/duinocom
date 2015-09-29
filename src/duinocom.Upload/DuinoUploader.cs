using System;
using System.IO;
using System.Diagnostics;

namespace duinocom.Upload
{
  public class DuinoUploader
  {
    public string Error = "";

    public DuinoUploader ()
    {
    }

    public void InstallOnUbuntu()
    {
      ExecuteCommand ("apt-get mono-runtime");
    }

    public string UploadSketch(string directory, string port, string board, string code)
    {
      var tmpDir = Path.GetFullPath ("_tmp");

      var uniqueDir = Path.Combine (tmpDir, Guid.NewGuid ().ToString ());

      var sketchDir = Path.Combine (uniqueDir, "sketch");

      var srcDir = Path.Combine (sketchDir, "src");

      Directory.CreateDirectory (srcDir);

      Directory.CreateDirectory (tmpDir);
      Directory.CreateDirectory (uniqueDir);
      Directory.CreateDirectory (sketchDir);

      Directory.SetCurrentDirectory (sketchDir);

      return UploadSketchFile (directory, port, board, sketchDir);
    }


      public string UploadSketchFile(string directory, string port, string board, string sketchDirectoryPath)
      {
        var sketchPath = Path.Combine (sketchDirectoryPath, "sketch.ino");

        var output = "";

        ExecuteCommand("ino init");
    
        File.WriteAllText (sketchPath, sketchDirectoryPath);

        output += ExecuteCommand("ino build -m " + board);

        // TODO: Enable port parameter
        output += ExecuteCommand("ino upload -m " + board);// + " -p " + port;
      
        Console.WriteLine("Finished");

        if (output.IndexOf("No device matching following was found") > -1)
        {
          Error = "No duino compatible device deteceted. Is it plugged in?";
        }

        return output;
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
        var process = Process.Start(startInfo);
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        Console.WriteLine(output);
        return output + Environment.NewLine;
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

