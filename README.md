# File and folder generator

It is nothing more than a bit of a "numpty" project. It is basically a script to create a ton of random files quickly, it randomises between the following file extensions (XLSX, DOCX, TXT, SQL, PDF, CS).

It randomly might cause nested folders (by design) and also change the file created dates. It will produce a maximum of a 100 files per folder, and no more than 15 nested folders.

By default, when the program is run, it will create a `files` directory in the `bin` folder, if you want to change this location, edit line 11 of `Program.cs` to point to whereever you like.

When run in debug mode, it will automatically delete the `files` directory and recreate it in the name of housekeeping!

The project requires the .NET 8 runtime.

You are free to do whatever you like with this without licence, but there is no warranty and I can not be held liable for whatever stupid things you decide to try and do with it!

Enjoy 

Chris