# Unitfly.MFiles.DevTools

These M-Files Dev Tools are designed to help automate repetitive parts of M-Files configuration process.
The solution currently contains a single tool: **AliasUpdate**, which enables batch set or update of vault aliases.

## AliasUpdate.App

Console application that updates M-Files vault aliases using a set of rules and templates defined in json configuration file.
For more details on running and configuring this tool, check out [wiki page](https://github.com/unitfly/Unitfly.MFiles.DevTools/wiki/Alias-Update).

## AliasUpdate

Class library that exposes methods for mass update of M-Files aliases. This library is used in *AliasUpdate.App*.

## DevTools.Common

Class library that contains common classes used in tools.


## DevTools.Common.Tests

Unit tests of functionality exposed in DevTools.Common project.
