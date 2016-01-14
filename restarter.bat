@echo off
:loop
start "wServer" ""C:\Users\Rishi\Desktop\Doom\OwlRealms\bin\Debug\wServer\wServer.exe"
timeout /t 1850 >null
taskkill /f /im wServer.exe >nul
goto loop