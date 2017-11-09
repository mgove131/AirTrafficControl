@echo off
rem Pulls the Release exe into this folder.
rem Do a Release build first

set project=AirTrafficControl

xcopy .\%project%\bin\Release\*.exe . /y

@echo on