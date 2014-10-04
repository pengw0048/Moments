Imports MySql.Data.MySqlClient

Public Class frmSettings

    Dim oldNickname As String, oldPassword As String
    Dim changed As Boolean

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName <> "" Then
            TextBox2.Text = OpenFileDialog1.FileName
            changed = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then Exit Sub
        TextBox1.Text = Strings.Replace(TextBox1.Text, "'", "")
        TextBox1.Text = Strings.Replace(TextBox1.Text, "`", "")
        If TextBox3.Text <> TextBox4.Text Then
            MsgBox("两次密码不一致！")
            Exit Sub
        End If
        If changed = True Then
            Try
                Dim bmp As Bitmap = Bitmap.FromFile(TextBox2.Text)
                bmp = New Bitmap(bmp, 100, 100)
                bmp.Save("Potrait.jpg", Imaging.ImageFormat.Jpeg)
                TextBox2.Text = "Potrait.jpg"
            Catch ex As Exception
                MsgBox("图片错误！")
                Exit Sub
            End Try
        End If
        If TextBox3.Text = "hahahahahaha~" Then
            TextBox3.Text = oldPassword
        ElseIf TextBox3.Text <> "" Then
            TextBox3.Text = MD5(TextBox3.Text, 32)
        End If
        Dim cmd As New MySqlCommand("UPDATE settings SET Nickname='" + TextBox1.Text + "', Potrait='" + TextBox2.Text + "', Password='" + TextBox3.Text + "' WHERE Nickname='" + oldNickname + "'", frmMain.conn)
        Try
            cmd.ExecuteScalar()
        Catch ex As Exception
            MessageBox.Show("写入错误：" + ex.Message)
        End Try
        frmMain.updateShowInfo()
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub frmSettings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As New MySqlCommand("SELECT Nickname, Password, Potrait FROM settings", frmMain.conn)
        Try
            reader = cmd.ExecuteReader
            reader.Read()
            oldNickname = reader.GetString(0)
            TextBox1.Text = oldNickname
            TextBox2.Text = reader.GetString(2)
            oldPassword = reader.GetString(1)
            If oldPassword <> "" Then
                TextBox3.Text = "hahahahahaha~" '表明没有更改...
                TextBox4.Text = "hahahahahaha~"
            End If
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
            Me.Dispose()
        Finally
            reader.Close()
        End Try
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
End Class