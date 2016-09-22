![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/icon_BefunDebug.png) BefunDebug  [![Build status](https://ci.appveyor.com/api/projects/status/74d7eukglosfvxfn/branch/master?svg=true)](https://ci.appveyor.com/project/Mikescher/befundebug/branch/master)
==========

This is a debug/test/run tool for the other projects in my BefunUtils toolset.

![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/BefunDebug_All.png)

Is is used to

 - test and debug the code generation of BefunGen
 - Output intermediary states of the Textfunge parser
 - Simply access a BefunRep safe (and quickly generate a small one)
 - Get the BefunHighlight befunge-space-graph as ASCII output
 - Debug and benchmark the MSZip befunge code-compression algorithm
 - Compare the BefunCompile results for different languages and inputs
 - Test BefunCompile changes with a big set of example programs
 - Visualize the different optimization steps in BefunCompile with a graph display
 - Debug the BefunCompile stacksize summary module for different optimization levels
 - Compile befunge programs with BefunCompile to multiple output languages
 - Run BefunRun (normal mode and --info mode) for a single program
 - Run BefunRun info mode for multiple test data sets in batch
 - Quickly reverse/flip/rotate a snippet of befunge code
 - Semantically reverse/flip/rotate a snippet of befunge code (keep code flow operands the same, eg flip `<` to `>`)
 - Automatically quash a befunge code (try to remove superfluous whitespace)
 - Generate a large ASCII grid with an ASCII-Art image (from a bitmap/png file)

This program evolved a little bit from a simple debugging tool for some libraries that had no entry point to a bigger Befunge tool with some useful features (crammed together with a lot of unit-test-like stuff and internal debug stuff).  
It would probably be wise to refactor all that stuff into different applications, but I don't want to :D.

Download
========

You can download the binaries from my website [www.mikescher.com](http://www.mikescher.com/programs/view/BefunUtils)

Or you can download the latest (nightly) version from the **[AppVeyor build server](https://ci.appveyor.com/project/Mikescher/BefunDebug/build/artifacts)**

Set Up
======

*This program was developed under Windows with Visual Studio.*

You need the other [BefunUtils](https://github.com/Mikescher/BefunUtils) projects to run this. And because this is for testing, the program alone would be without much use.  
Follow the setup instructions from BefunUtils: [README](https://github.com/Mikescher/BefunUtils/blob/master/README.md)


Screenshots
===========
 
![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/BefunDebug_1.png)

![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/BefunDebug_2.png)

![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/BefunDebug_3.png)

![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/BefunDebug_4.png)

![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/BefunDebug_5.png)

![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/BefunDebug_6.png)

![](https://raw.githubusercontent.com/Mikescher/BefunUtils/master/README-FILES/BefunDebug_7.png)


Contributions
=============

Yes, please