Public Class frmKey

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        frmRegistration.Close()
    End Sub

    Private Sub frmKey_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtKey.Text = frmRegistration.SendKey
        If Not LoadData() Then Exit Sub
    End Sub

    Private Function LoadData() As Boolean
        Dim result As Boolean = False
        Try
            Dim cmd As New Data.OleDb.OleDbCommand("SELECT * FROM Settings", NewConn)
            Dim rs As Data.OleDb.OleDbDataReader = cmd.ExecuteReader
            If rs.HasRows Then
                rs.Read()
                txtFName.Text = IIf(IsDBNull(rs("FName")), "", rs("FName"))
                txtLName.Text = IIf(IsDBNull(rs("LName")), "", rs("LName"))
                txtSerialKey.Text = IIf(IsDBNull(rs("CDSerialNo")), "", rs("CDSerialNo"))
                txtKey.Text = IIf(IsDBNull(rs("SendKey")), "", rs("SendKey"))
            End If
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtUnlockKey.Text.Trim.Length = 0 Then
            MessageBox.Show("The key is NOT valid!", "NOT Valid!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim BaseKey As String = ""
        Try
            Dim cmd As New Data.OleDb.OleDbCommand("SELECT * FROM Settings", NewConn)
            Dim rs As Data.OleDb.OleDbDataReader = cmd.ExecuteReader
            If rs.HasRows Then
                rs.Read()
                BaseKey = IIf(IsDBNull(rs("SendKey")), "", rs("SendKey"))
            End If
        Catch ex As Exception
            MessageBox.Show("Registration fail.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        '==================
        Dim KeyLen As Integer = BaseKey.Length
        Dim StartIndex As Integer = KeyLen - 5
        Dim KeyBase As String = BaseKey.Trim.Substring(StartIndex, 5)
        '==================
        'Dim UnlockKey As String = BaseKey.Trim.Substring(0, 5) & "-" & txtUnlockKey.Text.Trim
        Dim UnlockKey As String = KeyBase & "-" & txtUnlockKey.Text.Trim
        If Not ValidateCode(UnlockKey) Then
            MessageBox.Show("The key is NOT valid!", "NOT Valid!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim StoredKey As String = ""
        Try
            Dim cmd As New Data.OleDb.OleDbCommand("SELECT * FROM Settings", NewConn)
            Dim rs As Data.OleDb.OleDbDataReader = cmd.ExecuteReader
            If rs.HasRows Then
                rs.Read()
                StoredKey = IIf(IsDBNull(rs("StoredKey")), "", rs("StoredKey"))
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Dim St As String = StoredKey.Substring(6, 23)
        If UnlockKey = St Then
            Try
                Dim cmd As New Data.OleDb.OleDbCommand("UPDATE Settings SET IsRegistered=" & True & ", KeyGen=" & False, NewConn)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Exit Sub
            End Try
            MessageBox.Show("Click Ok to restart the proramme.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMain.ActvationToolStripMenuItem.Visible = False
            SplashScreen.Close()
        Else
            MessageBox.Show("The key is NOT valid!", "NOT Valid!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



End Class