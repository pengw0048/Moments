Imports MySql.Data.MySqlClient

Public Class frmMain

    Dim viewMode As Integer
    Dim btnViewMode(4) As Button
    Public conn As MySqlConnection
    Dim nickname As String, potrait As String, password As String
    Dim firstDate As Date, firstDateView As Date
    Dim firstDatePos As Integer, selDatePos As Integer
    Dim loaded As Boolean
    Dim monthPicture(42) As String
    Dim monthCount(42) As Integer
    Dim monthShowStr(42, 2) As String
    Dim monthListID As New List(Of Integer), monthListName As New List(Of String)
    Dim catLabels(4) As LinkLabel
    Dim rndPersonLink(4) As LinkLabel
    Dim rndPersonPic(4) As PictureBox
    Dim rndPersonID(4) As Integer
    Dim rndPlaceLink(4) As LinkLabel
    Dim rndPlaceID(4) As Integer

    Dim catIsPerson(4) As Boolean
    Dim catID(4) As Integer

    Public argEventIsNew As Boolean
    Public argEventID As Integer
    Public argNoteIsPerson As Boolean
    Public argNoteIsNew As Boolean
    Public argNoteID As Integer, argNoteTargetID As Integer
    Public argNoteName As String
    Public argPDIsPerson As Boolean
    Public argPDID As Integer
    Public argPDIsNew As Boolean
    Public argSearchWord As String
    Public argSearchSpecial As Integer

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub updateShowInfo()
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As New MySqlCommand("SELECT Nickname, Potrait, FirstUse FROM settings", conn)
        Dim firstUse As Date
        Try
            reader = cmd.ExecuteReader
            reader.Read()
            nickname = reader.GetString(0)
            potrait = reader.GetString(1)
            firstUse = reader.GetDateTime(2)
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader.Close()
        End Try
        lblHello.Text = "你好，" + nickname + vbCrLf + "这是我们第" + Trim(DateDiff(DateInterval.Day, firstUse, Now) + 1) + "天见面"
        picPotrait.Load(potrait)
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewMode = 1
        For i = 1970 To 2050
            cbMYear.Items.Add(Trim(i))
        Next
        For i = 1 To 12
            cbMMonth.Items.Add(Trim(i))
        Next
        cbMYear.SelectedIndex = Year(Now) - 1970
        cbMMonth.SelectedIndex = Month(Now) - 1
        btnViewMode(0) = btnYear
        btnViewMode(1) = btnMonth
        btnViewMode(2) = btnDay
        btnViewMode(3) = btnTimeline
        catLabels(0) = LinkLabel1
        catLabels(1) = LinkLabel2
        catLabels(2) = LinkLabel3
        catLabels(3) = LinkLabel4
        rndPersonLink(0) = LinkLabel5
        rndPersonLink(1) = LinkLabel6
        rndPersonLink(2) = LinkLabel7
        rndPersonLink(3) = LinkLabel8
        rndPersonPic(0) = PictureBox1
        rndPersonPic(1) = PictureBox2
        rndPersonPic(2) = PictureBox3
        rndPersonPic(3) = PictureBox4
        rndPlaceLink(0) = LinkLabel9
        rndPlaceLink(1) = LinkLabel10
        rndPlaceLink(2) = LinkLabel11
        rndPlaceLink(3) = LinkLabel12
        updateMButtons()
        updateVButtons()
        btnMonth.Focus()
        picMonth.Refresh()
        Try
            conn = New MySqlConnection("server=localhost;user id=root;password=123456;database=foo;pooling=false")
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("连接数据库错误：" + ex.Message)
        End Try
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As New MySqlCommand("SELECT Nickname, Potrait, FirstUse, Password FROM settings", conn)
        Dim firstUse As Date
        Try
            reader = cmd.ExecuteReader
            reader.Read()
            nickname = reader.GetString(0)
            potrait = reader.GetString(1)
            firstUse = reader.GetDateTime(2)
            password = reader.GetString(3)
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader.Close()
        End Try
        If password = "" Then
            Me.Opacity = 100
            Me.Enabled = True
        Else
            Dim rt As String = ""
            Do
                rt = InputBox("输入密码")
                If rt = "" Then End
            Loop While MD5(rt, 32) <> password
            Me.Opacity = 100
            Me.Enabled = True
        End If
        lblHello.Text = "你好，" + nickname + vbCrLf + "这是我们第" + Trim(DateDiff(DateInterval.Day, firstUse, Now) + 1) + "天见面"
        picPotrait.Load(potrait)
        loaded = True
        updateMButtons()
        updateVButtons()
    End Sub

    Function MD5(ByVal strSource As String, ByVal Code As Int16) As String
        Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(strSource)
        Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)
        Dim ATR As String = ""
        Dim i As Integer
        Select Case Code
            Case 16      '选择16位字符的加密结果   
                For i = 4 To 11
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
            Case 32      '选择32位字符的加密结果   
                For i = 0 To 15
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
            Case Else       'Code错误时，返回全部字符串，即32位字符   
                For i = 0 To 15
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
        End Select
        Return ATR
    End Function

    Private Sub btnMPrevMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMPrevMonth.Click
        If cbMMonth.SelectedItem = "1" Then
            cbMMonth.SelectedIndex = 11
            cbMYear.SelectedIndex -= 1
        Else
            cbMMonth.SelectedIndex -= 1
        End If
        updateMButtons()
    End Sub

    Sub updateMButtons(Optional ByVal resetPos As Boolean = True)
        If loaded = False Then Exit Sub
        btnMNextMonth.Enabled = True
        btnMPrevMonth.Enabled = True
        btnMNextYear.Enabled = True
        btnMPrevYear.Enabled = True
        If cbMYear.SelectedItem = "1970" Then
            btnMPrevYear.Enabled = False
            If cbMMonth.SelectedItem = "1" Then
                btnMPrevMonth.Enabled = False
            End If
        End If
        If cbMYear.SelectedItem = "2050" Then
            btnMNextYear.Enabled = False
            If cbMMonth.SelectedItem = "12" Then
                btnMNextMonth.Enabled = False
            End If
        End If
        firstDate = New Date(Val(cbMYear.SelectedItem), Val(cbMMonth.SelectedItem), 1)
        firstDatePos = IIf(firstDate.DayOfWeek = DayOfWeek.Monday, 7, (Weekday(firstDate) + 5) Mod 7)
        firstDateView = DateAdd(DateInterval.Day, -firstDatePos, firstDate)
        If resetPos Then selDatePos = firstDatePos
        For i = 0 To 41
            monthPicture(i) = ""
            monthCount(i) = 0
            monthShowStr(i, 0) = ""
            monthShowStr(i, 1) = ""
        Next
        Dim reader As MySqlDataReader = Nothing
        '取事件数
        Dim cmd(2) As MySqlCommand
        cmd(1) = New MySqlCommand("SELECT CAST(`CreateTime` AS DATE), COUNT(*) FROM personnote WHERE CAST(`CreateTime` AS DATE) BETWEEN '" + Format(firstDateView, "yyyy-MM-dd") + "' AND '" + Format(DateAdd(DateInterval.Day, 41, firstDateView), "yyyy-MM-dd") + "' GROUP BY CAST(`CreateTime` AS DATE)", conn)
        cmd(2) = New MySqlCommand("SELECT CAST(`CreateTime` AS DATE), COUNT(*) FROM placenote WHERE CAST(`CreateTime` AS DATE) BETWEEN '" + Format(firstDateView, "yyyy-MM-dd") + "' AND '" + Format(DateAdd(DateInterval.Day, 41, firstDateView), "yyyy-MM-dd") + "' GROUP BY CAST(`CreateTime` AS DATE)", conn)
        cmd(0) = New MySqlCommand("SELECT CAST(`EventTime` AS DATE), COUNT(*) FROM `event` WHERE CAST(`EventTime` AS DATE) BETWEEN '" + Format(firstDateView, "yyyy-MM-dd") + "' AND '" + Format(DateAdd(DateInterval.Day, 41, firstDateView), "yyyy-MM-dd") + "' GROUP BY CAST(`EventTime` AS DATE)", conn)
        For i = 0 To 2
            Try
                reader = cmd(i).ExecuteReader
                While reader.Read
                    Dim tDate As Date = Convert.ToDateTime(reader.GetString(0))
                    Dim pos As Integer = DateDiff(DateInterval.Day, firstDateView, tDate)
                    monthCount(pos) += reader.GetInt32(1)
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        Next
        '取图片
        cmd(0) = New MySqlCommand("SELECT CAST(`EventTime` AS DATE), Picture FROM `event` WHERE Picture IS NOT NULL AND CAST(`EventTime` AS DATE) BETWEEN '" + Format(firstDateView, "yyyy-MM-dd") + "' AND '" + Format(DateAdd(DateInterval.Day, 41, firstDateView), "yyyy-MM-dd") + "' GROUP BY CAST(`EventTime` AS DATE) ORDER BY RAND()", conn)
        Try
            reader = cmd(0).ExecuteReader
            While reader.Read
                Dim tDate As Date = Convert.ToDateTime(reader.GetString(0))
                Dim pos As Integer = DateDiff(DateInterval.Day, firstDateView, tDate)
                monthPicture(pos) = reader.GetString(1)
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader.Close()
        End Try
        '取随机内容
        cmd(1) = New MySqlCommand("SELECT CAST(CreateTime AS DATE), Content FROM (SELECT CreateTime, Content FROM personnote WHERE CAST(`CreateTime` AS DATE) BETWEEN '" + Format(firstDateView, "yyyy-MM-dd") + "' AND '" + Format(DateAdd(DateInterval.Day, 41, firstDateView), "yyyy-MM-dd") + "'ORDER BY RAND()) AS haha GROUP BY CAST(createtime AS DATE)", conn)
        cmd(2) = New MySqlCommand("SELECT CAST(CreateTime AS DATE), Content FROM (SELECT CreateTime, Content FROM placenote WHERE CAST(`CreateTime` AS DATE) BETWEEN '" + Format(firstDateView, "yyyy-MM-dd") + "' AND '" + Format(DateAdd(DateInterval.Day, 41, firstDateView), "yyyy-MM-dd") + "'ORDER BY RAND()) AS haha GROUP BY CAST(createtime AS DATE)", conn)
        cmd(0) = New MySqlCommand("SELECT CAST(EventTime AS DATE), Content FROM (SELECT EventTime, Content FROM `event` WHERE CAST(`EventTime` AS DATE) BETWEEN '" + Format(firstDateView, "yyyy-MM-dd") + "' AND '" + Format(DateAdd(DateInterval.Day, 41, firstDateView), "yyyy-MM-dd") + "'ORDER BY RAND()) AS haha GROUP BY CAST(eventtime AS DATE)", conn)
        For i = 0 To 2
            Try
                reader = cmd(i).ExecuteReader
                While reader.Read
                    Dim tDate As Date = Convert.ToDateTime(reader.GetString(0))
                    Dim pos As Integer = DateDiff(DateInterval.Day, firstDateView, tDate)
                    Dim str As String = reader.GetString(1)
                    If monthShowStr(pos, 0) = "" Then
                        monthShowStr(pos, 0) = str
                    Else
                        monthShowStr(pos, 1) = str
                    End If
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        Next
        updatelbMonth()
        picMonth.Refresh()
        updateTags()
        updatePerson()
        updatePlace()
    End Sub

    Private Sub btnMNextMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMNextMonth.Click
        If cbMMonth.SelectedItem = "12" Then
            cbMMonth.SelectedIndex = 0
            cbMYear.SelectedIndex += 1
        Else
            cbMMonth.SelectedIndex += 1
        End If
        updateMButtons()
    End Sub

    Private Sub btnMPrevYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMPrevYear.Click
        cbMYear.SelectedIndex -= 1
        updateMButtons()
    End Sub

    Private Sub btnMNextYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMNextYear.Click
        cbMYear.SelectedIndex += 1
        updateMButtons()
    End Sub

    Private Sub cbMYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMYear.SelectedIndexChanged
        updateMButtons()
    End Sub

    Private Sub cbMMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMMonth.SelectedIndexChanged
        updateMButtons()
    End Sub

    Private Sub btnYear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYear.Click
        viewMode = 0
        updateVButtons()
    End Sub

    Sub updateVButtons()
        If loaded = False Then Exit Sub
        For i = 0 To 3
            btnViewMode(i).FlatAppearance.BorderColor = Color.Black
            btnViewMode(i).FlatAppearance.BorderSize = 1
        Next
        btnViewMode(viewMode).FlatAppearance.BorderColor = Color.Blue
        btnViewMode(viewMode).FlatAppearance.BorderSize = 2
    End Sub

    Private Sub btnMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonth.Click
        viewMode = 1
        updateVButtons()
    End Sub

    Private Sub btnDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDay.Click
        viewMode = 2
        updateVButtons()
    End Sub

    Private Sub btnTimeline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimeline.Click
        viewMode = 3
        updateVButtons()
    End Sub

    Private Sub picMonth_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMonth.MouseClick
        If e.X < 8 Or e.X > 287 Or e.Y < 30 Or e.Y > 245 Then Exit Sub
        selDatePos = ((e.Y - 30) \ 36) * 7 + ((e.X - 8) \ 40)
        updatelbMonth()
        picMonth.Refresh()
    End Sub

    Sub updatelbMonth()
        lbMonth.Enabled = True
        lbMonth.Items.Clear()
        monthListID.Clear()
        monthListName.Clear()
        Dim text() As String = Split("事件 人物备注 地点备注")
        Dim tDate As Date = DateAdd(DateInterval.Day, selDatePos, firstDateView)
        Dim reader As MySqlDataReader = Nothing
        Dim cmd(2) As MySqlCommand
        cmd(1) = New MySqlCommand("SELECT personnote.CreateTime, Content, personnote.ID, PName FROM personnote, person WHERE person.ID=personnote.PersonID AND CAST(personnote.`CreateTime` AS DATE) = '" + Format(tDate, "yyyy-MM-dd") + "' ORDER BY personnote.CreateTime", conn)
        cmd(2) = New MySqlCommand("SELECT placenote.CreateTime, Content, placenote.ID, PName FROM placenote, place WHERE place.ID=placenote.PlaceID AND CAST(placenote.`CreateTime` AS DATE) = '" + Format(tDate, "yyyy-MM-dd") + "' ORDER BY placenote.CreateTime", conn)
        cmd(0) = New MySqlCommand("SELECT EventTime, Content, ID, 'haha' FROM `event` WHERE CAST(`EventTime` AS DATE) = '" + Format(tDate, "yyyy-MM-dd") + "' ORDER BY EventTime", conn)
        For i = 0 To 2
            Try
                reader = cmd(i).ExecuteReader
                While reader.Read
                    Dim tTime As Date = reader.GetDateTime(0)
                    lbMonth.Items.Add("[" + text(i) + "]" + IIf(tTime.Hour = 0 And tTime.Minute = 0 And tTime.Second = 0, "", Format(tTime, "HH:mm:ss")) + " " + IIf(i > 0, reader.GetString(3) + ":", "") + reader.GetString(1))
                    monthListID.Add(reader.GetInt32(2))
                    monthListName.Add(reader.GetString(3))
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        Next
        If lbMonth.Items.Count = 0 Then
            lbMonth.Items.Add("(本日无事件)")
            lbMonth.Enabled = False
        End If
    End Sub

    Function shortContent(ByVal str As String) As String
        If Strings.Len(str) < 60 Then Return str
        Return Strings.Left(str, 60)
    End Function

    Private Sub picMonth_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picMonth.Paint
        If loaded = False Then Exit Sub
        'monthPicture(1) = "men_main.gif"
        Dim g As Graphics = e.Graphics
        Dim fn As New Font("Times New Roman", 10)
        Dim fb As New Font("Times New Roman", 11, FontStyle.Bold)
        Dim fw As New Font("Times New Roman", 8, FontStyle.Bold)
        Dim fs As New Font("Times New Roman", 6)
        g.Clear(Color.White)
        g.DrawLine(Pens.Gray, 8, 8, 288, 8)
        For i = 0 To 6
            g.DrawLine(Pens.Gray, 8, 30 + 36 * i, 288, 30 + 36 * i)
        Next
        For i = 0 To 7
            g.DrawLine(Pens.Gray, 8 + 40 * i, 8, 8 + 40 * i, 246)
        Next
        Dim strMonth() As String = Split("Mon Tue Wed Thu Fri Sat Sun")
        For i = 0 To 6
            g.DrawString(strMonth(i), fb, Brushes.Black, 12 + 40 * i, 10)
        Next
        g.FillRectangle(Brushes.LightSkyBlue, 9 + 40 * (selDatePos Mod 7), 31 + 36 * (selDatePos \ 7), 39, 35)
        For i = 0 To 41
            If monthPicture(i) <> "" Then
                Try
                    Dim bmp As Bitmap = Bitmap.FromFile(monthPicture(i))
                    If bmp.Height > 0 Then g.DrawImage(FadeBitmap(bmp, 125), 10 + 40 * (i Mod 7), 32 + 36 * (i \ 7), 37, 33)
                Catch ex As Exception
                End Try
            End If
            If monthCount(i) > 0 Then
                g.FillEllipse(Brushes.Red, 35 + 40 * (i Mod 7), 32 + 36 * (i \ 7), 13, 13)
                g.DrawString(IIf(monthCount(i) > 9, "9+", Trim(monthCount(i))), fw, Brushes.White, IIf(monthCount(i) > 9, 35, 37) + 40 * (i Mod 7), 32 + 36 * (i \ 7))
                If monthShowStr(i, 0) <> "" Then
                    g.DrawString(shortText(monthShowStr(i, 0), 8), fs, Brushes.DarkGray, 10 + 40 * (i Mod 7), 45 + 36 * (i \ 7))
                End If
                If monthShowStr(i, 1) <> "" Then
                    g.DrawString(shortText(monthShowStr(i, 1), 8), fs, Brushes.DarkGray, 10 + 40 * (i Mod 7), 54 + 36 * (i \ 7))
                End If
            End If
            Dim tDate As Date = DateAdd(DateInterval.Day, i - firstDatePos, firstDate)
            If Format(tDate, "MM") = Format(firstDate, "MM") Then
                g.DrawString(IIf(Format(tDate, "dd") = "01", Format(tDate, "MM/"), "") + Format(tDate, "dd"), fn, IIf(tDate.DayOfWeek = DayOfWeek.Saturday Or tDate.DayOfWeek = DayOfWeek.Sunday, Brushes.Red, Brushes.Black), 10 + 40 * (i Mod 7), 32 + 36 * (i \ 7))
            Else
                g.DrawString(IIf(i = 0 Or Format(tDate, "dd") = "01", Format(tDate, "MM/"), "") + Format(tDate, "dd"), fn, Brushes.Gray, 10 + 40 * (i Mod 7), 32 + 36 * (i \ 7))
            End If
        Next
    End Sub

    Function shortstr(ByVal str As String) As String
        If Strings.Len(str) < 5 Then Return str
        Return Strings.Left(str, 4)
    End Function

    Private Function FadeBitmap(ByRef bmp As Bitmap, ByVal OpacityPercent As Single) As Bitmap
        Dim bmp2 As New Bitmap(bmp, 37, 33)
        For i = 0 To 36
            For j = 0 To 32
                bmp2.SetPixel(i, j, Color.FromArgb(OpacityPercent, bmp2.GetPixel(i, j)))
            Next
        Next
        Return bmp2
    End Function

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        frmSettings.Show()
    End Sub

    Private Sub btnType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnType.Click
        Dim btnSender As Button = CType(sender, Button)
        Dim point As New Point(0, btnSender.Height)
        point = btnSender.PointToScreen(point)
        ContextMenuStrip1.Show(point)
    End Sub

    Private Sub mnuPersonType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPersonType.Click
        frmPersonType.ShowDialog()
    End Sub

    Private Sub mnuPlaceType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPlaceType.Click
        frmPlaceType.ShowDialog()
    End Sub

    Public Sub updateTags()
        For i = 0 To 3
            catLabels(i).Visible = True
        Next
        Dim rand As New Random
        Dim pos As Integer = 0
        Dim full As Boolean = False
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As New MySqlCommand("SELECT ID, TName FROM persontype ORDER BY RAND() LIMIT 4", conn)
        Dim reader2 As MySqlDataReader = Nothing
        Dim cmd2 As New MySqlCommand("SELECT ID, TName FROM placetype ORDER BY RAND() LIMIT 4", conn)
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                catLabels(pos).Text = shortText(reader.GetString(1), 8)
                catIsPerson(pos) = True
                catID(pos) = reader.GetInt32(0)
                pos += 1
                If pos >= 4 Then
                    pos = 0
                    full = True
                End If
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader.Close()
        End Try
        Try
            reader2 = cmd2.ExecuteReader
            While reader2.Read
                If rand.Next(3) = 1 Then
                    catLabels(pos).Text = shortText(reader2.GetString(1), 8)
                    catIsPerson(pos) = False
                    catID(pos) = reader2.GetInt32(0)
                End If
                pos += 1
                If pos >= 4 Then
                    pos = 0
                    full = True
                End If
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader2.Close()
        End Try
        If Not full Then
            For i = pos To 3
                catLabels(i).Visible = False
            Next
        End If
    End Sub

    Public Sub updatePerson()
        For i = 0 To 3
            rndPersonLink(i).Visible = True
            rndPersonPic(i).Visible = True
        Next
        Dim rand As New Random
        Dim pos As Integer = 0
        Dim full As Boolean = False
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As New MySqlCommand("SELECT ID, PName, Potrait FROM person ORDER BY RAND() LIMIT 4", conn)
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                rndPersonLink(pos).Text = shortText(reader.GetString(1), 10)
                rndPersonID(pos) = reader.GetInt32(0)
                Try
                    rndPersonPic(pos).Load(reader.GetString(2))
                Catch ex2 As Exception
                    rndPersonPic(pos).Load("men_main.gif")
                End Try
                pos += 1
                If pos >= 4 Then
                    pos = 0
                    full = True
                End If
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader.Close()
        End Try
        If Not full Then
            For i = pos To 3
                rndPersonLink(i).Visible = False
                rndPersonPic(i).Visible = False
            Next
        End If
    End Sub

    Public Sub updatePlace()
        For i = 0 To 3
            rndPlaceLink(i).Visible = True
        Next
        Dim rand As New Random
        Dim pos As Integer = 0
        Dim full As Boolean = False
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As New MySqlCommand("SELECT ID, PName FROM place ORDER BY RAND() LIMIT 4", conn)
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                rndPlaceLink(pos).Text = shortText(reader.GetString(1), 10)
                rndPlaceID(pos) = reader.GetInt32(0)
                pos += 1
                If pos >= 4 Then
                    pos = 0
                    full = True
                End If
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader.Close()
        End Try
        If Not full Then
            For i = pos To 3
                rndPlaceLink(i).Visible = False
            Next
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        updateTags()
    End Sub

    Public Function shortText(ByVal str As String, ByVal len As Integer) As String
        Dim ret As String = ""
        Dim count As Integer = 0
        For i = 1 To Strings.Len(str)
            ret += Mid(str, i, 1)
            If AscW(Mid(str, i, 1)) < 256 Then
                count += 1
            Else
                count += 2
            End If
            If (count >= len - 2 And i < Strings.Len(str) - 1) Then Return ret + ".."
        Next
        Return ret
    End Function

    Private Sub lbMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMonth.Click
        If lbMonth.SelectedIndex = -1 Then Exit Sub
        If Strings.Left(lbMonth.SelectedItem, 4) = "[事件]" Then
            argEventIsNew = False
            argEventID = monthListID(lbMonth.SelectedIndex)
            frmEvent.ShowDialog()
            updatelbMonth()
            updateMButtons(False)
            picMonth.Refresh()
        ElseIf Strings.Left(lbMonth.SelectedItem, 4) = "[人物备" Then
            argNoteIsNew = False
            argNoteID = monthListID(lbMonth.SelectedIndex)
            argNoteIsPerson = True
            argNoteName = monthListName(lbMonth.SelectedIndex)
            frmNote.ShowDialog()
            updatelbMonth()
            updateMButtons(False)
            picMonth.Refresh()
        ElseIf Strings.Left(lbMonth.SelectedItem, 4) = "[地点备" Then
            argNoteIsNew = False
            argNoteID = monthListID(lbMonth.SelectedIndex)
            argNoteIsPerson = False
            argNoteName = monthListName(lbMonth.SelectedIndex)
            frmNote.ShowDialog()
            updatelbMonth()
            updateMButtons(False)
            picMonth.Refresh()
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        argEventIsNew = True
        frmEvent.ShowDialog()
        updatelbMonth()
        updateMButtons(False)
        picMonth.Refresh()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        updatePerson()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        updatePlace()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        argPDIsPerson = True
        argPDIsNew = True
        frmPDetail.ShowDialog()
        updateMButtons(False)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        argPDIsPerson = False
        argPDIsNew = True
        frmPDetail.ShowDialog()
        updateMButtons(False)
    End Sub

    Sub handlePersonClick(ByVal num As Integer)
        argPDIsPerson = True
        argPDIsNew = False
        argPDID = rndPersonID(num)
        frmPDetail.ShowDialog()
        updateMButtons(False)
    End Sub

    Sub handlePlaceClick(ByVal num As Integer)
        argPDIsPerson = False
        argPDIsNew = False
        argPDID = rndPlaceID(num)
        frmPDetail.ShowDialog()
        updateMButtons(False)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        handlePersonClick(0)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        handlePersonClick(1)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        handlePersonClick(2)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        handlePersonClick(3)
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        handlePersonClick(0)
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        handlePersonClick(1)
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        handlePersonClick(2)
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        handlePersonClick(3)
    End Sub

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        handlePlaceClick(0)
    End Sub

    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        handlePlaceClick(1)
    End Sub

    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        handlePlaceClick(2)
    End Sub

    Private Sub LinkLabel12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        handlePlaceClick(3)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        argSearchWord = TextBox1.Text
        argSearchSpecial = -1
        frmSearch.ShowDialog()
        updateMButtons()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        argSearchSpecial = 1
        argSearchWord = "*"
        frmSearch.ShowDialog()
        updateMButtons()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        argSearchSpecial = 2
        argSearchWord = "*"
        frmSearch.ShowDialog()
        updateMButtons()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        handleTag(0)
    End Sub

    Sub handleTag(ByVal num As Integer)
        argSearchSpecial = 5
        argSearchWord = catLabels(num).Text
        frmSearch.ShowDialog()
        updateMButtons()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        handleTag(1)
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        handleTag(2)
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        handleTag(3)
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Or e.KeyChar = Chr(10) Then Button1_Click(Nothing, Nothing)
    End Sub
End Class
