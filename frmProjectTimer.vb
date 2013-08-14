'********************  MOD LOG  ****************************
'DATE       NAME           DESCRIPTION     
'---------- -------------  ----------------
'2010-02-18 Jason Atcheson add time (not working as of 3-2-2010)
'2010-02-10 Jason Atcheson double-click pause
'2010-02-23 Jason Atcheson dblclck start/pause
'2010-03-02 Jason Atcheson fix reset none selected
'2010-03-02 Jason Atcheson add reset all
'2010-03-06 Jason Atcheson add list context menu and edit project info
'2010-08-09 Jason Atcheson Use |;| when saving proj name, etc. with commas so when opening they aren't cut off
'2013.06.25 Jason Atcheson Adding save backup (every ten mins)
'***********************************************************

Imports System.IO

Public Class frmProjectTimer
    Private SelectedItem As ListViewItem
    Private colProjects As Collection
    Private dblTotalTime As Double '2013.06.25
    Private strFilename As String '2013.06.25

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim oProject As clsProject
        Dim item As ListViewItem
        Dim bFound As Boolean = False
        Try
            If txtProjID.Text <> "" AndAlso txtProjName.Text <> "" Then
                'mod 2010-03-06 add list context menu and edit project info ++
                If btnAdd.Text = "&Add" Then
                    'mod 2010-03-06 add list context menu and edit project info --

                    For Each oProject In colProjects
                        If oProject.ID = txtProjID.Text Then
                            bFound = True
                        End If
                    Next
                    If Not bFound Then
                        'mod 2010-02-18 add time ++
                        oProject = New clsProject(txtProjID.Text, txtProjName.Text, txtProjDesc.Text)
                        'oProject = New clsProject(txtProjID.Text, txtProjName.Text, txtProjDesc.Text, "00:00:00")
                        'mod 2010-02-18 add time --
                        colProjects.Add(oProject)
                        With lsvProjects()
                            .View = View.Details
                            item = New ListViewItem(oProject.ID)
                            item.SubItems.Add(oProject.Name)
                            item.SubItems.Add(oProject.Description)
                            item.SubItems.Add(oProject.getTime)
                            .Items.Add(item)
                        End With
                        'mod 2010-03-06 add list context menu and edit project info (move clear stuff to after if stmt)++
                        'txtProjDesc.Clear()
                        'txtProjName.Clear()
                        'With txtProjID
                        '    .Clear()
                        '    .Focus()
                        'End With
                        'mod 2010-03-06 add list context menu and edit project info (move clear stuff to after if stmt)--
                    Else
                        MessageBox.Show("The project ID has already been used.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        With txtProjID
                            .SelectAll()
                            .Focus()
                        End With
                    End If
                    'mod 2010-03-06 add list context menu and edit project info ++
                ElseIf btnAdd.Text = "&Change" Then
                    'Update the project in the collection that was changed
                    For Each oProject In colProjects
                        If oProject.ID = SelectedItem.SubItems.Item(0).Text Then
                            With oProject
                                .ID = txtProjID.Text
                                .Name = txtProjName.Text
                                .Description = txtProjDesc.Text
                            End With
                        End If
                    Next 'oProject

                    'Update the item in the list that was changed.
                    For Each item In lsvProjects.Items
                        If item.SubItems.Item(0).Text = SelectedItem.SubItems.Item(0).Text Then
                            With item.SubItems
                                .Item(0).Text = txtProjID.Text
                                .Item(1).Text = txtProjName.Text
                                .Item(2).Text = txtProjDesc.Text
                            End With
                        End If
                    Next 'item
                    
                    btnAdd.Text = "&Add"
                End If 'btnAdd.text = "Add"/"Change"

                txtProjDesc.Clear()
                txtProjName.Clear()
                With txtProjID
                    .Clear()
                    .Focus()
                End With
                'mod 2010-03-06 add list context menu and edit project info --
            Else
                MessageBox.Show("A Project ID and Project Name must be entered.", "Blank Field(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtProjID.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oProject = Nothing
            item = Nothing
        End Try
    End Sub

    Private Sub btnStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles btnStart.Click, StartTimerToolStripMenuItem.Click, StartProjectTimerToolStripMenuItem.Click ', lsvProjects.DoubleClick

        Dim oProject As clsProject

        If lsvProjects.SelectedItems.Count > 0 Then
            'Verifies that a project was selected
            If Not SelectedItem Is Nothing Then
                'If SelectedItem hasn't been assigned, this is the 
                'first time through and we don't need to run this code.
                'Otherwise, we want to make sure the timer is stopped
                'on the previous project before assigning SelectedItem again.
                For Each oProject In colProjects
                    If oProject.IsTimerRunning Then
                        If SelectedItem.Text = oProject.ID Then
                            oProject.StopTime()
                            SelectedItem.SubItems.Item(3).Text = oProject.getTime
                            With lblCurTmrRun
                                .Text = "Timer Running For:" & vbNewLine & "None"
                                .BackColor = Color.LightGray
                            End With
                        End If
                    End If
                Next
                oProject = Nothing
            End If

            SelectedItem = lsvProjects.SelectedItems.Item(0)
            For Each oProject In colProjects
                If SelectedItem.Text = oProject.ID Then
                    'mod++ 2010-02-10 double-click pause
                    'If ReferenceEquals(sender, lsvProjects) And oProject.IsTimerRunning() Then
                    ' oProject.StopTime()
                    ' SelectedItem.SubItems.Item(3).Text = oProject.getTime
                    'Else
                    'mod-- 2010-02-10 double-click pause
                    oProject.StartTime()
                    SelectedItem.SubItems.Item(3).Text = oProject.getTime
                    With lblCurTmrRun
                        .Text = "Timer Running For:" & vbNewLine & oProject.ID & vbNewLine & oProject.Description
                        .BackColor = Color.Green
                    End With
                End If
                'End If 'mod 2010-02-10 double-click pause
            Next
            tmrDisplay.Start()
        Else
            MessageBox.Show("Please select a project before starting timer.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
CleanUP:
        oProject = Nothing
    End Sub

    Private Sub tmrDisplay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDisplay.Tick
        Dim oProject As clsProject
        If Not SelectedItem Is Nothing Then
            For Each oProject In colProjects
                If SelectedItem.Text = oProject.ID Then
                    SelectedItem.SubItems.Item(3).Text = oProject.getTime
                End If
            Next
        End If
CleanUP:
        oProject = Nothing
    End Sub

    Private Sub btnPause_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles btnPause.Click, PauseTimerToolStripMenuItem.Click, PauseProjectTimerToolStripMenuItem.Click

        Dim oProject As clsProject
        If Not SelectedItem Is Nothing Then
            For Each oProject In colProjects
                If SelectedItem.Text = oProject.ID Then
                    oProject.StopTime()
                    SelectedItem.SubItems.Item(3).Text = oProject.getTime
                    With lblCurTmrRun
                        .Text = "Timer Running For:" & vbNewLine & "None"
                        .BackColor = Color.LightGray
                    End With
                End If
            Next
            tmrDisplay.Stop()
        End If
CleanUP:
        oProject = Nothing
    End Sub

    ' MOD 2010-08-11 Add Notify (tmp remove)
    '    Private Sub frmProjectTimer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '        Me.WindowState = FormWindowState.Minimized
    '        Me.Visible = False
    '        e.Cancel = True
    '        nfiProjMain.Visible = True
    '        nfiProjMain.ShowBalloonTip(25, "Project Timer Hidden", "The program Project Timer Keeper has been hiddent to the notification bar", ToolTipIcon.Info)
    '    End Sub

    Private Sub frmProjectTimer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Project Timer Keeper v3.0"
        'BEGIN-2013.06.25
        strFilename = "TIME_REPORT_backup_" & Replace(Today.ToShortDateString(), "/", "-") & "_" & Replace(Replace(Now.ToShortTimeString(), " ", "_"), ":", "-") & ".txt"
        'END_2013.06.25
        With lsvProjects
            .Columns.Clear()
            .Columns.Add("Project ID", CInt(.Width * 0.2), HorizontalAlignment.Left)
            .Columns.Add("Project Name", CInt(.Width * 0.25), HorizontalAlignment.Left)
            .Columns.Add("Description", CInt(.Width * 0.3), HorizontalAlignment.Left)
            .Columns.Add("Project Timer", CInt(.Width * 0.2), HorizontalAlignment.Left)
            '    .Columns.Add("Timer Status", CInt(.Width * 0.04), HorizontalAlignment.Left)
            .View = View.Details
        End With
        With lblCurTmrRun
            .Text = "Timer Running For:" & vbNewLine & "None"
            .BackColor = Color.LightGray
        End With

        colProjects = New Collection
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnReset.Click, ResetTimerToolStripMenuItem.Click, ResetProjectTimerToolStripMenuItem.Click

        Dim oProject As clsProject

        'mod 2010-03-02 fix reset none selected ++
        If lsvProjects.SelectedItems.Count > 0 Then
            'mod 2010-03-02 fix reset none selected --
            For Each oProject In colProjects
                'reset only for selected prior to clicking reset button
                'do not disturb current SelectedItem
                If lsvProjects.SelectedItems.Item(0).Text = oProject.ID Then
                    If oProject.IsTimerRunning Then
                        oProject.StopTime()
                        With lblCurTmrRun
                            .Text = "Timer Running For:" & vbNewLine & "None"
                            .BackColor = Color.LightGray
                        End With
                    End If
                    oProject.ResetTime()
                    lsvProjects.SelectedItems.Item(0).SubItems.Item(3).Text = oProject.getTime
                End If
            Next

            If lsvProjects.SelectedItems.Item(0).Text = SelectedItem.Text Then
                tmrDisplay.Stop()
            End If
        End If 'mod 2010-03-02 fix reset none selected
CleanUP:
        oProject = Nothing
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim sMessage As String
        sMessage = "Project Timer Keeper v3.0" & vbNewLine
        sMessage = sMessage & "Updated: 07.05.2013" & vbNewLine
        sMessage = sMessage & "By: Jason Atcheson" & vbNewLine & vbNewLine
        sMessage = sMessage & "This program keeps a timer for each project separately." & vbNewLine
        sMessage = sMessage & "Allows for saving/loading projects, and view/save/print report (report will also auto-backup)." & vbNewLine

        sMessage = sMessage & vbNewLine & "Please direct any bugs or suggestions for improvements to: jmatch83@gmail.com"

        MessageBox.Show(sMessage, "Project Timer Keeper v3.0", MessageBoxButtons.OK, MessageBoxIcon.None)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim oProject As clsProject
        Dim result As DialogResult

        If Not colProjects Is Nothing Then
            result = dlgSave.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                Dim sProjectsToWrite(colProjects.Count - 1) As String
                For iIndex As Integer = 0 To colProjects.Count - 1
                    oProject = colProjects.Item(iIndex + 1)
                    'MOD 2010-08-09 replace , with |;| to save correctly
                    'sProjectsToWrite(iIndex) = oProject.ID & "," & oProject.Name & "," & oProject.Description '& ","
                    sProjectsToWrite(iIndex) = Replace(oProject.ID, ",", "|;|") & "," & Replace(oProject.Name, ",", "|;|") & "," & Replace(oProject.Description, ",", "|;|")
                    'MOD 2010-08-09 --
                Next

                File.WriteAllLines(dlgSave.FileName, sProjectsToWrite)
            End If
        End If

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim oProject As clsProject
        Dim item As ListViewItem
        Dim result As DialogResult
        Dim sProjectsToLoad() As String
        Dim sProjectLoaded() As String


        result = dlgOpen.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            'mod 2010-02-18 add time (fix load after save) ++
            lsvProjects.Items.Clear()
            colProjects = New Collection
            'mod 2010-02-18 add time (fix load after save) --
            sProjectsToLoad = File.ReadAllLines(dlgOpen.FileName)
            For iIndex As Integer = 0 To sProjectsToLoad.Length - 1
                sProjectLoaded = sProjectsToLoad(iIndex).Split(",")
                If sProjectLoaded.Length > 0 Then
                    'mod 2010-02-18 add time ++
                    'Dim iCount As Integer = 0
                    'For Each sProjItem As String In sProjectLoaded
                    '    iCount += 1
                    'Next
                    'If iCount = 4 Then
                    'oProject = New clsProject(sProjectLoaded(0), sProjectLoaded(1), sProjectLoaded(2), sProjectLoaded(3))
                    'Else
                    'oProject = New clsProject(sProjectLoaded(0), sProjectLoaded(1), sProjectLoaded(2), "00:00:00")
                    'mod 2010-02-18 add time --
                    'MOD 2010-08-09 Replace |;| with , for Descriptions, etc. ++
                    'oProject = New clsProject(sProjectLoaded(0), sProjectLoaded(1), sProjectLoaded(2))
                    oProject = New clsProject(Replace(sProjectLoaded(0), "|;|", ","), Replace(sProjectLoaded(1), "|;|", ","), Replace(sProjectLoaded(2), "|;|", ","))
                    'MOD 2010-08-09 --
                    'End If 'mod 2010-02-18 add time
                    colProjects.Add(oProject)
                End If
            Next
            oProject = Nothing
            If colProjects.Count > 0 Then
                For Each oProject In colProjects
                    With lsvProjects()
                        .View = View.Details
                        item = New ListViewItem(oProject.ID)
                        item.SubItems.Add(oProject.Name)
                        item.SubItems.Add(oProject.Description)
                        item.SubItems.Add(oProject.getTime)
                        .Items.Add(item)
                    End With
                Next
                oProject = Nothing
            End If
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        colProjects = Nothing
        Me.Close()
    End Sub

    'mod 2010-02-23 dblclck start/pause ++
    Private Sub lsvProjects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvProjects.DoubleClick
        Dim bPauseStart As Boolean = True 'True = call Start timer
        Dim oProject As clsProject

        For Each oProject In colProjects
            'reset only for selected prior to clicking reset button
            'do not disturb current SelectedItem
            If lsvProjects.SelectedItems.Item(0).Text = oProject.ID Then
                If oProject.IsTimerRunning Then
                    bPauseStart = False
                Else
                    bPauseStart = True
                End If
            End If
        Next

        If bPauseStart = True Then
            btnStart_Click(sender, e)
        Else
            btnPause_Click(sender, e)
        End If

        oProject = Nothing
    End Sub
    'mod 2010-02-23 dblclck start/pause --

    'mod 2010-03-02 add reset all ++
    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        Dim oProject As clsProject
        Dim oItem As ListViewItem
        Dim dlgResult As DialogResult

        dlgResult = MessageBox.Show("This will reset the time spent on all projects in current list.  Continue?", "Reset All Project Times", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

        If dlgResult = Windows.Forms.DialogResult.Yes Then
            For Each oProject In colProjects
                oProject.StopTime()
                oProject.ResetTime()
            Next

            For Each oItem In lsvProjects.Items
                oProject = colProjects.Item(lsvProjects.Items.IndexOf(oItem) + 1)

                oItem.SubItems.Item(3).Text = oProject.getTime
            Next

            tmrDisplay.Stop()
        End If
CleanUP:
        oProject = Nothing
        oItem = Nothing
    End Sub
    'mod 2010-03-02 add reset all --

    'mod 2010-03-06 add list context menu and edit project info ++
    Private Sub EditProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditProjectToolStripMenuItem.Click
        Dim oProject As clsProject

        btnPause_Click(sender, e)

        If lsvProjects.SelectedItems.Count > 0 Then
            SelectedItem = lsvProjects.SelectedItems.Item(0)
            For Each oProject In colProjects
                If oProject.ID = SelectedItem.SubItems.Item(0).Text Then
                    txtProjID.Text = SelectedItem.SubItems.Item(0).Text
                    txtProjName.Text = SelectedItem.SubItems.Item(1).Text
                    txtProjDesc.Text = SelectedItem.SubItems.Item(2).Text
                    btnAdd.Text = "&Change"
                    Exit For
                End If
            Next
        End If

        oProject = Nothing
    End Sub
    'mod 2010-03-06 add list context menu and edit project info --

    Private Sub ViewTimeReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewTimeReportToolStripMenuItem.Click
        frmTimeReport.colProjects = colProjects
        frmTimeReport.Show()
    End Sub

    'BEGIN-2013.06.25-Add Backup
    Private Sub tmrBackup_Tick(sender As Object, e As EventArgs) Handles tmrBackup.Tick, btnTest.Click
        Dim sProjectsToWrite() As String
        Dim infDir As DirectoryInfo
        Dim infFile As FileInfo()
        'Dim strFilename As String
        Dim strFilePath As String
        If Not colProjects Is Nothing Then
            strFilePath = "C:\Temp\TimeReportBackups\"

            infDir = New DirectoryInfo(strFilePath)
            If Not infDir.Exists Then
                infDir.Create()
            End If

            infFile = infDir.GetFiles("TIME_REPORT_backup*")
            If infFile.Length > 50 Then
                For Each fileInf As FileInfo In infFile
                    If InStr(fileInf.Name, strFilename) < 1 Then
                        fileInf.Delete()
                    End If
                Next
            End If


            sProjectsToWrite = BuildBackupReport()
            File.AppendAllLines(strFilePath & strFilename, sProjectsToWrite)
        End If
    End Sub

    Private Function BuildBackupReport() As String()
        ' ------------------------------------------------------------------------------------------------------------
        '|                                                                                                            |
        '|                                     Time Report for [Current Date]                                         |
        ' ------------------------------------------------------------------------------------------------------------
        '| Project ID: [Project ID1]   Project Description: [Project Descr1]  Time Spent on Project: [Time on Proj1]  |
        '| Project ID: [Project ID2]   Project Description: [Project Descr2]  Time Spent on Project: [Time on Proj2]  |
        ' ------------------------------------------------------------------------------------------------------------
        Dim iProjLen(4) As Integer
        Dim iBuffer As Integer = 3
        Dim sItem, sLines As String
        Dim sPart As String
        Dim iTotLen As Integer
        Dim iHalfTotLen As Integer
        Dim strTmpTime As String
        Dim sTotTimeDisp As String
        Dim iLBuffer As Integer
        Dim strReturn As String()
        strReturn = {"", ""}

        For Each oProject As clsProject In colProjects
            If iProjLen(0) < Len(oProject.ID) Then
                iProjLen(0) = Len(oProject.ID)
            End If
            If iProjLen(1) < Len(oProject.Name) Then
                iProjLen(1) = Len(oProject.Name)
            End If
            If iProjLen(2) < Len(oProject.Description) Then
                iProjLen(2) = Len(oProject.Description)
            End If

            'below CalculateTime populates dblTotalTime
            strTmpTime = CalculateTime(oProject.getTime)
            If iProjLen(3) < Len(strTmpTime) Then
                iProjLen(3) = Len(strTmpTime)
            End If
        Next


        For iIndex As Integer = 0 To 3
            iTotLen += iProjLen(iIndex) + iBuffer
        Next

        sItem = "Time Report for " & Today.ToShortDateString() & " Backup: " & Today.ToShortDateString() & " " & Now.ToShortTimeString()


        iHalfTotLen = ((iTotLen - sItem.Length) / 2)

        For iIndex As Integer = 1 To iHalfTotLen
            sItem = " " & sItem & " "
        Next
        'sItem = sItem.PadLeft((iTotLen / 2), " ")
        'sItem = sItem.PadRight((iTotLen / 2), " ")
        sLines = "| " & sItem & " |" & vbNewLine

        'reset the total time b/c we will calc it again in below For loop
        dblTotalTime = 0D
        For Each oProject As clsProject In colProjects
            sItem = ""
            sPart = ""

            sPart = oProject.ID
            sItem = sItem & sPart.PadRight(iProjLen(0) + iBuffer, " ")

            sPart = oProject.Name
            sItem = sItem & sPart.PadRight(iProjLen(1) + iBuffer, " ")

            sPart = oProject.Description
            sItem = sItem & sPart.PadRight(iProjLen(2) + iBuffer, " ")

            'below CalculateTime populates dblTotalTime
            sPart = CalculateTime(oProject.getTime)
            sItem = sItem & sPart.PadRight(iProjLen(3) + iBuffer, " ")

            sLines = sLines & "| " & sItem & " |" & vbNewLine
        Next

        sTotTimeDisp = "Total Time: " & dblTotalTime.ToString
        iLBuffer = (Len(sItem) - iBuffer) - Len(sTotTimeDisp)
        sTotTimeDisp = sTotTimeDisp.PadLeft(iLBuffer + Len(sTotTimeDisp))
        sTotTimeDisp = sTotTimeDisp.PadRight(iBuffer + Len(sTotTimeDisp))
        sLines = sLines & "| " & sTotTimeDisp & " |" & vbNewLine

        strReturn = Split(sLines, vbNewLine)

        Return strReturn
    End Function

    Private Function CalculateTime(ByVal strTime As String) As String
        Dim tmTime As TimeSpan
        Dim iHours, iSec As Integer
        Dim dCurTime, dMin As Double

        tmTime = TimeSpan.Parse(strTime)
        iHours = tmTime.Hours
        dMin = CDbl(tmTime.Minutes)
        iSec = tmTime.Seconds

        If iSec > 50 Then
            dMin += 1
        End If
        Select Case dMin
            Case Is > 52
                iHours += 1
                dMin = 0
            Case Is > 37
                dMin = 0.75
            Case Is > 22
                dMin = 0.5
            Case Is > 7
                dMin = 0.25
            Case Else
                dMin = 0
        End Select

        dCurTime = iHours + dMin

        dblTotalTime += dCurTime

        Return dCurTime.ToString()
    End Function
    'END-2013.06.25-Add Backup
End Class
