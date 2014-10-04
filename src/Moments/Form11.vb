Imports MySql.Data.MySqlClient

Public Class frmSearch

    Dim timeList As New List(Of Date)
    Dim typeList As New List(Of Integer), idList As New List(Of Integer), sortList As New List(Of Integer)
    Dim strList As New List(Of String), extNameList As New List(Of String)
    Dim hasSearched As Boolean
    Dim checkState(6) As Boolean

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub

    Private Sub Form11_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If frmMain.argSearchSpecial >= 0 Then
            CheckedListBox1.SetItemChecked(frmMain.argSearchSpecial, True)
        Else
            For i = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemChecked(i, True)
            Next
        End If
        For i = 0 To 5
            checkState(i) = CheckedListBox1.GetItemChecked(i)
        Next
        TextBox1.Text = frmMain.argSearchWord
        doSearch()
    End Sub

    Sub doSearch()
        TextBox1.Text = safeSQL(TextBox1.Text)
        If Trim(TextBox1.Text) = "" Then Exit Sub
        Dim startTime As Integer = Environment.TickCount()
        ListBox1.Items.Clear()
        timeList.Clear()
        typeList.Clear()
        idList.Clear()
        strList.Clear()
        sortList.Clear()
        extNameList.Clear()
        Dim count(6) As Integer
        Dim cmd As MySqlCommand = Nothing
        Dim reader As MySqlDataReader = Nothing
        If CheckedListBox1.GetItemChecked(0) Then
            cmd = New MySqlCommand("SELECT ID, EventTime, Content FROM `event` WHERE Content LIKE '%" + TextBox1.Text + "%' ORDER BY EventTime DESC", frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                While reader.Read
                    idList.Add(reader.GetInt32(0))
                    timeList.Add(reader.GetDateTime(1))
                    typeList.Add(0)
                    extNameList.Add("")
                    count(0) += 1
                    strList.Add("[事件] " + Format(reader.GetDateTime(1), "yyyy-MM-dd ") + shortText(reader.GetString(2), 60))
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        End If
        If CheckedListBox1.GetItemChecked(1) Then
            cmd = New MySqlCommand("SELECT ID, CreateTime, PName FROM person WHERE PName LIKE '%" + TextBox1.Text + "%' ORDER BY CreateTime DESC", frmMain.conn)
            If frmMain.argSearchWord = "*" Then cmd = New MySqlCommand("SELECT ID, CreateTime, PName FROM person ORDER BY CreateTime DESC", frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                While reader.Read
                    idList.Add(reader.GetInt32(0))
                    timeList.Add(reader.GetDateTime(1))
                    typeList.Add(1)
                    extNameList.Add("")
                    count(1) += 1
                    strList.Add("[人物] " + shortText(reader.GetString(2), 60))
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        End If
        If CheckedListBox1.GetItemChecked(2) Then
            cmd = New MySqlCommand("SELECT ID, CreateTime, PName FROM place WHERE PName LIKE '%" + TextBox1.Text + "%' ORDER BY CreateTime DESC", frmMain.conn)
            If frmMain.argSearchWord = "*" Then cmd = New MySqlCommand("SELECT ID, CreateTime, PName FROM place ORDER BY CreateTime DESC", frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                While reader.Read
                    idList.Add(reader.GetInt32(0))
                    timeList.Add(reader.GetDateTime(1))
                    typeList.Add(2)
                    extNameList.Add("")
                    count(2) += 1
                    strList.Add("[地点] " + shortText(reader.GetString(2), 60))
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        End If
        If CheckedListBox1.GetItemChecked(3) Then
            cmd = New MySqlCommand("SELECT personnote.ID, personnote.CreateTime, Content, PName FROM person, personnote WHERE personnote.PersonID=person.ID AND Content LIKE '%" + TextBox1.Text + "%' ORDER BY personnote.CreateTime DESC", frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                While reader.Read
                    idList.Add(reader.GetInt32(0))
                    timeList.Add(reader.GetDateTime(1))
                    typeList.Add(3)
                    count(3) += 1
                    strList.Add("[人物备注] " + shortText(reader.GetString(2), 60))
                    extNameList.Add(reader.GetString(3))
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        End If
        If CheckedListBox1.GetItemChecked(4) Then
            cmd = New MySqlCommand("SELECT place.ID, place.CreateTime, Content, PName FROM place, placenote WHERE placenote.PlaceID=place.ID AND Content LIKE '%" + TextBox1.Text + "%' ORDER BY placenote.CreateTime DESC", frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                While reader.Read
                    idList.Add(reader.GetInt32(0))
                    timeList.Add(reader.GetDateTime(1))
                    typeList.Add(4)
                    count(4) += 1
                    strList.Add("[地点备注] " + shortText(reader.GetString(2), 60))
                    extNameList.Add(reader.GetString(3))
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        End If
        If CheckedListBox1.GetItemChecked(5) Then
            cmd = New MySqlCommand("SELECT PName, person.ID, persontype.TName, persontypify.CreateTime FROM person, persontype, persontypify WHERE person.id=persontypify.PersonID AND persontypify.TypeID=persontype.ID AND persontype.TName LIKE '%" + TextBox1.Text + "%' ORDER BY persontypify.CreateTime DESC", frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                While reader.Read
                    idList.Add(reader.GetInt32(1))
                    timeList.Add(reader.GetDateTime(3))
                    typeList.Add(5)
                    extNameList.Add("")
                    count(5) += 1
                    strList.Add("[人物][标签：" + shortText(reader.GetString(2), 10) + "] " + shortText(reader.GetString(0), 60))
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
            cmd = New MySqlCommand("SELECT PName, place.ID, placetype.TName, placetypify.CreateTime FROM place, placetype, placetypify WHERE place.id=placetypify.PlaceID AND placetypify.TypeID=placetype.ID AND placetype.TName LIKE '%" + TextBox1.Text + "%' ORDER BY placetypify.CreateTime DESC", frmMain.conn)
            Try
                reader = cmd.ExecuteReader
                While reader.Read
                    idList.Add(reader.GetInt32(1))
                    timeList.Add(reader.GetDateTime(3))
                    typeList.Add(6)
                    extNameList.Add("")
                    count(5) += 1
                    strList.Add("[地点][标签：" + shortText(reader.GetString(2), 10) + "] " + shortText(reader.GetString(0), 60))
                End While
            Catch ex As Exception
                MessageBox.Show("读取错误：" + ex.Message)
            Finally
                reader.Close()
            End Try
        End If
        For i = 0 To idList.Count - 1
            sortList.Add(i)
        Next
        sortList.Sort(AddressOf cmp)
        For i = 0 To idList.Count - 1
            ListBox1.Items.Add(strList(sortList(i)))
        Next
        Dim total As Integer = 0
        For i = 0 To 5
            CheckedListBox1.Items(i) = Split(CheckedListBox1.Items(i))(0) + " (" + Trim(count(i)) + ")"
            total += count(i)
        Next
        Label2.Text = "找到" + Trim(total) + "个结果，用时" + Trim((Environment.TickCount - startTime) / 1000.0) + "秒"
        hasSearched = True
    End Sub

    Private Function cmp(ByVal x As Integer, ByVal y As Integer) As Integer
        Return timeList(y).CompareTo(timeList(x))
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        doSearch()
    End Sub

    Function safeSQL(ByVal str As String) As String
        str = Strings.Replace(str, "'", "")
        str = Strings.Replace(str, "`", "")
        str = Strings.Replace(str, "%", "")
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Not hasSearched Then Exit Sub
        For i = 0 To 5
            If CheckedListBox1.GetItemChecked(i) <> checkState(i) Then
                For j = 0 To 5
                    checkState(i) = CheckedListBox1.GetItemChecked(i)
                Next
                doSearch()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        Dim index As Integer = sortList(ListBox1.SelectedIndex)
        Select Case typeList(index)
            Case 0
                frmMain.argEventID = idList(index)
                frmMain.argEventIsNew = False
                frmEvent.ShowDialog()
            Case 1, 5
                frmMain.argPDID = idList(index)
                frmMain.argPDIsNew = False
                frmMain.argPDIsPerson = True
                frmPDetail.ShowDialog()
            Case 2, 6
                frmMain.argPDID = idList(index)
                frmMain.argPDIsNew = False
                frmMain.argPDIsPerson = False
                frmPDetail.ShowDialog()
            Case 3
                frmMain.argNoteID = idList(index)
                frmMain.argNoteIsNew = False
                frmMain.argNoteIsPerson = True
                frmMain.argNoteName = extNameList(index)
                frmNote.ShowDialog()
            Case 4
                frmMain.argNoteID = idList(index)
                frmMain.argNoteIsNew = False
                frmMain.argNoteIsPerson = False
                frmMain.argNoteName = extNameList(index)
                frmNote.ShowDialog()
        End Select
        doSearch()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Or e.KeyChar = Chr(10) Then Button1_Click(Nothing, Nothing)
    End Sub
End Class