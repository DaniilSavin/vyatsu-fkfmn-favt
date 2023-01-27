@echo off

  rem ���塞 ����஢�� ��� ࠡ��� � ॥��஬

FOR /F "tokens=*" %%A IN ('CHCP') DO FOR %%B IN (%%~A) DO SET CodePage=%%B
chcp 1251 > nul

  rem ���� ����� ��� ���㬥���

for /f "tokens=2*" %%a In ('reg query "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders" ^| Find /i "Personal"') Do (set MyDocuments=%%b)

  rem ���� ����� � �ਬ�ࠬ�

for /f "tokens=2*" %%a In ('reg query "HKEY_LOCAL_MACHINE\SOFTWARE\BaseGroup Labs\Deductor\Common" ^| Find /i "SamplesDir"') Do (set Source=%%b)

  rem ����⠭�������� ����஢��

chcp %CodePage% > nul

  rem ����஢���� �����
  
if "%MyDocuments%" == "" (goto errmydoc)
if "%Source%" == "" (goto errnotfound)
if not exist "%Source%\" (goto errnotfound)
xcopy "%Source%" "%MyDocuments%\Deductor\Samples\" /S /E /Y /Q /R /I
if not errorlevel == 0 (goto errcopy)

  rem ���������� ���� �ᯮ������� � ॥���

reg add "HKEY_CURRENT_USER\SOFTWARE\BaseGroup Labs\Deductor\Common" /v "SamplesDir" /t "REG_SZ" /d "%MyDocuments%\Deductor\Samples" /f
chcp %CodePage% > nul
echo "�ਬ��� ࠧ��饭� � ��४���:"
echo %MyDocuments%\Deductor\Samples
goto exit

:errmydoc
echo "�� ������� ����� ��� ���㬥���"
goto exit

:errnotfound
echo "�����ਬ��� �� ��⠭������" 
goto exit

:errcopy
echo "�訡�� ����஢���� 䠩���"
goto exit

:exit

pause
