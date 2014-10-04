Imports MySql.Data.MySqlClient

Public Class frmPersonTypeEdit

    Dim newMode As Boolean
    Dim editID As Integer

    Public Sub updateView(ByVal mode As Boolean, ByVal id As Integer)
        newMode = mode
        editID = id
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        If newMode = False Then
            Dim reader As MySqlDataReader = Nothing
            Dim cmd As New MySqlCommand("SELECT ID, TName, Des FROM persontype WHERE ID=" + Trim(editID), frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                reader.Read()
                TextBox1.Text = reader.GetString(1)
                If Not IsDBNull(2) Then TextBox2.Text = reader.GetString(2)
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
                Me.Dispose()
            Finally
                reader.Close()
            End Try
            cmd = New MySqlCommand("SELECT COUNT(*) FROM persontypify WHERE TypeID=" + Trim(editID), frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                reader.Read()
                TextBox4.Text = Trim(reader.GetInt32(0))
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
                Me.Dispose()
            Finally
                reader.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Trim(safeSQL(TextBox1.Text) = "") Then
            MsgBox("名称不能为空！")
            Exit Sub
        End If
        If newMode Then
            Dim cmd As New MySqlCommand("INSERT INTO persontype(TName, Des) VALUES ('" + safeSQL(TextBox1.Text) + "','" + safeSQL(TextBox2.Text) + "')", frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
        Else
            Dim cmd As New MySqlCommand("UPDATE persontype SET TName='" + safeSQL(TextBox1.Text) + "', Des='" + safeSQL(TextBox2.Text) + "' WHERE ID=" + Trim(editID), frmMain.conn)
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

    Private Sub frmPersonTypeEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        updateView(frmPersonType.newMode, frmPersonType.editID)
    End Sub

End Class