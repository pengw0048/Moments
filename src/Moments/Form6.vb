Imports MySql.Data.MySqlClient

Public Class frmPlaceType

    Dim idList As New List(Of Integer)
    Dim nameList As New List(Of String)
    Public newMode As Boolean
    Public editID As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Dispose()
    End Sub

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        updateList()
    End Sub

    Sub updateList()
        ListBox1.Items.Clear()
        idList.Clear()
        nameList.Clear()
        Dim reader As MySqlDataReader = Nothing
        Dim cmd As New MySqlCommand("SELECT ID, TName, Des FROM placetype", frmMain.conn)
        Try
            reader = cmd.ExecuteReader
            While reader.Read
                idList.Add(reader.GetInt32(0))
                nameList.Add(reader.GetString(1))
                Dim Des As String = ""
                If reader.IsDBNull(2) Then
                    Des = ""
                ElseIf reader.GetString(2) <> "" Then
                    Des = " - " + reader.GetString(2)
                End If
                ListBox1.Items.Add(reader.GetString(1) + Des)
            End While
        Catch ex As Exception
            MessageBox.Show("读取错误：" + ex.Message)
            Me.Dispose()
        Finally
            reader.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        If MsgBox("真的要删除吗？", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim cmd As New MySqlCommand("DELETE FROM placetypify WHERE TypeID=" + Trim(idList(ListBox1.SelectedIndex).ToString), frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
            cmd = New MySqlCommand("DELETE FROM placetype WHERE ID=" + Trim(idList(ListBox1.SelectedIndex).ToString), frmMain.conn)
            Try
                cmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show("写入错误：" + ex.Message)
            End Try
            updateList()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        newMode = True
        frmPlaceTypeEdit.ShowDialog()
        updateList()
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        newMode = False
        editID = idList(ListBox1.SelectedIndex)
        frmPlaceTypeEdit.ShowDialog()
        updateList()
    End Sub

    Private Sub btnMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMember.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        frmMain.argSearchSpecial = 5
        frmMain.argSearchWord = nameList(ListBox1.SelectedIndex)
        frmSearch.ShowDialog()
        updateList()
    End Sub
End Class