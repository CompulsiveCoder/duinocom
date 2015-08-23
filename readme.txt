---------------
Duinocom Readme
---------------
Duinocom is a library used for serial communication between an arduino compatible device and a PC.

To send a message via the command line...
  1) Install necessary packages:
     sudo apt-get install mono-complete

  2) Move to release bin directory:
     cd bin/Release

  3) Send message:
     mono duinocom.exe [message]
     # Examples:
     mono duinocom.exe H13
     # Multiple commands:
     mono duinocom.exe "H13;L13;"
    

To edit the arduino library or example sketch...

  1) Open and edit .c and .cpp files in:
     /src/sketch/duinocom/src/duinocom

  2) Edit code

  3) Save file

  4) Copy library files to arduino sketchbook libraries folder:
     sh src/sketch/duinocom/to-duino-lib.sh

  5) Compile and run sketch in Arduino IDE


To build the C# and ASP.NET source code...

  1) Install necessary packages:
    sudo apt-get install mono-complete

  2) Run build script:  
    sh src/build.sh


To set up the C# and ASP.NET source code for development:
  1) Install the necessary packages:
    sudo apt-get install mono-complete monodevelop monodevelop-nunit

  2) Open the following file in monodevelop:
    src/duinocom.sln


To run the sanity test (and ensure the system is working)...
  1) Connect an arduino via USB

  2) Install 'outputpins' example sketch to the arduino compatible

  3) Run the sanity test script:
     sh src/sanity-test-cs.sh
     # or
     sh src/sanity-test-cs-debug.sh
