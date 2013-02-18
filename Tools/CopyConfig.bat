set ConfigDir=.\Hd.Run

copy %ConfigDir%\app.config .\Reference\Feng.Run.exe.config
rem copy %ConfigDir%\release.config .\Reference\Feng.Run.exe.config
copy %ConfigDir%\hd.model.*.config .\Reference

copy %ConfigDir%\ADInfosUtil.exe.config .\Reference\

copy %ConfigDir%\neokernel.exe.config .\Reference\
copy %ConfigDir%\mime_types .\Reference\
copy %ConfigDir%\neokernel_props.xml .\Reference\

copy %ConfigDir%\ipy.exe.config .\Reference\ipy.exe.config

.\Reference\ipy.exe .\encrypt_connectionstring.py


IF ERRORLEVEL 1 pause