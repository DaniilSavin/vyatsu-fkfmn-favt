@echo off

  rem Меняем кодировку для работы с реестром

FOR /F "tokens=*" %%A IN ('CHCP') DO FOR %%B IN (%%~A) DO SET CodePage=%%B
chcp 1251 > nul

  rem Адрес папки мои документы

for /f "tokens=2*" %%a In ('reg query "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders" ^| Find /i "Personal"') Do (set MyDocuments=%%b)

  rem Адрес папки с примерами

for /f "tokens=2*" %%a In ('reg query "HKEY_LOCAL_MACHINE\SOFTWARE\BaseGroup Labs\Deductor\Common" ^| Find /i "SamplesDir"') Do (set Source=%%b)

  rem Восстанавливаем кодировку

chcp %CodePage% > nul

  rem Копирование папок
  
if "%MyDocuments%" == "" (goto errmydoc)
if "%Source%" == "" (goto errnotfound)
if not exist "%Source%\" (goto errnotfound)
xcopy "%Source%" "%MyDocuments%\Deductor\Samples\" /S /E /Y /Q /R /I
if not errorlevel == 0 (goto errcopy)

  rem Добавление адреса расположения в реестр

reg add "HKEY_CURRENT_USER\SOFTWARE\BaseGroup Labs\Deductor\Common" /v "SamplesDir" /t "REG_SZ" /d "%MyDocuments%\Deductor\Samples" /f
chcp %CodePage% > nul
echo "Примеры размещены в директорию:"
echo %MyDocuments%\Deductor\Samples
goto exit

:errmydoc
echo "Не найдена папка Мои документы"
goto exit

:errnotfound
echo "Демопримеры не установлены" 
goto exit

:errcopy
echo "Ошибка копирования файлов"
goto exit

:exit

pause
