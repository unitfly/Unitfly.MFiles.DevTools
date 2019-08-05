# Unitfly.MFiles.DevTools

These M-Files Dev Tools are designed to help automate repetitive parts of M-Files configuration process.
The solution currently contains a single tool: **AliasUpdate**, which enables batch set or update of vault aliases.

## AliasUpdate.App

Console application that updates M-Files vault aliases using a set of rules and templates defined in json configuration file.

### Getting started:

- Download latest release from [releases page](https://github.com/unitfly/Unitfly.MFiles.DevTools/releases)
- Extract files from zip archive
- Edit settings in *appsettings.json* file
- Run *Unitfly.MFiles.DevTools.AliasUpdate.App*
- To see available commands, type `help`

![help](https://github.com/unitfly/Unitfly.MFiles.DevTools/raw/master/images/AliasUpdate.App.Help.PNG)

- To see usage information and available options on any command, run `help {commandName}`

![run-help](https://github.com/unitfly/Unitfly.MFiles.DevTools/raw/master/images/AliasUpdate.App.Run.Help.PNG)

- Execute `run` command to execute alias update

For more more details on running and configuring this tool, check out [wiki page](https://github.com/unitfly/Unitfly.MFiles.DevTools/wiki/Alias-Update).

## AliasUpdate

Class library that exposes methods for mass update of M-Files aliases. This library is used in *AliasUpdate.App*.

## DevTools.Common

Class library that contains common classes used in tools.


## DevTools.Common.Tests

Unit tests of functionality exposed in DevTools.Common project.
