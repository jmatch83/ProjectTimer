<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjectTimer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjectTimer))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtProjDesc = New System.Windows.Forms.TextBox()
        Me.txtProjName = New System.Windows.Forms.TextBox()
        Me.txtProjID = New System.Windows.Forms.TextBox()
        Me.lblProjDesc = New System.Windows.Forms.Label()
        Me.lblProjName = New System.Windows.Forms.Label()
        Me.lblProjID = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lsvProjects = New System.Windows.Forms.ListView()
        Me.colProjID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProjName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProjDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProjTimer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmnProjList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StartProjectTimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PauseProjectTimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetProjectTimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tmrDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartTimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PauseTimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetTimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewTimeReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.lblCurTmrRun = New System.Windows.Forms.Label()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.nfiProjMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tmrBackup = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.cmnProjList.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtProjDesc)
        Me.Panel1.Controls.Add(Me.txtProjName)
        Me.Panel1.Controls.Add(Me.txtProjID)
        Me.Panel1.Controls.Add(Me.lblProjDesc)
        Me.Panel1.Controls.Add(Me.lblProjName)
        Me.Panel1.Controls.Add(Me.lblProjID)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 337)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(658, 112)
        Me.Panel1.TabIndex = 0
        '
        'txtProjDesc
        '
        Me.txtProjDesc.Location = New System.Drawing.Point(264, 52)
        Me.txtProjDesc.Name = "txtProjDesc"
        Me.txtProjDesc.Size = New System.Drawing.Size(100, 20)
        Me.txtProjDesc.TabIndex = 6
        '
        'txtProjName
        '
        Me.txtProjName.Location = New System.Drawing.Point(147, 52)
        Me.txtProjName.Name = "txtProjName"
        Me.txtProjName.Size = New System.Drawing.Size(100, 20)
        Me.txtProjName.TabIndex = 5
        '
        'txtProjID
        '
        Me.txtProjID.Location = New System.Drawing.Point(29, 52)
        Me.txtProjID.Name = "txtProjID"
        Me.txtProjID.Size = New System.Drawing.Size(100, 20)
        Me.txtProjID.TabIndex = 4
        '
        'lblProjDesc
        '
        Me.lblProjDesc.AutoSize = True
        Me.lblProjDesc.Location = New System.Drawing.Point(261, 33)
        Me.lblProjDesc.Name = "lblProjDesc"
        Me.lblProjDesc.Size = New System.Drawing.Size(110, 15)
        Me.lblProjDesc.TabIndex = 3
        Me.lblProjDesc.Text = "Project Description"
        '
        'lblProjName
        '
        Me.lblProjName.AutoSize = True
        Me.lblProjName.Location = New System.Drawing.Point(144, 33)
        Me.lblProjName.Name = "lblProjName"
        Me.lblProjName.Size = New System.Drawing.Size(82, 15)
        Me.lblProjName.TabIndex = 2
        Me.lblProjName.Text = "Project Name"
        '
        'lblProjID
        '
        Me.lblProjID.AutoSize = True
        Me.lblProjID.Location = New System.Drawing.Point(26, 33)
        Me.lblProjID.Name = "lblProjID"
        Me.lblProjID.Size = New System.Drawing.Size(60, 15)
        Me.lblProjID.TabIndex = 1
        Me.lblProjID.Text = "Project ID"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(444, 49)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lsvProjects
        '
        Me.lsvProjects.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colProjID, Me.colProjName, Me.colProjDesc, Me.colProjTimer, Me.colStatus})
        Me.lsvProjects.ContextMenuStrip = Me.cmnProjList
        Me.lsvProjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProjects.FullRowSelect = True
        Me.lsvProjects.HideSelection = False
        Me.lsvProjects.Location = New System.Drawing.Point(0, 0)
        Me.lsvProjects.MultiSelect = False
        Me.lsvProjects.Name = "lsvProjects"
        Me.lsvProjects.Size = New System.Drawing.Size(500, 308)
        Me.lsvProjects.TabIndex = 1
        Me.lsvProjects.UseCompatibleStateImageBehavior = False
        Me.lsvProjects.View = System.Windows.Forms.View.Details
        '
        'colProjID
        '
        Me.colProjID.Text = "Project ID"
        Me.colProjID.Width = 77
        '
        'colProjName
        '
        Me.colProjName.Text = "Project Name"
        Me.colProjName.Width = 83
        '
        'colProjDesc
        '
        Me.colProjDesc.Text = "Description"
        Me.colProjDesc.Width = 117
        '
        'colProjTimer
        '
        Me.colProjTimer.Text = "Project Timer"
        Me.colProjTimer.Width = 92
        '
        'colStatus
        '
        Me.colStatus.Text = "Timer Status"
        Me.colStatus.Width = 74
        '
        'cmnProjList
        '
        Me.cmnProjList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartProjectTimerToolStripMenuItem, Me.PauseProjectTimerToolStripMenuItem, Me.ResetProjectTimerToolStripMenuItem, Me.ToolStripMenuItem2, Me.EditProjectToolStripMenuItem})
        Me.cmnProjList.Name = "cmnProjList"
        Me.cmnProjList.Size = New System.Drawing.Size(199, 106)
        '
        'StartProjectTimerToolStripMenuItem
        '
        Me.StartProjectTimerToolStripMenuItem.Name = "StartProjectTimerToolStripMenuItem"
        Me.StartProjectTimerToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.StartProjectTimerToolStripMenuItem.Text = "&Start Project Timer"
        '
        'PauseProjectTimerToolStripMenuItem
        '
        Me.PauseProjectTimerToolStripMenuItem.Name = "PauseProjectTimerToolStripMenuItem"
        Me.PauseProjectTimerToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.PauseProjectTimerToolStripMenuItem.Text = "&Pause Project Timer"
        '
        'ResetProjectTimerToolStripMenuItem
        '
        Me.ResetProjectTimerToolStripMenuItem.Name = "ResetProjectTimerToolStripMenuItem"
        Me.ResetProjectTimerToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.ResetProjectTimerToolStripMenuItem.Text = "&Reset Project Timer"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(195, 6)
        '
        'EditProjectToolStripMenuItem
        '
        Me.EditProjectToolStripMenuItem.Name = "EditProjectToolStripMenuItem"
        Me.EditProjectToolStripMenuItem.Size = New System.Drawing.Size(198, 24)
        Me.EditProjectToolStripMenuItem.Text = "&Edit Project"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(28, 110)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 2
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnPause
        '
        Me.btnPause.Location = New System.Drawing.Point(28, 70)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(75, 23)
        Me.btnPause.TabIndex = 1
        Me.btnPause.Text = "&Pause"
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(28, 31)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "&Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tmrDisplay
        '
        Me.tmrDisplay.Interval = 1000
        '
        'pnlMenu
        '
        Me.pnlMenu.Controls.Add(Me.MenuStrip1)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(658, 29)
        Me.pnlMenu.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ProjectToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(658, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.ToolStripMenuItem1, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(41, 23)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(112, 24)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(112, 24)
        Me.SaveToolStripMenuItem.Text = "&Save"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(109, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(112, 24)
        Me.CloseToolStripMenuItem.Text = "&Close"
        '
        'ProjectToolStripMenuItem
        '
        Me.ProjectToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartTimerToolStripMenuItem, Me.PauseTimerToolStripMenuItem, Me.ResetTimerToolStripMenuItem, Me.ToolStripMenuItem3, Me.ViewTimeReportToolStripMenuItem})
        Me.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem"
        Me.ProjectToolStripMenuItem.Size = New System.Drawing.Size(63, 23)
        Me.ProjectToolStripMenuItem.Text = "&Project"
        '
        'StartTimerToolStripMenuItem
        '
        Me.StartTimerToolStripMenuItem.Name = "StartTimerToolStripMenuItem"
        Me.StartTimerToolStripMenuItem.Size = New System.Drawing.Size(185, 24)
        Me.StartTimerToolStripMenuItem.Text = "&Start Timer"
        '
        'PauseTimerToolStripMenuItem
        '
        Me.PauseTimerToolStripMenuItem.Name = "PauseTimerToolStripMenuItem"
        Me.PauseTimerToolStripMenuItem.Size = New System.Drawing.Size(185, 24)
        Me.PauseTimerToolStripMenuItem.Text = "&Pause Timer"
        '
        'ResetTimerToolStripMenuItem
        '
        Me.ResetTimerToolStripMenuItem.Name = "ResetTimerToolStripMenuItem"
        Me.ResetTimerToolStripMenuItem.Size = New System.Drawing.Size(185, 24)
        Me.ResetTimerToolStripMenuItem.Text = "&Reset Timer"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(182, 6)
        '
        'ViewTimeReportToolStripMenuItem
        '
        Me.ViewTimeReportToolStripMenuItem.Name = "ViewTimeReportToolStripMenuItem"
        Me.ViewTimeReportToolStripMenuItem.Size = New System.Drawing.Size(185, 24)
        Me.ViewTimeReportToolStripMenuItem.Text = "&View Time Report"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(49, 23)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 24)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "PTK"
        Me.dlgSave.Filter = "Project Timer Keeper Files|*.PTK"
        '
        'dlgOpen
        '
        Me.dlgOpen.DefaultExt = "PTK"
        Me.dlgOpen.Filter = "Project Timer Keeper Files|*.PTK"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 29)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.lsvProjects)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnTest)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblCurTmrRun)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnResetAll)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnReset)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnStart)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnPause)
        Me.SplitContainer2.Size = New System.Drawing.Size(658, 308)
        Me.SplitContainer2.SplitterDistance = 500
        Me.SplitContainer2.TabIndex = 3
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(28, 258)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(83, 23)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "TestBackup"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'lblCurTmrRun
        '
        Me.lblCurTmrRun.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCurTmrRun.Location = New System.Drawing.Point(10, 187)
        Me.lblCurTmrRun.Name = "lblCurTmrRun"
        Me.lblCurTmrRun.Size = New System.Drawing.Size(115, 57)
        Me.lblCurTmrRun.TabIndex = 4
        Me.lblCurTmrRun.Text = "Timer Running For:"
        '
        'btnResetAll
        '
        Me.btnResetAll.Location = New System.Drawing.Point(28, 150)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(75, 23)
        Me.btnResetAll.TabIndex = 3
        Me.btnResetAll.Text = "R&eset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'nfiProjMain
        '
        Me.nfiProjMain.Text = "NotifyIcon1"
        Me.nfiProjMain.Visible = True
        '
        'tmrBackup
        '
        Me.tmrBackup.Enabled = True
        Me.tmrBackup.Interval = 600000
        '
        'frmProjectTimer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 449)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProjectTimer"
        Me.Text = "Project Timer Keeper"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.cmnProjList.ResumeLayout(False)
        Me.pnlMenu.ResumeLayout(False)
        Me.pnlMenu.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtProjDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtProjName As System.Windows.Forms.TextBox
    Friend WithEvents txtProjID As System.Windows.Forms.TextBox
    Friend WithEvents lblProjDesc As System.Windows.Forms.Label
    Friend WithEvents lblProjName As System.Windows.Forms.Label
    Friend WithEvents lblProjID As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lsvProjects As System.Windows.Forms.ListView
    Friend WithEvents colProjID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProjName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProjDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProjTimer As System.Windows.Forms.ColumnHeader
    Friend WithEvents tmrDisplay As System.Windows.Forms.Timer
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartTimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PauseTimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetTimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents cmnProjList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartProjectTimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PauseProjectTimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetProjectTimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblCurTmrRun As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewTimeReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nfiProjMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents tmrBackup As System.Windows.Forms.Timer
    Friend WithEvents btnTest As System.Windows.Forms.Button

End Class
