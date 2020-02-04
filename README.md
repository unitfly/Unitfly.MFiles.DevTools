# Unitfly.MFiles.DevTools

These M-Files Dev Tools are designed to help automate repetitive parts of M-Files configuration process.

The solution currently contains the following tools:

- [**Rename**](#Rename) - enables batch rename of vault structure elements
- [**Alias Update**](#Alias-Update) - enables batch set or update of vault structure elements' aliases
- [**Sql Generator**](#Sql-Generator) - generates sql queries (CREATE, UPDATE, INSERT, DELETE) for M-Files classes

## Rename

Console application that enables batch rename of M-Files vault structure elements:

- classes
- user groups
- object types
- value lists
- property definitions
- workflows
- workflow states
- workflow transitions

### Getting started

- Download latest release from [releases page](https://github.com/unitfly/Unitfly.MFiles.DevTools/releases)
- Extract files from zip archive
- Navigate to *Rename* folder
- Edit settings in *appsettings.json* file
- Run *Unitfly.MFiles.DevTools.Rename.App*
- To see available commands, type `help`

![help](https://github.com/unitfly/Unitfly.MFiles.DevTools/raw/master/images/Rename.Help.png)

- To see usage information and available options on any command, run `help {commandName}`

For more more details on running and configuring this tool, check out [wiki page](https://github.com/unitfly/Unitfly.MFiles.DevTools/wiki/Rename).

## Alias Update

Console application that updates M-Files vault aliases using a set of rules and templates defined in json configuration file. Vault structure elements that can be updated this way are:

- classes
- user groups
- object types
- value lists
- property definitions
- workflows
- workflow states
- workflow transitions

### Getting started

- Download latest release from [releases page](https://github.com/unitfly/Unitfly.MFiles.DevTools/releases)
- Extract files from zip archive
- Navigate to *AliasUpdate* folder
- Edit settings in *appsettings.json* file
- Run *Unitfly.MFiles.DevTools.AliasUpdate.App*
- To see available commands, type `help`

![help](https://github.com/unitfly/Unitfly.MFiles.DevTools/raw/master/images/AliasUpdate.Help.png)

- To see usage information and available options on any command, run `help {commandName}`

- Execute `run` command to execute alias update

For more more details on running and configuring this tool, check out [wiki page](https://github.com/unitfly/Unitfly.MFiles.DevTools/wiki/Alias-Update).

## Sql Generator

Console application that generates sql queries (CREATE, UPDATE, INSERT, DELETE) for M-Files classes that can be used in connection to external database.
Application uses a set of rules and settings defined in json configuration file to establish connection to an M-Files vault and to normalize class and property names in generated SQL queries.

### Getting started

- Download latest release from [releases page](https://github.com/unitfly/Unitfly.MFiles.DevTools/releases)
- Extract files from zip archive
- Navigate to *SqlGenerator* folder
- Edit settings in *appsettings.json* file
- Run *Unitfly.MFiles.DevTools.SqlGenerator.App*
- To see available commands, type `help`

![help](https://github.com/unitfly/Unitfly.MFiles.DevTools/raw/master/images/SqlGenerator.Help.png)

- To see usage information and available options on any command, run `help {commandName}`

For more more details on running and configuring this tool, check out [wiki page](https://github.com/unitfly/Unitfly.MFiles.DevTools/wiki/Sql-Generator).
