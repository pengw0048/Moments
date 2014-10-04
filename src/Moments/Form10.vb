Imports MySql.Data.MySqlClient

Public Class frmPDetail

    Dim typeAllList As New List(Of Integer)
    Dim typeAllName As New List(Of String)
    Dim noteID As New List(Of Integer)
    Dim eventID As New List(Of Integer)
    Dim picName As String

    Private Sub frmPDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        clbTag.Visible = False
    End Sub

    Private Sub frmPDetail_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Form10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmMain.argPDIsPerson Then
            TextBox2.Visible = False
        Else
            Label2.Text = "地址："
            DateTimePicker1.Visible = False
            RadioButton1.Visible = False
            RadioButton2.Visible = False
            RadioButton3.Visible = False
        End If
        Dim cmd As New MySqlCommand("SELECT ID, TName, Des FROM " + IIf(frmMain.argPDIsPerson, "person", "place") + "type", frmMain.conn)
        Dim reader As MySqlDataReader = Nothing
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                typeAllList.Add(reader.GetInt32(0))
                typeAllName.Add(reader.GetString(1))
                clbTag.Items.Add(reader.GetString(1) + IIf(reader.GetString(2) = "", "", " - " + reader.GetString(2)))
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
            Me.Dispose()
        Finally
            reader.Close()
        End Try
        If frmMain.argPDIsNew Then
            picName = "men_main.gif"
            enterEditMode()
        Else
            If frmMain.argPDIsPerson Then
                cmd = New MySqlCommand("SELECT PName, Sex, Birthday, Potrait, CreateTime FROM person WHERE ID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    reader = cmd.ExecuteReader
                    reader.Read()
                    TextBox1.Text = reader.GetString(0)
                    Select Case reader.GetString(1)
                        Case "M"
                            RadioButton1.Checked = True
                        Case "F"
                            RadioButton2.Checked = True
                        Case Else
                            RadioButton3.Checked = True
                    End Select
                    If Not reader.IsDBNull(2) Then DateTimePicker1.Value = reader.GetDateTime(2)
                    Try
                        If Not reader.IsDBNull(3) Then PictureBox1.Load(reader.GetString(3))
                    Catch ex2 As Exception

                    End Try
                    TextBox3.Text = Format(reader.GetDateTime(4), "yyyy-MM-dd HH:mm:ss")
                Catch ex As Exception
                    MessageBox.Show("读取错误：" + ex.Message)
                    Me.Dispose()
                Finally
                    reader.Close()
                End Try
            Else
                cmd = New MySqlCommand("SELECT PName, Address, Picture, CreateTime FROM place WHERE ID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    reader = cmd.ExecuteReader
                    reader.Read()
                    TextBox1.Text = reader.GetString(0)
                    If Not reader.IsDBNull(1) Then TextBox2.Text = reader.GetString(1)
                    Try
                        If Not reader.IsDBNull(2) Then PictureBox1.Load(reader.GetString(2))
                    Catch ex2 As Exception

                    End Try
                    TextBox3.Text = Format(reader.GetDateTime(3), "yyyy-MM-dd HH:mm:ss")
                Catch ex As Exception
                    MessageBox.Show("读取错误：" + ex.Message)
                    Me.Dispose()
                Finally
                    reader.Close()
                End Try
            End If
            cmd = New MySqlCommand("SELECT TypeID FROM " + IIf(frmMain.argPDIsPerson, "person", "place") + "typify WHERE " + IIf(frmMain.argPDIsPerson, "Person", "Place") + "ID=" + Trim(frmMain.argPDID), frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                While reader.Read
                    Dim toFind As Integer = reader.GetInt32(0)
                    For i = 0 To typeAllList.Count - 1
                        If typeAllList(i) = toFind Then
                            clbTag.SetItemChecked(i, True)
                            Exit For
                        End If
                    Next
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
                Me.Dispose()
            Finally
                reader.Close()
            End Try
            updateLBNote()
            updateLBEvent()
            updateTag()
        End If
    End Sub

    Sub updateTag()
        lblTag.Text = ""
        For i = 0 To typeAllList.Count - 1
            If clbTag.GetItemChecked(i) = True Then
                lblTag.Text += typeAllName(i) + "; "
            End If
        Next
        If lblTag.Text <> "" Then lblTag.Text = Strings.Left(lblTag.Text, Strings.Len(lblTag.Text) - 2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Sub enterEditMode()
        Button3.Enabled = False
        Button2.Text = "完成"
        TextBox1.ReadOnly = False
        TextBox2.ReadOnly = False
        DateTimePicker1.Enabled = True
        Button4.Visible = True
        ListBox1.Enabled = False
        ListBox2.Enabled = False
        Button5.Enabled = False
        Timer1.Enabled = True
    End Sub

    Sub exitEditMode()
        Timer1.Enabled = False
        Button3.Enabled = True
        Button2.Text = "编辑"
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        DateTimePicker1.Enabled = False
        Button4.Visible = False
        clbTag.Visible = False
        ListBox1.Enabled = True
        ListBox2.Enabled = True
        Button5.Enabled = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        clbTag.Visible = Not clbTag.Visible
        If clbTag.Visible = True Then clbTag.Focus()
    End Sub

    Private Sub clbTag_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbTag.Leave
        clbTag.Visible = False
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        updateTag()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("真的要删除吗？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If frmMain.argPDIsPerson Then
                Dim cmd As New MySqlCommand("DELETE FROM personnote WHERE PersonID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("DELETE FROM persontypify WHERE PersonID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("DELETE FROM eventparticipate WHERE PersonID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("DELETE FROM person WHERE ID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
            Else
                Dim cmd As New MySqlCommand("DELETE FROM placenote WHERE PlaceID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("DELETE FROM placetypify WHERE PlaceID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("DELETE FROM eventplace WHERE PlaceID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("DELETE FROM place WHERE ID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
            End If
        End If
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "编辑" Then
            enterEditMode()
        Else
            TextBox1.Text = safeSQL(TextBox1.Text)
            TextBox2.Text = safeSQL(TextBox2.Text)
            If Trim(TextBox1.Text) = "" Then Exit Sub
            Dim cmd As MySqlCommand = Nothing
            Dim reader As MySqlDataReader = Nothing
            If frmMain.argPDIsNew Then
                If frmMain.argPDIsPerson Then cmd = New MySqlCommand("INSERT INTO person(PName, Sex, Birthday, Potrait) VALUES('" + TextBox1.Text + "', '" + IIf(RadioButton1.Checked, "M", IIf(RadioButton2.Checked, "F", "-")) + "', '" + Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") + "', '" + picName + "')", frmMain.conn)
                If Not frmMain.argPDIsPerson Then cmd = New MySqlCommand("INSERT INTO place(PName, Address, Picture) VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + picName + "')", frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("SELECT last_insert_id()", frmMain.conn)
                Try
                    reader = cmd.ExecuteReader
                    reader.Read()
                    frmMain.argPDIsNew = False
                    frmMain.argPDID = reader.GetInt32(0)
                Catch ex As Exception
                    MessageBox.Show("读取错误：" + ex.Message)
                    Me.Dispose()
                Finally
                    reader.Close()
                End Try
            Else
                If frmMain.argPDIsPerson Then cmd = New MySqlCommand("UPDATE person SET PName='" + TextBox1.Text + "', Sex='" + IIf(RadioButton1.Checked, "M", IIf(RadioButton2.Checked, "F", "-")) + "', Birthday='" + Format(DateTimePicker1.Value, "yyyy-MM-dd HH:mm:ss") + "', Potrait='" + picName + "' WHERE ID=" + Trim(frmMain.argPDID), frmMain.conn)
                If Not frmMain.argPDIsPerson Then cmd = New MySqlCommand("UPDATE place SET PName='" + TextBox1.Text + "', Address='" + TextBox2.Text + "', Picture='" + picName + "' WHERE ID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                If frmMain.argPDIsPerson Then cmd = New MySqlCommand("DELETE FROM persontypify WHERE PersonID=" + Trim(frmMain.argPDID), frmMain.conn)
                If Not frmMain.argPDIsPerson Then cmd = New MySqlCommand("DELETE FROM placetypify WHERE PlaceID=" + Trim(frmMain.argPDID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                For i = 0 To typeAllList.Count - 1
                    If clbTag.GetItemChecked(i) Then
                        If frmMain.argPDIsPerson Then cmd = New MySqlCommand("INSERT INTO persontypify(TypeID,PersonID) VALUES (" + Trim(typeAllList(i)) + ", " + Trim(frmMain.argPDID) + ")", frmMain.conn)
                        If Not frmMain.argPDIsPerson Then cmd = New MySqlCommand("INSERT INTO placetypify(TypeID, PlaceID) VALUES (" + Trim(typeAllList(i)) + ", " + Trim(frmMain.argPDID) + ")", frmMain.conn)
                        Try
                            cmd.ExecuteScalar()
                        Catch ex As Exception
                            MessageBox.Show("写入错误：" + ex.Message)
                        End Try
                    End If
                Next
            End If
            exitEditMode()
        End If
    End Sub

    Public Sub updateLBNote()
        ListBox1.Items.Clear()
        noteID.Clear()
        Dim cmd As New MySqlCommand("SELECT ID, Content, CreateTime FROM " + IIf(frmMain.argPDIsPerson, "person", "place") + "note WHERE " + IIf(frmMain.argPDIsPerson, "Person", "Place") + "ID=" + Trim(frmMain.argPDID), frmMain.conn)
        Dim reader As MySqlDataReader = Nothing
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                noteID.Add(reader.GetInt32(0))
                ListBox1.Items.Add(Format(reader.GetDateTime(2), "yyyy-MM-dd ") + shortText(reader.GetString(1), 50))
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader.Close()
        End Try
    End Sub

    Public Sub updateLBEvent()
        ListBox2.Items.Clear()
        eventID.Clear()
        Dim cmd As New MySqlCommand("SELECT event.ID, Content, EventTime FROM event, " + IIf(frmMain.argPDIsPerson, "eventparticipate", "eventplace") + " WHERE " + IIf(frmMain.argPDIsPerson, "eventparticipate.Person", "eventplace.Place") + "ID=" + Trim(frmMain.argPDID) + " AND " + IIf(frmMain.argPDIsPerson, "event.ID=eventparticipate.EventID", "event.ID=eventplace.EventID"), frmMain.conn)
        Dim reader As MySqlDataReader = Nothing
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                eventID.Add(reader.GetInt32(0))
                ListBox2.Items.Add(Format(reader.GetDateTime(2), "yyyy-MM-dd ") + shortText(reader.GetString(1), 50))
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
        Finally
            reader.Close()
        End Try
    End Sub

    Function safeSQL(ByVal str As String) As String
        str = Strings.Replace(str, "'", "")
        str = Strings.Replace(str, "`", "")
        Return str
    End Function

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

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        frmMain.argNoteIsNew = False
        frmMain.argNoteID = noteID(ListBox1.SelectedIndex)
        frmMain.argNoteIsPerson = frmMain.argPDIsPerson
        frmMain.argNoteName = TextBox1.Text
        frmNote.ShowDialog()
        updateLBNote()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex = -1 Then Exit Sub
        frmMain.argEventID = False
        frmMain.argEventID = eventID(ListBox2.SelectedIndex)
        frmEvent.ShowDialog()
        updateLBEvent()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        frmMain.argNoteIsNew = True
        frmMain.argNoteIsPerson = frmMain.argPDIsPerson
        frmMain.argNoteName = TextBox1.Text
        frmMain.argNoteTargetID = frmMain.argPDID
        frmNote.ShowDialog()
        updateLBNote()
    End Sub
End Class