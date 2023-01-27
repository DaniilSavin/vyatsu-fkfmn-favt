'
'Скрипт для размещения демопримеров в каталоге "Мои документы" текущего пользователя
'

Dim WshShell: Set WshShell = WScript.CreateObject("WScript.Shell")
'Директория в которой находятся примеры при установке
Dim DirFrom
'Директория, в которую нужно скопировать примеры 
Dim DirTo: DirTo = WshShell.SpecialFolders("MyDocuments") & "\BaseGroup\Deductor\Samples"
'Ключ с указанием директории, в которую были размещены демопримеры при установке
Const CommonKey = "HKEY_LOCAL_MACHINE\SOFTWARE\BaseGroup Labs\Deductor\Common\SamplesDir"
'Ключ с указанием, что примеры находятся в каталоге "мои документы" текущего пользователя
Const UserKey = "HKEY_CURRENT_USER\SOFTWARE\BaseGroup Labs\Deductor\Common\SamplesDir"

Const LS_ErrCopyFolder = "Не удалось разместить демопримеры"
Const LS_ErrFindRegKey = "Демопримеры не были установлены"
Const LS_Success       = "Примеры размещены в директорию:"
Dim CRLF: CRLF         = Chr(13) & Chr(10)


If RegReadEx(CommonKey, DirFrom) Then 
  If CopyFolders(DirFrom, DirTo) Then
    WshShell.RegWrite UserKey, DirTo, "REG_SZ"
    WScript.Echo LS_Success & CRLF & DirTo
  Else
    WScript.Echo LS_ErrCopyFolder
  End If
Else
  WScript.Echo LS_ErrFindRegKey
End If


'
' Функция копирования папок со структурой
'
Function CopyFolders(Source, Dest)
  On Error Resume Next
  Dim FSO: Set FSO = CreateObject("Scripting.FileSystemObject")
  MakeDirRecursive Dest, FSO
  If FSO.FolderExists(Source) And FSO.FolderExists(Dest) Then FSO.CopyFolder Source, Dest
  If Err.Number <> 0 Then
    CopyFolders = False
  Else
    CopyFolders = True
  End If
  On Error GoTo 0
End Function

'
' Рекурсивное создание каталога
'
Sub MakeDirRecursive(DirectoryPath, objFSO)
  If objFSO.FolderExists(DirectoryPath) Then Exit Sub
  MakeDirRecursive objFSO.GetParentFolderName(DirectoryPath), objFSO
  objFSO.CreateFolder(DirectoryPath)
End Sub

'
' Расширенная версия получения данных по ключу реестра, если ключ не найдет вернет False
'
Function RegReadEx(KeyPath, KeyValue)
  On Error Resume Next
  KeyValue = WshShell.RegRead(KeyPath)
  If Err.Number <> 0 Then
    RegReadEx = False
    KeyValue = ""
  Else
    RegReadEx = True
  End If
  On Error GoTo 0
End Function
