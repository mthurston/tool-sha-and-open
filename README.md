# SHA and open 

A simple dotnet tool that once installed allows users to paste a SHA and "YOLO-pens" a file within your downloads folder if it matches.  Meant primarily for executables and security purposes.

## Features
* **Cross Platform** .NET 8
* **Keeps it Simple** Always targets download folder.  No ambiguity
* **List SHAs** when ran without a SHA will output a table from your downloads folder with two columns: 1) filenames and 2) SHAs.  

## Example Usage

```bash
shaman > 4sho e01fa8be02bc15e706352ee9d5948b74634ac41b18595394549db49af390be82
Now opening "Framework_Laptop_16_Amd_Ryzen7040_BIOS_3.05.exe"

shaman > 4sho 
File                                                SHA
***************************************************************************
Framework_Laptop_16_Amd_Ryzen7040_BIOS_3.05.exe
           e01fa8be02bc15e706352ee9d5948b74634ac41b18595394549db49af390be82
---------------------------------------------------------------------------
mthurston_tool-sha-and-open.zip
           937975297a36de37ef5b672415c1c7e3d920534d921a9157ac656f0f70936484
---------------------------------------------------------------------------
:
``` 
