Imports MySql.Data.MySqlClient

Public Class frmNote

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "对" + frmMain.argNoteName + "的评价"
        If frmMain.argNoteIsNew Then
            Button2.Enabled = False
            TextBox2.ReadOnly = False
            Button1.Text = "完成"
        Else
            Dim cmd As New MySqlCommand("SELECT " + IIf(frmMain.argNoteIsPerson, "Person", "Place") + "ID, Content, CreateTime FROM " + IIf(frmMain.argNoteIsPerson, "Person", "Place") + "note WHERE ID=" + Trim(frmMain.argNoteID), frmMain.conn)
            Dim reader As MySqlDataReader = Nothing
            Try
                reader = cmd.ExecuteReader
                reader.Read()
                TextBox2.Text = reader.GetString(1)
                TextBox1.Text = Format(reader.GetDateTime(2), "yyyy-MM-dd HH:mm:ss")
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
                Me.Dispose()
            Finally
                reader.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("真的要删除吗？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As New MySqlCommand("DELETE FROM " + IIf(frmMain.argNoteIsPerson, "person", "place") + "note WHERE ID=" + Trim(frmMain.argNoteID), frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
        End If
        Me.Dispose()
    End Sub

    Function safeSQL(ByVal str As String) As String
        str = Strings.Replace(str, "'", "")
        str = Strings.Replace(str, "`", "")
        Return str
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "编辑" Then
            Button1.Text = "完成"
            Button2.Enabled = False
            TextBox2.ReadOnly = False
        Else
            TextBox2.Text = safeSQL(TextBox2.Text)
            If Trim(TextBox2.Text) = "" Then Exit Sub
            Dim cmd As MySqlCommand = Nothing
            Dim reader As MySqlDataReader = Nothing
            If frmMain.argNoteIsNew Then
                cmd = New MySqlCommand("INSERT INTO " + IIf(frmMain.argNoteIsPerson, "person", "place") + "note(" + IIf(frmMain.argNoteIsPerson, "person", "place") + "ID, Content) VALUES(" + Trim(frmMain.argNoteTargetID) + ", '" + TextBox2.Text + "')", frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
                cmd = New MySqlCommand("SELECT last_insert_id()", frmMain.conn)
                Try
                    reader = cmd.ExecuteReader
                    reader.Read()
                    frmMain.argNoteIsNew = False
                    frmMain.argNoteID = reader.GetInt32(0)
                Catch ex As Exception
                    MessageBox.Show("读取错误：" + ex.Message)
                    Me.Dispose()
                Finally
                    reader.Close()
                End Try
            Else
                cmd = New MySqlCommand("UPDATE " + IIf(frmMain.argNoteIsPerson, "person", "place") + "note SET Content='" + TextBox2.Text + "' WHERE ID=" + Trim(frmMain.argNoteID), frmMain.conn)
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("写入错误：" + ex.Message)
                End Try
            End If
            Button1.Text = "编辑"
            Button2.Enabled = True
            TextBox2.ReadOnly = True
        End If
    End Sub
End Class