using System;
using NUnit.Framework;
using System.IO;

namespace duinocom.Upload.Tests.Integration
{
  [TestFixture(Category="Arduino")]
  public class DuinoUploaderTestFixture
  {
    string blinkSketchCode = @"
int led = 13;

void setup() {                
  pinMode(led, OUTPUT);     
}

void loop() {
  digitalWrite(led, HIGH);
  delay(1000);
  digitalWrite(led, LOW);
  delay(1000);
}";

    [Test]
    public void Test_UploadCode()
    {
      var uploader = new DuinoUploader ();

      uploader.UploadCode (blinkSketchCode, "", "nano328");

      if (uploader.Error.Length > 0) {
        Console.WriteLine ("Error:");
        Console.WriteLine (uploader.Error);
      }

      Assert.AreEqual (0, uploader.Error.Length, "Error: " + uploader.Error);

      Console.WriteLine ("Check your arduino. Is it blinking? It should be.");
    }

    [Test]
    public void Test_UploadFromFile()
    {
      var uploader = new DuinoUploader ();

      var tmpDir = Path.Combine (Path.GetFullPath("_tmp"), Guid.NewGuid ().ToString());
      Directory.CreateDirectory (tmpDir);
      tmpDir = Path.Combine(tmpDir, "TestSketch");
      Directory.CreateDirectory (tmpDir);

      var tmpFile = Path.Combine (tmpDir, "Sketch.ino");

      File.WriteAllText (tmpFile, blinkSketchCode);

      uploader.UploadFromFile (tmpFile, "", "nano328");

      if (uploader.Error.Length > 0) {
        Console.WriteLine ("Error:");
        Console.WriteLine (uploader.Error);
      }

      Assert.AreEqual (0, uploader.Error.Length, "Error: " + uploader.Error);

      Console.WriteLine ("Check your arduino. Is it blinking? It should be.");

      Directory.Delete (tmpDir, true);
    }
  }
}

