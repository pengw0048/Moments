<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnYear = New System.Windows.Forms.Button()
        Me.btnMonth = New System.Windows.Forms.Button()
        Me.btnDay = New System.Windows.Forms.Button()
        Me.btnTimeline = New System.Windows.Forms.Button()
        Me.pnlMonth = New System.Windows.Forms.Panel()
        Me.picMonth = New System.Windows.Forms.PictureBox()
        Me.cbMMonth = New System.Windows.Forms.ComboBox()
        Me.cbMYear = New System.Windows.Forms.ComboBox()
        Me.btnMNextMonth = New System.Windows.Forms.Button()
        Me.btnMPrevMonth = New System.Windows.Forms.Button()
        Me.btnMNextYear = New System.Windows.Forms.Button()
        Me.btnMPrevYear = New System.Windows.Forms.Button()
        Me.lbMonth = New System.Windows.Forms.ListBox()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.lblHello = New System.Windows.Forms.Label()
        Me.picPotrait = New System.Windows.Forms.PictureBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.btnType = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPersonType = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlaceType = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel8 = New System.Windows.Forms.LinkLabel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel11 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel12 = New System.Windows.Forms.LinkLabel()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.pnlMonth.SuspendLayout()
        CType(Me.picMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPotrait, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnYear
        '
        Me.btnYear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYear.Location = New System.Drawing.Point(-34, 23)
        Me.btnYear.Name = "btnYear"
        Me.btnYear.Size = New System.Drawing.Size(22, 73)
        Me.btnYear.TabIndex = 1
        Me.btnYear.Text = "年"
        Me.btnYear.UseVisualStyleBackColor = True
        Me.btnYear.Visible = False
        '
        'btnMonth
        '
        Me.btnMonth.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.btnMonth.FlatAppearance.BorderSize = 2
        Me.btnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMonth.Location = New System.Drawing.Point(-34, 102)
        Me.btnMonth.Name = "btnMonth"
        Me.btnMonth.Size = New System.Drawing.Size(22, 73)
        Me.btnMonth.TabIndex = 0
        Me.btnMonth.Text = "月"
        Me.btnMonth.UseVisualStyleBackColor = True
        Me.btnMonth.Visible = False
        '
        'btnDay
        '
        Me.btnDay.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDay.Location = New System.Drawing.Point(-34, 181)
        Me.btnDay.Name = "btnDay"
        Me.btnDay.Size = New System.Drawing.Size(22, 73)
        Me.btnDay.TabIndex = 1
        Me.btnDay.Text = "日"
        Me.btnDay.UseVisualStyleBackColor = True
        Me.btnDay.Visible = False
        '
        'btnTimeline
        '
        Me.btnTimeline.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnTimeline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTimeline.Location = New System.Drawing.Point(-34, 260)
        Me.btnTimeline.Name = "btnTimeline"
        Me.btnTimeline.Size = New System.Drawing.Size(22, 97)
        Me.btnTimeline.TabIndex = 1
        Me.btnTimeline.Text = "时间轴"
        Me.btnTimeline.UseVisualStyleBackColor = True
        Me.btnTimeline.Visible = False
        '
        'pnlMonth
        '
        Me.pnlMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMonth.Controls.Add(Me.picMonth)
        Me.pnlMonth.Controls.Add(Me.cbMMonth)
        Me.pnlMonth.Controls.Add(Me.cbMYear)
        Me.pnlMonth.Controls.Add(Me.btnMNextMonth)
        Me.pnlMonth.Controls.Add(Me.btnMPrevMonth)
        Me.pnlMonth.Controls.Add(Me.btnMNextYear)
        Me.pnlMonth.Controls.Add(Me.btnMPrevYear)
        Me.pnlMonth.Controls.Add(Me.lbMonth)
        Me.pnlMonth.Location = New System.Drawing.Point(23, 12)
        Me.pnlMonth.Name = "pnlMonth"
        Me.pnlMonth.Size = New System.Drawing.Size(306, 478)
        Me.pnlMonth.TabIndex = 2
        '
        'picMonth
        '
        Me.picMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picMonth.Location = New System.Drawing.Point(3, 42)
        Me.picMonth.Name = "picMonth"
        Me.picMonth.Size = New System.Drawing.Size(298, 267)
        Me.picMonth.TabIndex = 3
        Me.picMonth.TabStop = False
        '
        'cbMMonth
        '
        Me.cbMMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbMMonth.FormattingEnabled = True
        Me.cbMMonth.Location = New System.Drawing.Point(162, 10)
        Me.cbMMonth.Name = "cbMMonth"
        Me.cbMMonth.Size = New System.Drawing.Size(50, 20)
        Me.cbMMonth.TabIndex = 2
        '
        'cbMYear
        '
        Me.cbMYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbMYear.FormattingEnabled = True
        Me.cbMYear.Location = New System.Drawing.Point(95, 10)
        Me.cbMYear.Name = "cbMYear"
        Me.cbMYear.Size = New System.Drawing.Size(61, 20)
        Me.cbMYear.TabIndex = 2
        '
        'btnMNextMonth
        '
        Me.btnMNextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMNextMonth.Location = New System.Drawing.Point(241, 10)
        Me.btnMNextMonth.Name = "btnMNextMonth"
        Me.btnMNextMonth.Size = New System.Drawing.Size(22, 24)
        Me.btnMNextMonth.TabIndex = 1
        Me.btnMNextMonth.Text = ">"
        Me.btnMNextMonth.UseVisualStyleBackColor = True
        '
        'btnMPrevMonth
        '
        Me.btnMPrevMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMPrevMonth.Location = New System.Drawing.Point(41, 10)
        Me.btnMPrevMonth.Name = "btnMPrevMonth"
        Me.btnMPrevMonth.Size = New System.Drawing.Size(22, 24)
        Me.btnMPrevMonth.TabIndex = 1
        Me.btnMPrevMonth.Text = "<"
        Me.btnMPrevMonth.UseVisualStyleBackColor = True
        '
        'btnMNextYear
        '
        Me.btnMNextYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMNextYear.Location = New System.Drawing.Point(269, 10)
        Me.btnMNextYear.Name = "btnMNextYear"
        Me.btnMNextYear.Size = New System.Drawing.Size(32, 24)
        Me.btnMNextYear.TabIndex = 1
        Me.btnMNextYear.Text = ">>"
        Me.btnMNextYear.UseVisualStyleBackColor = True
        '
        'btnMPrevYear
        '
        Me.btnMPrevYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMPrevYear.Location = New System.Drawing.Point(3, 10)
        Me.btnMPrevYear.Name = "btnMPrevYear"
        Me.btnMPrevYear.Size = New System.Drawing.Size(32, 24)
        Me.btnMPrevYear.TabIndex = 1
        Me.btnMPrevYear.Text = "<<"
        Me.btnMPrevYear.UseVisualStyleBackColor = True
        '
        'lbMonth
        '
        Me.lbMonth.FormattingEnabled = True
        Me.lbMonth.ItemHeight = 12
        Me.lbMonth.Location = New System.Drawing.Point(3, 309)
        Me.lbMonth.Name = "lbMonth"
        Me.lbMonth.Size = New System.Drawing.Size(298, 160)
        Me.lbMonth.TabIndex = 0
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(373, 19)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(67, 21)
        Me.btnSettings.TabIndex = 3
        Me.btnSettings.Text = "设置"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'lblHello
        '
        Me.lblHello.AutoSize = True
        Me.lblHello.Location = New System.Drawing.Point(455, 23)
        Me.lblHello.Name = "lblHello"
        Me.lblHello.Size = New System.Drawing.Size(41, 12)
        Me.lblHello.TabIndex = 4
        Me.lblHello.Text = "Label1"
        '
        'picPotrait
        '
        Me.picPotrait.Location = New System.Drawing.Point(640, 12)
        Me.picPotrait.Name = "picPotrait"
        Me.picPotrait.Size = New System.Drawing.Size(46, 44)
        Me.picPotrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPotrait.TabIndex = 5
        Me.picPotrait.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(705, 500)
        Me.ShapeContainer1.TabIndex = 6
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 360
        Me.LineShape1.X2 = 686
        Me.LineShape1.Y1 = 57
        Me.LineShape1.Y2 = 57
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(360, 74)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(234, 21)
        Me.TextBox1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(602, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 21)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "搜索一切"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "常用分类"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("宋体", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(411, 107)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(38, 11)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "位置一"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("宋体", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(458, 107)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(38, 11)
        Me.LinkLabel2.TabIndex = 10
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "位置二"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("宋体", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LinkLabel3.Location = New System.Drawing.Point(505, 107)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(38, 11)
        Me.LinkLabel3.TabIndex = 10
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "位置三"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Font = New System.Drawing.Font("宋体", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LinkLabel4.Location = New System.Drawing.Point(552, 107)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(38, 11)
        Me.LinkLabel4.TabIndex = 10
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "位置四"
        '
        'btnType
        '
        Me.btnType.ContextMenuStrip = Me.ContextMenuStrip1
        Me.btnType.Location = New System.Drawing.Point(620, 103)
        Me.btnType.Name = "btnType"
        Me.btnType.Size = New System.Drawing.Size(67, 21)
        Me.btnType.TabIndex = 3
        Me.btnType.Text = "管理分类"
        Me.btnType.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPersonType, Me.mnuPlaceType})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(149, 48)
        '
        'mnuPersonType
        '
        Me.mnuPersonType.Name = "mnuPersonType"
        Me.mnuPersonType.Size = New System.Drawing.Size(148, 22)
        Me.mnuPersonType.Text = "管理人物分类"
        '
        'mnuPlaceType
        '
        Me.mnuPlaceType.Name = "mnuPlaceType"
        Me.mnuPlaceType.Size = New System.Drawing.Size(148, 22)
        Me.mnuPlaceType.Text = "管理地点分类"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(360, 150)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(324, 31)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "添加事件"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(600, 103)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(21, 21)
        Me.Button3.TabIndex = 13
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(358, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "今天有没有想他们"
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(360, 237)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(446, 237)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Location = New System.Drawing.Point(532, 237)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Location = New System.Drawing.Point(618, 237)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Location = New System.Drawing.Point(360, 310)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel5.TabIndex = 16
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "名字一"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.Location = New System.Drawing.Point(444, 310)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel6.TabIndex = 16
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "名字二"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.Location = New System.Drawing.Point(530, 310)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel7.TabIndex = 16
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "名字三"
        '
        'LinkLabel8
        '
        Me.LinkLabel8.AutoSize = True
        Me.LinkLabel8.Location = New System.Drawing.Point(616, 310)
        Me.LinkLabel8.Name = "LinkLabel8"
        Me.LinkLabel8.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel8.TabIndex = 16
        Me.LinkLabel8.TabStop = True
        Me.LinkLabel8.Text = "名字四"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(574, 205)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(67, 21)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "所有人物"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(554, 205)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(21, 21)
        Me.Button5.TabIndex = 13
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(358, 351)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "常去地点"
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(554, 347)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(21, 21)
        Me.Button6.TabIndex = 13
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(574, 347)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(67, 21)
        Me.Button7.TabIndex = 3
        Me.Button7.Text = "所有地点"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'LinkLabel9
        '
        Me.LinkLabel9.AutoSize = True
        Me.LinkLabel9.Location = New System.Drawing.Point(360, 384)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel9.TabIndex = 16
        Me.LinkLabel9.TabStop = True
        Me.LinkLabel9.Text = "名字一"
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = True
        Me.LinkLabel10.Location = New System.Drawing.Point(444, 384)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel10.TabIndex = 16
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "名字二"
        '
        'LinkLabel11
        '
        Me.LinkLabel11.AutoSize = True
        Me.LinkLabel11.Location = New System.Drawing.Point(530, 384)
        Me.LinkLabel11.Name = "LinkLabel11"
        Me.LinkLabel11.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel11.TabIndex = 16
        Me.LinkLabel11.TabStop = True
        Me.LinkLabel11.Text = "名字三"
        '
        'LinkLabel12
        '
        Me.LinkLabel12.AutoSize = True
        Me.LinkLabel12.Location = New System.Drawing.Point(616, 384)
        Me.LinkLabel12.Name = "LinkLabel12"
        Me.LinkLabel12.Size = New System.Drawing.Size(41, 12)
        Me.LinkLabel12.TabIndex = 16
        Me.LinkLabel12.TabStop = True
        Me.LinkLabel12.Text = "名字四"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(640, 205)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(43, 21)
        Me.Button8.TabIndex = 17
        Me.Button8.Text = "添加"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(640, 347)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(43, 21)
        Me.Button9.TabIndex = 17
        Me.Button9.Text = "添加"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(705, 500)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.LinkLabel12)
        Me.Controls.Add(Me.LinkLabel9)
        Me.Controls.Add(Me.LinkLabel10)
        Me.Controls.Add(Me.LinkLabel11)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.LinkLabel8)
        Me.Controls.Add(Me.LinkLabel7)
        Me.Controls.Add(Me.LinkLabel6)
        Me.Controls.Add(Me.LinkLabel5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnType)
        Me.Controls.Add(Me.LinkLabel4)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.picPotrait)
        Me.Controls.Add(Me.lblHello)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.pnlMonth)
        Me.Controls.Add(Me.btnTimeline)
        Me.Controls.Add(Me.btnDay)
        Me.Controls.Add(Me.btnMonth)
        Me.Controls.Add(Me.btnYear)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Enabled = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Opacity = 0.0R
        Me.Text = "Moments"
        Me.pnlMonth.ResumeLayout(False)
        CType(Me.picMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPotrait, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnYear As System.Windows.Forms.Button
    Friend WithEvents btnMonth As System.Windows.Forms.Button
    Friend WithEvents btnDay As System.Windows.Forms.Button
    Friend WithEvents btnTimeline As System.Windows.Forms.Button
    Friend WithEvents pnlMonth As System.Windows.Forms.Panel
    Friend WithEvents lbMonth As System.Windows.Forms.ListBox
    Friend WithEvents btnMPrevYear As System.Windows.Forms.Button
    Friend WithEvents btnMPrevMonth As System.Windows.Forms.Button
    Friend WithEvents cbMYear As System.Windows.Forms.ComboBox
    Friend WithEvents cbMMonth As System.Windows.Forms.ComboBox
    Friend WithEvents btnMNextMonth As System.Windows.Forms.Button
    Friend WithEvents btnMNextYear As System.Windows.Forms.Button
    Friend WithEvents picMonth As System.Windows.Forms.PictureBox
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents lblHello As System.Windows.Forms.Label
    Friend WithEvents picPotrait As System.Windows.Forms.PictureBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents btnType As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuPersonType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlaceType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel7 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel8 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents LinkLabel9 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel10 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel11 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel12 As System.Windows.Forms.LinkLabel
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button

End Class
