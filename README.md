# File and folder generator

It is nothing more than a bit of a "numpty" project. It is basically a script to create a ton of random files quickly, it randomises between the following file extensions (XLSX, DOCX, TXT, SQL, PDF, CS).

It randomly might cause nested folders (by design) and also change the file created dates. It will produce a maximum of a 100 files per folder, and no more than 15 nested folders.

All files are created with no content which means if trying to open a file depends on the application used to open it whether it will behave or not, but this isn't about whats inside, its all about whats on the outside!

By default, when the program is run, it will create a `files` directory in the `bin` folder, if you want to change this location, edit line 11 of `Program.cs` to point to whereever you like.

When run in debug mode, it will automatically delete the `files` directory and recreate it in the name of housekeeping!

The project requires the .NET 8 runtime.

You are free to do whatever you like with this without licence, but there is no warranty and I can not be held liable for whatever stupid things you decide to try and do with it!

![image](https://github.com/cmjchrisjones/FileAndFolderAutoGenerator/assets/3969086/f3ae8d44-3b01-475f-9d4f-0dbf41d2d2ec)

![image](https://github.com/cmjchrisjones/FileAndFolderAutoGenerator/assets/3969086/820b1705-65f2-448c-bcf5-d5cf50baa647)

Enjoy 

Chris