# Form Portal
A web application that can submit forms to predefined email addresses. This application is the outcome of the 
Final Assignment of 5 students at [Reykjavik University](https://www.ru.is), where they studied Computer Science (B.Sc.)

## Getting Started
This sofware was made using .Net Core 3.1 and Blazor Components. It was created using Mac and Windows operating systems, using Visual Studio Code and Visual Studio.
### Prerequisites & operating sytems
So far, this software has only been tested on "up-to-date" Mac and Windows operating systems (and this text is written in May 2020).
In order to run it on older legacy operating systems (OS) or even Linux operating systems, one simply has to try it for himself. A word of advice before doing that: Make sure their OS installation is as up-to-date as possible before starting.

To give an idea of running requirements: If one downloads the bundle and extracts it, it will take 8 MB of memory. After "dotnet build" has been ran, it will take about 90 MB of space. As a rule of thumb; any *ok student laptop* can run this solution.

## Prerequisites
Don't know what Blazor is? [Read here](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-3.1)


## Installing
As mentioned before, this solution is cross-platform, i.e. it can be modified and run on varios operating systems, including MacOs and Windows.

Here are for example instructions on how to edit/run the solution on Windows 10.
### Windows 10 OS
1) Make sure Internet Information Service is enabled in Contol Panel.
2) Download and install the latest stable release of [.Net Core SDK](https://dotnet.microsoft.com/download). Currently, that is version 3.1. 
3) Download and install [Visual Studio](https://visualstudio.microsoft.com/downloads) and choose to include ASP.NET to install necessary packages.
4) Clone or download this git repository.
5) Open the solution in Visual Studio, then build the solution. 


6) Run the solution from Visual Studio (and click yes when asked to install a SSL certificate)

Run the following commands in Package Manager (a console window within Visual Studio):
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;add-migration 'your description goes here'  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;update-database

7) A website should show up in your web browser, shoing the application running at localhost.


Note: The solution can also be built and run from terminal (command prompt) or editors such as Visual Studio Code.

## Run tests
This can be run in cmd prompt (terminal). Open the folder of the application and navigate to the folder BlazorSkraApp1.UnitTests
Once you are located in that folder, give the following command:
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=./lcov.info

## Built With
* [Visual Studio Code](https://code.visualstudio.com/) 
* [Visual Studio](https://visualstudio.microsoft.com/downloads/)

## Authors
* Benedikt Rúnar Valtýsson - [Benedikt on Github](https://github.com/BenediktRunar)
* Bjarki Baldvinsson - [Bjarki on Github](https://github.com/Bjarkibadda)
* Hannes Kristjánsson - [Hannes on Github](https://github.com/hkristjansson)
* Fjölnir Unnarsson - [Fjölnir on Github](https://github.com/fjolnirunnarsson)
* Þórný Stefánsdóttir - [Þórný on Github](https://github.com/thornystefans)

## Acknowledgments
* Bjarni Konráð Árnason, programmer at [Registers Iceland](https://skra.is/english/individuals)
* Hildur Andrjésdóttir, instructor during this project.
* Tryggvi R. Jónsson, Quality- Security and Data Protection Officer at [Registers Iceland](https://skra.is/english/individuals)










