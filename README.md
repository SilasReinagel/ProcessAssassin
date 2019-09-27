# Process Assassin &middot; [![Build status](https://ci.appveyor.com/api/projects/status/k5xp9v6dbdi231f3?svg=true)](https://ci.appveyor.com/project/TheoConfidor/processassassin) [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](./LICENSE) 

Process Assassin is a .NET Core Console Application

#### Kills unwanted processes whenever they are found running

<img src="./art/logo.jpg" alt="Process Assassin Logo" width="160"/>

----

## Features

1. Kills any process matching any named Target, within a couple of seconds

----

## Build

1. Install the [.NET Core SDK 3.0+](https://dotnet.microsoft.com/download)
2. Clone this repository `git clone https://github.com/SilasReinagel/ProcessAssassin/`
3. Navigate to the `src` folder in your local repository and run `dotnet build`

----

## Installation

After Building the project:

1. `dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true` targetting your [system's runtime](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)
2. Copy the publish output to the installation folder of your choice

----

## Run

1. Run the `help` command to view the other application commands

----

## License

You may use this code in part or in full however you wish.  
No credit or attachments are required.

