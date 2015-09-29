using System;
using NUnit.Framework;
using System.IO;

namespace duinocom.Upload.Tests.Integration
{
  [TestFixture]
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
    public void Test_Upload()
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
  }
}

