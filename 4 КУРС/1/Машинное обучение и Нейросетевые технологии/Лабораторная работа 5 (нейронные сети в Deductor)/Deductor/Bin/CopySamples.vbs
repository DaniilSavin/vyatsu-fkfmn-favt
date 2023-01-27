'
'������ ��� ���������� ������������ � �������� "��� ���������" �������� ������������
'

Dim WshShell: Set WshShell = WScript.CreateObject("WScript.Shell")
'���������� � ������� ��������� ������� ��� ���������
Dim DirFrom
'����������, � ������� ����� ����������� ������� 
Dim DirTo: DirTo = WshShell.SpecialFolders("MyDocuments") & "\BaseGroup\Deductor\Samples"
'���� � ��������� ����������, � ������� ���� ��������� ����������� ��� ���������
Const CommonKey = "HKEY_LOCAL_MACHINE\SOFTWARE\BaseGroup Labs\Deductor\Common\SamplesDir"
'���� � ���������, ��� ������� ��������� � �������� "��� ���������" �������� ������������
Const UserKey = "HKEY_CURRENT_USER\SOFTWARE\BaseGroup Labs\Deductor\Common\SamplesDir"

Const LS_ErrCopyFolder = "�� ������� ���������� �����������"
Const LS_ErrFindRegKey = "����������� �� ���� �����������"
Const LS_Success       = "������� ��������� � ����������:"
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
' ������� ����������� ����� �� ����������
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
' ����������� �������� ��������
'
Sub MakeDirRecursive(DirectoryPath, objFSO)
  If objFSO.FolderExists(DirectoryPath) Then Exit Sub
  MakeDirRecursive objFSO.GetParentFolderName(DirectoryPath), objFSO
  objFSO.CreateFolder(DirectoryPath)
End Sub

'
' ����������� ������ ��������� ������ �� ����� �������, ���� ���� �� ������ ������ False
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
