# maze-generator
A .net core console app for creating custom mazes

Optional Parameters
======
| Name    | Command        | Description |
| ------- |----------------| -------------------------------|
| Width   | `-w <integer>` | Set the width of the maze that will be generated. |
| Height  | `-h <integer>` | Set the height of the maze that will be generated. |
| Noise   | `-n <integer>` | Set the noise of the maze that will be generated. (1-10) |
| Path    | `-p <string>`  | Set the path where the maze file will be created. |
| Debug   | `-d <boolean>` | If enabled output will show in the console and remain open. |
| View    | `-v <boolean>` | If enabled maze will show in default photo viewer after generation. |

Build EXE
======
[dotnet build -r win10-x64](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog#using-rids "Microsoft Docs")