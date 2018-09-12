# Justine - Discord bot

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/petrspelos/Justine/blob/master/LICENSE)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/d9c0114f2072429eb520ed02dd2fa966)](https://app.codacy.com/app/petrspelos/Justine?utm_source=github.com&utm_medium=referral&utm_content=petrspelos/Justine&utm_campaign=Badge_Grade_Dashboard)
[![Build status](https://ci.appveyor.com/api/projects/status/5sqa35gu330v6dxc?svg=true)](https://ci.appveyor.com/project/petrspelos/justine)
[![Coverage Status](https://coveralls.io/repos/github/petrspelos/Justine/badge.svg?branch=master)](https://coveralls.io/github/petrspelos/Justine?branch=master)


Meet **Justine**. :woman:

A personal (and Open Source) bot for Discord written in C# using the [Discord .NET library](https://github.com/RogueException/Discord.Net). :v:

I started making this bot for the management of my C# bot-making [help server](https://discord.gg/cGhEZuk). :ghost:

My instance of Justine is hosted on a [Raspberry Pi 3B](https://www.raspberrypi.org/products/raspberry-pi-3-model-b/) running [Windows 10 IoT](https://developer.microsoft.com/en-us/windows/iot). :floppy_disk:

## Getting Started

The following instructions describe a step by step process of getting Justine on your local machine and ready for development.

If you're interested in hosting your own instance of Justine, check the notes in [deployment](#deployment).

### Prerequisites

* The recommended IDE is [Visual Studio Code](https://code.visualstudio.com/).
* You will also need the [.NET Core](https://www.microsoft.com/net/download) framework.

### Installation

**Getting the source**

If you would like to contribute:
1. [Fork the repository](https://help.github.com/articles/fork-a-repo/).
2. Navigate to your fork.
3. [Clone](https://help.github.com/articles/cloning-a-repository/) your fork to your local machine.

If you just want a copy of the code:
1. Directly [Clone](https://help.github.com/articles/cloning-a-repository/) or [download as a ZIP](https://stackoverflow.com/a/6466993) of this repository. :raised_hands:

**Setting up the development environment**

* The solution file can be found at `./src/Justine.sln`, it links to the two `.csproj` files: `Justine.csproj` and `Justine.NUnit.Tests.csproj` for unit tests.

* It is recommended to open the root directory in your IDE.

* After that, you should be ready to develop.

## Running the tests

To run Unit Tests in Visual Studio Code, you use the `CTRL + SHIFT + P` shortcut to open the command palette where you can invoke the `Tasks: Run Test Task` command.

:information_source: Justine comes with `.vscode/tasks.json` file which is used by Visual Studio Code to setup the default Build and Test tasks. After selecting the `Tasks: Run Test Task` command, you should be able to select the predefined `test` task.

_If you don't see the test task, make sure you opened the root folder in Visual Studio Code._

Alternatively, you can navigate to the `src/` directory in through command prompt and run the following command: 
``` bash
dotnet test ./Justine.NUnit.Tests/Justine.NUnit.Tests.csproj /p:CollectCoverage=true /p:Include=[Justine]* /p:Exclude=\"[Justine]Justine.Discord.*,[Justine]Justine.Program,[NUnit3.TestAdapter]*\" /p:CoverletOutputFormat=opencover /p:Threshold=100 /p:ThresholdType=line
```

This command will run the Unit Tests as well as generate the code coverage report.

*Note that Unit Tests will fail if your code coverage is bellow 100%.

## Deployment

To publish a version of Justine and run it on a machine, you can use [this tutorial](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore2x) that walks you through the process.

* When running the application for the first time, a notice about an invalid token might appear. If this happens, close the application, check its directory and search for `App.xml` (can be `Justine.dll.xml`). Edit this file and make sure to put your token in the right place. The next launch of the application should properly connect.

## Database

Justine is using SQLlite for her data storage and requires a `Justine.db` file with a specific setup. You can find an example `Justine.db` file in the `./src/Justine.NUnit.Tests/` folder. This database is used for testing and contains minor dummy entries.

Release versions of Justine contain an empty and ready-to-go database in their ZIP file.

## Built With

* [.NET Core 2.0](https://docs.microsoft.com/en-us/dotnet/core/) - Platform used
* [Discord .NET](https://github.com/RogueException/Discord.Net) - Discord API wrapper library
* [NUnit](https://nunit.org/) - Testing Framework
* [Lamar](https://jasperfx.github.io/lamar/) - Inversion of Control container
* [MS Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Microsoft's Entity Framework solution
* :heart: Passion and a healthy bit of self-interest :yum:

## Contributing

Hey, thank you so much for trying to contribute! It is super nice of you! :two_hearts:

This is just my personal playground, feel free to learn from it, but if you want to contribute, check out [Miunie The Community Bot](https://github.com/petrspelos/Community-Discord-BOT). :yellow_heart:

:information_source: Though if you **super want to help out**, I will be only glad to see your pull requests. =)

## Author

* **Petr Sedláček** - *Developer* - [PetrSpelos](https://github.com/petrspelos)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
