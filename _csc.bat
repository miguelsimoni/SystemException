@path %windir%\Microsoft.NET\Framework\v1.1.4322;
@rem cd %userprofile%\Mis documentos\asistvlite
@csc /target:winexe /out:.\SystemException.scr SystemException.cs /win32icon:app.ico /res:app.ico /reference:system.drawing.dll,system.windows.forms.dll
@pause