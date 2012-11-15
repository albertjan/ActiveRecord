call "%VS80COMNTOOLS%vsvars32.bat"
ildasm /all /out=%1.il %1.dll
ilasm /dll /key=..\..\buildscripts/CastleKey.snk %1.il
pause