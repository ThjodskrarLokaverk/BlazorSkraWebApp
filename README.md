# Form Portal
A web application that can submit forms to predefined email addresses. This application is the outcome of the 
Final Assignment of 5 students at [Reykjavik University](https://ru.is), where they studied Computer Science (B.Sc.)

## Getting Started
This sofware was made using .Net Core 3.1 and Blazor Components. It was created using Mac and Windows operating systems, using Visual Studio Code and Visual Studio.
### Prerequisites & operating sytems
So far, this software has only been tested on "up-to-date" Mac and Windows operating systems (and this text is written in May 2020).
In order to run it on older legacy operating systems (OS) or even Linux operating systems, one simply has to try it for himself. A word of advice before doing that: Make sure their OS installation is as up-to-date as possible before starting.

To give an idea of running requirements: If one downloads the bundle and extracts it, it will take 8 MB of memory. After "dotnet build" has been ran, it will take about 90 MB of space. As a rule of thumb; any *ok student laptop* can run this solution.

## Prerequisites
Don't know what Blazor is? [Read here](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.1)


## Installing
Start by installing software bundles:
# Windows 10 OS
1) Make sure Internet Information Service is enabled in Contol Panel.
2) Download and install the latest stable release of [.Net Core SDK](https://dotnet.microsoft.com/download). Currently, that is version 3.1. 
3) Download and install [Visual Studio Core](https://code.visualstudio.com/download). Choose "Add to path" when installing Visual Studio Code. 
4) Clone or download this git repository.
5) Open the solution in Visual Studio Code, then build the solution running "dotnet build" in terminal, and then run "dotnet ef migrations 'name of migration'" to migrate a database on your pc.


To Compile
1) In command prompt (terminal), start by unzipping the files. 
2) Then navigate to the folder where the unzipped files are, and type in: dotnet build 
This will trigger the build of the solution.

To run
run the solution on your computer by typing the following in command prompt (terminal) in the solution is located:
    dotnet.run 

## Built With
* [VS Code ](https://code.visualstudio.com/) - A nice editor. Other editors will also work fine.

## Authors
* Benedikt Rúnar Valtýsson - [Benedikt on Github](https://github.com/BenediktRunar)
* Bjarki Baldvinsson - [Bjarki on Github](https://github.com/Bjarkibadda)
* Hannes Kristjánsson - [Hannes on Github](https://github.com/hkristjansson)
* Fjölnir Unnarsson - [Fjölnir on Github](https://github.com/fjolnirunnarsson)
* Þórný Stefánsdóttir - [Þórný on Github](https://github.com/thornystefans)

## Acknowledgments
* Bjarni Konráð Árnason, programmer at [Registers Iceland](https://skra.is/english/individuals)
* Tryggvi R. Jónsson, Quality- Security and Data Protection Officer at [Registers Iceland](https://skra.is/english/individuals)
* Hildur Andrjésdóttir, instructor during this project.









