Imports System.IO
''-------------------------------------- MODIFICATION LOG -------------------------------------------''
'' DATE          DEVELOPER           DESCR                                                           ''
'' ----------    ----------------    ----------------------------------------------------------------''
'' 08/06/2010    JASON ATCHESON      Fix issue where hours would total ~60.                          ''
''                                   dMin needed to be reset in Select Case in CalculateTime function''
''                                                                                                   ''
''***************************************************************************************************''

Public Class frmTimeReport
    Public colProjects As Collection
    Private dblTotalTime As Double
    Private sTotalTime As String

    Private colControls As Collection 'stores collection of colProjCntrls collection

    Private Sub frmTimeReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim bNoProjects As Boolean = False
        Dim lblTotProjTime As New Label
        Dim txtTotProjTime As New TextBox
        Dim flpSingleProj As New FlowLayoutPanel

        If Not colProjects Is Nothing Then
            If colProjects.Count > 0 Then
                colControls = New Collection

                For Each oProject As clsProject In colProjects
                    AddControlstoFlow(oProject)
                Next
                With flpSingleProj
                    .FlowDirection = FlowDirection.LeftToRight
                    .Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
                    .AutoSize = True
                    .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                    .Padding = New System.Windows.Forms.Padding(2)
                End With
                With lblTotProjTime
                    .Text = "Total Time:"
                    .Parent = flpSingleProj
                    .AutoSize = True
                End With
                With txtTotProjTime
                    .ReadOnly = True
                    .Text = dblTotalTime.ToString & " hours"
                    .Parent = flpSingleProj
                    .Width = 50
                End With
                'BEGIN-2012.02.29 Add Total to Save
                sTotalTime = dblTotalTime.ToString
                'END-2012.02.29
                flpSingleProj.Parent = flpProjectsRpt
            Else
                bNoProjects = True
            End If
        Else
            bNoProjects = True
        End If
        If bNoProjects Then
            MsgBox("There are no projects loaded to display", MsgBoxStyle.OkOnly, "No Projects")
            Me.Close()
        End If
    End Sub

    Private Sub AddControlstoFlow(ByVal oProject As clsProject)
        Dim lblProjID, lblProjDescr, lblProjTime As New Label
        Dim txtProjID, txtProjDescr, txtProjTime As New TextBox
        Dim flpSingleProj As New FlowLayoutPanel
        Dim colProjCntrls As New Collection

        With flpProjectsRpt
            .AutoSize = True
            .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            .Padding = New System.Windows.Forms.Padding(2)
        End With
        With flpSingleProj
            .FlowDirection = FlowDirection.LeftToRight
            .Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
            .AutoSize = True
            .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            .Padding = New System.Windows.Forms.Padding(2)
        End With

        flpProjectsRpt.FlowDirection = FlowDirection.TopDown

        With lblProjID
            .Text = "Project ID:"
            .Parent = flpSingleProj
            .AutoSize = True
        End With


        With txtProjID
            .ReadOnly = True
            .Text = oProject.ID
            .Parent = flpSingleProj
            .Width = 100
        End With
        colProjCntrls.Add(txtProjID)

        With lblProjDescr
            .Text = "Project Description:"
            .Parent = flpSingleProj
            .AutoSize = True
        End With

        With txtProjDescr
            .ReadOnly = True
            .Text = oProject.Description
            .Parent = flpSingleProj
            .Width = 100
        End With
        colProjCntrls.Add(txtProjDescr)

        With lblProjTime
            .Text = "Hours:"
            .Parent = flpSingleProj
            .AutoSize = True
        End With

        With txtProjTime
            .ReadOnly = True
            .Text = CalculateTime(oProject.getTime)
            .Parent = flpSingleProj
            .Width = 50
        End With
        colProjCntrls.Add(txtProjTime)

        colControls.Add(colProjCntrls)

        flpSingleProj.Parent = flpProjectsRpt

    End Sub

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

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        colProjects = Nothing
        dblTotalTime = 0
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        'Dim oProject As clsProject
        'Dim oProjCntrl As TextBox
        'Dim colPrjCntrl As Collection
        Dim result As DialogResult
        'Dim iProjLen(3) As Integer
        'Dim iBuffer As Integer = 3
        'Dim sItem, sLines As String
        Dim sProjectsToWrite() As String

        ' ------------------------------------------------------------------------------------------------------------
        '|                                                                                                            |
        '|                                     Time Report for [Current Date]                                         |
        ' ------------------------------------------------------------------------------------------------------------
        '| Project ID: [Project ID1]   Project Description: [Project Descr1]  Time Spent on Project: [Time on Proj1]  |
        '| Project ID: [Project ID2]   Project Description: [Project Descr2]  Time Spent on Project: [Time on Proj2]  |
        ' ------------------------------------------------------------------------------------------------------------


        If Not colProjects Is Nothing Then
            dlgSave.FileName = Date.Today.ToString("yyyyMMdd") & ".txt"
            result = dlgSave.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                'For Each colPrjCntrl In colControls
                '    For iIndex As Integer = 0 To colPrjCntrl.Count - 1
                '        oProjCntrl = colPrjCntrl.Item(iIndex + 1)
                '        If iProjLen(iIndex) < oProjCntrl.TextLength Then
                '            iProjLen(iIndex) = oProjCntrl.TextLength
                '        End If
                '    Next
                'Next

                'Dim iTotLen As Integer
                'For iIndex As Integer = 0 To 2
                '    iTotLen += iProjLen(iIndex) + iBuffer
                'Next


                'sItem = "Time Report for " & Today.ToShortDateString()
                'Dim iHalfTotLen As Integer

                'iHalfTotLen = ((iTotLen - sItem.Length) / 2)

                'For iIndex As Integer = 1 To iHalfTotLen
                '    sItem = " " & sItem & " "
                'Next
                ''sItem = sItem.PadLeft((iTotLen / 2), " ")
                ''sItem = sItem.PadRight((iTotLen / 2), " ")
                'sLines = "| " & sItem & " |" & vbNewLine

                'For Each colPrjCntrl In colControls
                '    sItem = ""
                '    For iIndex As Integer = 0 To colPrjCntrl.Count - 1
                '        Dim sPart As String
                '        oProjCntrl = colPrjCntrl.Item(iIndex + 1)
                '        sPart = oProjCntrl.Text
                '        sItem = sItem & sPart.PadRight(iProjLen(iIndex) + iBuffer, " ")
                '    Next
                '    sLines = sLines & "| " & sItem & " |" & vbNewLine
                'Next

                'sProjectsToWrite = Split(sLines, vbNewLine)

                ' ''For Each oProject In colProjects
                ' ''    If oProject.ID.Length > iProjIDLen Then
                ' ''        iProjIDLen = oProject.ID.Length
                ' ''    End If
                ' ''    If oProject.Description.Length > iProjDescrLen Then
                ' ''        iProjDescrLen = oProject.Description.Length
                ' ''    End If

                ' ''Next
                ' ''Dim sProjectsToWrite(colProjects.Count - 1) As String
                ' ''For iIndex As Integer = 0 To colProjects.Count - 1
                ' ''    oProject = colProjects.Item(iIndex + 1)
                ' ''    sProjectsToWrite(iIndex) = oProject.ID & "," & oProject.Name & "," & oProject.Description '& ","
                ' ''Next
                sProjectsToWrite = BuildReport()
                File.WriteAllLines(dlgSave.FileName, sProjectsToWrite)
            End If
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim result As DialogResult
        'Dim sProjectsToWrite() As String
        'Dim pDoc As Printing.PrintDocument

        If Not colProjects Is Nothing Then
            dlgPrint.Document = prnDoc
            result = dlgPrint.ShowDialog()
            If result = Windows.Forms.DialogResult.OK Then
                prnDoc.Print()
                'sProjectsToWrite = BuildReport()
            End If
        End If

    End Sub

    Private Function BuildReport() As String()
        Dim oProjCntrl As TextBox
        Dim colPrjCntrl As Collection
        Dim iProjLen(3) As Integer
        Dim iBuffer As Integer = 3
        Dim sItem, sLines As String
        Dim sTmpRpt As String()

        For Each colPrjCntrl In colControls
            For iIndex As Integer = 0 To colPrjCntrl.Count - 1
                oProjCntrl = colPrjCntrl.Item(iIndex + 1)
                If iProjLen(iIndex) < oProjCntrl.TextLength Then
                    iProjLen(iIndex) = oProjCntrl.TextLength
                End If
            Next
        Next

        Dim iTotLen As Integer
        For iIndex As Integer = 0 To 2
            iTotLen += iProjLen(iIndex) + iBuffer
        Next


        sItem = "Time Report for " & Today.ToShortDateString()
        Dim iHalfTotLen As Integer

        iHalfTotLen = ((iTotLen - sItem.Length) / 2)

        For iIndex As Integer = 1 To iHalfTotLen
            sItem = " " & sItem & " "
        Next
        'sItem = sItem.PadLeft((iTotLen / 2), " ")
        'sItem = sItem.PadRight((iTotLen / 2), " ")
        sLines = "| " & sItem & " |" & vbNewLine

        For Each colPrjCntrl In colControls
            sItem = ""
            For iIndex As Integer = 0 To colPrjCntrl.Count - 1
                Dim sPart As String
                oProjCntrl = colPrjCntrl.Item(iIndex + 1)
                sPart = oProjCntrl.Text
                sItem = sItem & sPart.PadRight(iProjLen(iIndex) + iBuffer, " ")
            Next
            sLines = sLines & "| " & sItem & " |" & vbNewLine
        Next
        'BEGIN-2012.02.29 Add Total to Save
        Dim sTotTimeDisp As String
        Dim iLBuffer As Integer
        sTotTimeDisp = "Total Time: " & sTotalTime
        iLBuffer = (Len(sItem) - iBuffer) - Len(sTotTimeDisp)
        sTotTimeDisp = sTotTimeDisp.PadLeft(iLBuffer + Len(sTotTimeDisp))
        sTotTimeDisp = sTotTimeDisp.PadRight(iBuffer + Len(sTotTimeDisp))
        sLines = sLines & "| " & sTotTimeDisp & " |" & vbNewLine
        'END-2012.02.29

        sTmpRpt = Split(sLines, vbNewLine)

        Return sTmpRpt
    End Function

    Private Sub prnDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles prnDoc.PrintPage
        Dim printFont As New System.Drawing.Font("Courier New", 10, System.Drawing.FontStyle.Regular)
        Dim sPrint As String = ""
        For Each sLine As String In BuildReport()
            sPrint = sPrint & sLine & vbNewLine
        Next
        e.Graphics.DrawString(sPrint, printFont, Brushes.Black, 10, 10)

    End Sub

End Class