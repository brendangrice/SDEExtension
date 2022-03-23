This is a Final Year Project for a undergraduate bachelor degree at Maynooth University by Brendan Grice

The SDEExtension is a Visual Studio extension that works on top Visual Studio to interface with the Intel Software Development Emulator (SDE). Various tools can be used from the SDE to help with debugging while using Visual Studio.

This software is intended for Visual Studio 2019 and later, both to build and install.

Building:
The SDEExtension can be built in Visual Studio using the solution file attached. Simply Build>Build Solution in either Debug or Release.

A VSIX file will be built at ...\SDEExtension\SDEExtension\bin\[Debug/Release]\SDEExtension.vsix

Installation:
Opening the vsix file produced from building will attempt to install the SDEExtension using the VSIX Installer. Selecting 'Install' when prompted will install the extension. Visual Studio and its instances will need to be closed.

A temporary Visual Studio environment (devenv.exe) can be launched through Visual Studio by hitting 'Run' in a Visual Studio instance with the SDEExtension solution open. This temporary enviornment will automatically have the SDEExtension installed and can be tested out.

Uninstallation:
The SDEExtension can be uninstalled from Visual Studio using the VSIX installer. In Visual Studio, navigate to Extensions>Manage Extensions>Installed the SDEExtension should then be visible and an accompanying 'Uninstall' button present. Clicking this button will schedule the extension for uninstallation when Visual Studio is next closed.

Hotkeys:
A sample Hotkey interface is included with the repo as SDEExtension-Sample-Hotkeys-Exported-2022-03-23.vssettings
This can be imported using Tools>Import and Export Settings>Import selected
environment settings>Next>My settings>Browse>[Choose File]>Next>Finish

This adds CTRL+ALT+SHIFT+Z as a hotkey to open the SDEExtension.

Usage:

The SDEExtension can be opened through View>Other Windows>SDEExtension
Upon first use the SDEExtension may be the wrong size to view all the components. The tool window can be resized as any other Visual Studio tool window can, by dragging the edges. This is a one time operation as Visual Studio will save the size of the extension for future use after resizing it.

The SDEExtension can be used in -mix or -debugtrace mode. Which can be accessed through the drop down window at the top of the Tool Window. 
A second drop down window is adjascent which can be used to adjust the architecture used.

Supported Architectures:

Different functionality is available depending on the mode:

-mix
	Selecting 'Architecture'.
	'Run'ning the program to generate the sde-mix-out.txt file.
	'Process'ing the sde-mix-out.txt file.
	'Ignore Windows Calls' skip Windows functions in the processing.

-mix provides a file giving an overview of code run in function blocks and how common these functions are. Windows programs are filled with boilerplate windows code, it is inevitable that smaller programs have their functions overshadowed by system libraries. However, depending on the compiler and complexity of the program. The program can compile down to just using system functions. This will return "Couldn't find a match" if Windows calls are ignored as the software has nothing else to monitor.

-debugtrace
	Selecting 'Architecture'.
	'Run'ning the program to generate the sde-debugtrace-out.txt file.
	'Process'ing the sde-debugtrace-out.txt.
	'Recording Read/Write' operations.

-debugtrace outputs a very large file. It is a record of every line executed while running the program. Because of this, output files can be VERY LARGE so it is worth considering if storage space is a concern. Both running and processing also take significantly longer because of this. -debugtrace processing requires a start address and end address of the range of instructions to examine. Offering 0x0 for the start address will read from the first line, 0x0 for the end address will read to the last line. Because the execution is notably long it is optional for the users to check for Read/Write instructions. 
