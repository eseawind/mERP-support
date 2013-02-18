mkdir .\Reference\Script
cd PythonScript
if exist pythonFiles.txt del pythonFiles.txt>nul
dir /s /b *.py > pythonFiles.txt
for /f %%i in (pythonFiles.txt ) do copy %%i ..\Reference\Script
del pythonFiles.txt>nul
cd ..


.\Reference\ipy.exe .\build_python.py

.\Reference\ipy.exe .\upload_python.py

IF ERRORLEVEL 1 pause