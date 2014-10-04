Imports MySql.Data.MySqlClient

Public Class frmEvent

    Dim picName As String
    Dim lnkPlace(5) As LinkLabel, lnkPerson(5) As LinkLabel
    Dim placeIDList As New List(Of Integer), personIDList As New List(Of Integer)
    Dim placeAllList As New List(Of Integer), personAllList As New List(Of Integer)
    Dim placeAllName As New List(Of String), personAllName As New List(Of String)

    Private Sub frmEvent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        clbPerson.Visible = False
        clbPlace.Visible = False
    End Sub

    Private Sub frmEvent_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmEvent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As MySqlCommand = Nothing
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy年MM月dd日 dddd HH:mm:ss"
        If frmMain.argEventIsNew Then
            lblPerson.Text = ""
            lblPlace.Text = ""
            enterEditMode()
        Else
            cmd = New MySqlCommand("SELECT EventTime, Content, Picture, CreateTime FROM event WHERE ID=" + Trim(frmMain.argEventID), frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                reader.Read()
                DateTimePicker1.Value = reader.GetDateTime(0)
                TextBox2.Text = reader.GetString(1)
                Try
                    If Not reader.IsDBNull(2) Then PictureBox1.Load(reader.GetString(2))
                Catch ex2 As Exception

                End Try
                TextBox1.Text = Format(reader.GetDateTime(3), "yyyy年MM月dd日 HH:mm:ss")
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
                Me.Dispose()
            Finally
                reader.Close()
            End Try
            updateTagList()
        End If
        cmd = New MySqlCommand("SELECT ID, PName FROM person", frmMain.conn)
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                personAllList.Add(reader.GetInt32(0))
                personAllName.Add(reader.GetString(1))
                clbPerson.Items.Add(reader.GetString(1))
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
            Me.Dispose()
        Finally
            reader.Close()
        End Try
        cmd = New MySqlCommand("SELECT ID, PName FROM place", frmMain.conn)
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                placeAllList.Add(reader.GetInt32(0))
                placeAllName.Add(reader.GetString(1))
                clbPlace.Items.Add(reader.GetString(1))
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
            Me.Dispose()
        Finally
            reader.Close()
        End Try
        For i = 0 To placeIDList.Count - 1
            Dim index As Integer = -1
            For j = 0 To placeAllList.Count - 1
                If placeIDList(i) = placeAllList(j) Then index = j
            Next
            If index <> -1 Then clbPlace.SetItemChecked(index, True)
        Next
        For i = 0 To personIDList.Count - 1
            Dim index As Integer = -1
            For j = 0 To personAllList.Count - 1
                If personIDList(i) = personAllList(j) Then index = j
            Next
            If index <> -1 Then clbPerson.SetItemChecked(index, True)
        Next
    End Sub

    Public Sub updateTagList()
        Dim cmd As MySqlCommand
        Dim reader As MySqlDataReader = Nothing
        placeIDList.Clear()
        personIDList.Clear()
        cmd = New MySqlCommand("SELECT PName, place.ID FROM eventplace, place WHERE PlaceID=place.ID AND EventID=" + Trim(frmMain.argEventID), frmMain.conn)
        Try
            reader = cmd.ExecuteReader
            lblPlace.Text = ""
            While reader.Read
                lblPlace.Text += reader.GetString(0) + "; "
                placeIDList.Add(reader.GetInt32(1))
            End While
            If lblPlace.Text <> "" Then lblPlace.Text = Strings.Left(lblPlace.Text, Strings.Len(lblPlace.Text) - 2)
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
            Me.Dispose()
        Finally
            reader.Close()
        End Try
        cmd = New MySqlCommand("SELECT PName, person.ID FROM eventparticipate, person WHERE PersonID=person.ID AND EventID=" + Trim(frmMain.argEventID), frmMain.conn)
        Try
            reader = cmd.ExecuteReader
            lblPerson.Text = ""
            While reader.Read
                lblPerson.Text += reader.GetString(0) + "; "
                personIDList.Add(reader.GetInt32(1))
            End While
            If lblPerson.Text <> "" Then lblPerson.Text = Strings.Left(lblPerson.Text, Strings.Len(lblPerson.Text) - 2)
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
            Me.Dispose()
        Finally
            reader.Close()
        End Try

    End Sub

    Sub updateTagList2()
        lblPerson.Text = ""
        lblPlace.Text = ""
        For i = 0 To personAllList.Count - 1
            If clbPerson.GetItemChecked(i) = True Then lblPerson.Text += personAllName(i) + "; "
        Next
        If lblPerson.Text <> "" Then lblPerson.Text = Strings.Left(lblPerson.Text, Strings.Len(lblPerson.Text) - 2)
        For i = 0 To placeAllList.Count - 1
            If clbPlace.GetItemChecked(i) = True Then lblPlace.Text += placeAllName(i) + "; "
        Next
        If lblPlace.Text <> "" Then lblPlace.Text = Strings.Left(lblPlace.Text, Strings.Len(lblPlace.Text) - 2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Sub enterEditMode()
        Button2.Text = "完成"
        TextBox2.ReadOnly = False
        Button3.Enabled = False
        DateTimePicker1.Enabled = True
        Button4.Visible = True
        Button5.Visible = True
        Timer1.Enabled = True
    End Sub

    Sub exitEditMode()
        Timer1.Enabled = False
        Button2.Text = "编辑"
        Button3.Enabled = True
        DateTimePicker1.Enabled = False
        TextBox2.ReadOnly = True
        Button4.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If Button2.Text <> "完成" Then Exit Sub
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        Try
            Dim bmp As Bitmap = Bitmap.FromFile(OpenFileDialog1.FileName)
            picName = "images/" + Format(Now, "yyyyMMddHHmmss") + ".jpg"
            bmp.Save(picName, Imaging.ImageFormat.Jpeg)
            PictureBox1.Image = bmp
        Catch ex As Exception
            MsgBox("图片错误！")
            Exit Sub
        End Try
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("真的要删除吗？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As New MySqlCommand("DELETE FROM eventparticipate WHERE EventID=" + Trim(frmMain.argEventID), frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
            cmd = New MySqlCommand("DELETE FROM eventplace WHERE EventID=" + Trim(frmMain.argEventID), frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
            cmd = New MySqlCommand("DELETE FROM event WHERE ID=" + Trim(frmMain.argEventID), frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
        End If
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "编辑" Then
            enterEditMode()
        Else
            TextBox2.Text = safeSQL(TextBox2.Text)
            If Trim(TextBox2.Text = "") Then Exit Sub
            Dim cmd As MySqlCommand = Nothing
            Dim reader As MySqlDataReader = Nothing
            If frmMain.argEventIsNew Then
                cmd = New MySqlCommand("INSERT INTO event(EventTime, Content, Picture) VALUES('" + Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") + "', '" + TextBox2.Text + "', '" + picName + "')", frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("SELECT last_insert_id()", frmMain.conn)
                Try
                    reader = cmd.ExecuteReader
                    reader.Read()
                    frmMain.argEventIsNew = False
                    frmMain.argEventID = reader.GetInt32(0)
                Catch ex As Exception
                    MessageBox.Show("读取错误：" + ex.Message)
                    Me.Dispose()
                Finally
                    reader.Close()
                End Try
            Else
                cmd = New MySqlCommand("UPDATE event SET EventTime='" + Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") + "', Content='" + TextBox2.Text + "', Picture='" + picName + "' WHERE ID=" + Trim(frmMain.argEventID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
            End If
            cmd = New MySqlCommand("DELETE FROM eventplace WHERE EventID=" + Trim(frmMain.argEventID), frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
            cmd = New MySqlCommand("DELETE FROM eventparticipate WHERE EventID=" + Trim(frmMain.argEventID), frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
            For i = 0 To placeAllList.Count - 1
                If clbPlace.GetItemChecked(i) Then
                    cmd = New MySqlCommand("INSERT INTO eventplace(PlaceID, EventID) VALUES (" + Trim(placeAllList(i)) + ", " + Trim(frmMain.argEventID) + ")", frmMain.conn)
                    Try
                        cmd.ExecuteScalar()
                    Catch ex As Exception
                        MessageBox.Show("写入错误：" + ex.Message)
                    End Try
                End If
            Next
            For i = 0 To personAllList.Count - 1
                If clbPerson.GetItemChecked(i) Then
                    cmd = New MySqlCommand("INSERT INTO eventparticipate(PersonID, EventID) VALUES (" + Trim(personAllList(i)) + ", " + Trim(frmMain.argEventID) + ")", frmMain.conn)
                    Try
                        cmd.ExecuteScalar()
                    Catch ex As Exception
                        MessageBox.Show("写入错误：" + ex.Message)
                    End Try
                End If
            Next
            exitEditMode()
        End If
    End Sub

    Function safeSQL(ByVal str As String) As String
        str = Strings.Replace(str, "'", "")
        str = Strings.Replace(str, "`", "")
        Return str
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        clbPlace.Visible = Not clbPlace.Visible
        If clbPlace.Visible = True Then clbPlace.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        clbPerson.Visible = Not clbPerson.Visible
        If clbPerson.Visible = True Then clbPerson.Focus()
    End Sub

    Private Sub clbPlace_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbPlace.Leave
        clbPlace.Visible = False
    End Sub

    Private Sub clbPerson_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbPerson.Leave
        clbPerson.Visible = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If clbPerson.Visible = True Or clbPlace.Visible = True Then updateTagList2()
    End Sub
End Class