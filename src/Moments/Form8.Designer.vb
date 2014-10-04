<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEvent))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblPlace = New System.Windows.Forms.Label()
        Me.lblPerson = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.clbPerson = New System.Windows.Forms.CheckedListBox()
        Me.clbPlace = New System.Windows.Forms.CheckedListBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(488, 66)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 21)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "关闭"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(488, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 21)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "编辑"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(488, 39)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(89, 21)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "删除"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "事件时间："
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Location = New System.Drawing.Point(82, 10)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(236, 21)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "创建时间："
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(82, 38)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(236, 21)
        Me.TextBox1.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(324, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(156, 117)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "地点："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "人物："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "事件内容："
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(14, 138)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(562, 270)
        Me.TextBox2.TabIndex = 6
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "图片文件|*.jpg;*.png;*.gif;*.jpeg;*.bmp|所有文件|*.*"
        '
        'lblPlace
        '
        Me.lblPlace.AutoSize = True
        Me.lblPlace.Location = New System.Drawing.Point(80, 66)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Size = New System.Drawing.Size(53, 12)
        Me.lblPlace.TabIndex = 16
        Me.lblPlace.Text = "lblPlace"
        '
        'lblPerson
        '
        Me.lblPerson.AutoSize = True
        Me.lblPerson.Location = New System.Drawing.Point(80, 91)
        Me.lblPerson.Name = "lblPerson"
        Me.lblPerson.Size = New System.Drawing.Size(59, 12)
        Me.lblPerson.TabIndex = 16
        Me.lblPerson.Text = "lblPerson"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(274, 62)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(44, 21)
        Me.Button4.TabIndex = 17
        Me.Button4.Text = "选择"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(274, 87)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(44, 21)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "选择"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'clbPerson
        '
        Me.clbPerson.FormattingEnabled = True
        Me.clbPerson.Location = New System.Drawing.Point(274, 112)
        Me.clbPerson.Name = "clbPerson"
        Me.clbPerson.Size = New System.Drawing.Size(299, 324)
        Me.clbPerson.TabIndex = 18
        Me.clbPerson.Visible = False
        '
        'clbPlace
        '
        Me.clbPlace.FormattingEnabled = True
        Me.clbPlace.Location = New System.Drawing.Point(274, 87)
        Me.clbPlace.Name = "clbPlace"
        Me.clbPlace.Size = New System.Drawing.Size(299, 324)
        Me.clbPlace.TabIndex = 18
        Me.clbPlace.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'frmEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(589, 448)
        Me.Controls.Add(Me.clbPlace)
        Me.Controls.Add(Me.clbPerson)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblPlace)
        Me.Controls.Add(Me.lblPerson)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEvent"
        Me.Text = "事件详情"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblPlace As System.Windows.Forms.Label
    Friend WithEvents lblPerson As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents clbPerson As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbPlace As System.Windows.Forms.CheckedListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
