Imports System
Imports System.Management

Public Class frmRegistration
    Public SendKey As String = ""
    Dim MachineMBID As String = ""
    Dim isKeyGen As Boolean = False
    Dim ProcessID As String = ""
    Dim StoredUnlockEey As String = ""

    Private Sub btnTrail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrail.Click
        Me.Close()
    End Sub

    Private Sub btnRegistration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegistration.Click

        If txtFName.Text.Trim.Length = 0 Then
            MessageBox.Show("Enter the First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFName.Focus()
            Exit Sub
        End If
        If txtLName.Text.Trim.Length = 0 Then
            MessageBox.Show("Enter the Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLName.Focus()
            Exit Sub
        End If
        If txtSlKey.Text.Trim.Length = 0 Then
            MessageBox.Show("Enter the CD Serial Key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSlKey.Focus()
            Exit Sub
        End If
        If txtSlKey.Text.Trim.Length <> 17 Then
            MessageBox.Show("Invalid Serial Key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSlKey.Focus()
            Exit Sub
        End If
        If txtSlKey.Text.Trim.Substring(5, 1) <> "-" Then
            MessageBox.Show("Invalid Serial Key. Please retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSlKey.Focus()
            Exit Sub
        End If
        If Not ValidateCDKEY(txtSlKey.Text.Trim.Substring(0, 5)) Then
            MessageBox.Show("Serial Key not valid!", "NOT Valid!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not ValidateCDKEY(txtSlKey.Text.Trim.Substring(6, 5)) Then
            MessageBox.Show("Serial Key not valid!", "NOT Valid!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim no As Integer = Val(txtSlKey.Text.Trim.Substring(12, 5))
        If Val(txtSlKey.Text.Trim.Substring(12, 5)) < 47253 Or Val(txtSlKey.Text.Trim.Substring(12, 5)) > 57252 Then
            MessageBox.Show("Serial Key not valid!", "NOT Valid!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Try
        '    If isKeyGen = False Then
        '        MachineMBID = GetMotherBoardID()
        '        Dim newMB As String = Formula(MachineMBID)
        '        SendKey = GenerateRandomKey()
        '        Dim serial As String = GenerateSerialFromBase(CConvert.FromBase36(newMB.Substring(0, 5)))
        '        Dim Process As String = GetProcessorId()
        '        StoredUnlockEey = Process.Substring(0, 5) & "-" & serial & "-" & Process.Substring(3, 5)
        '        If StoredUnlockEey = "" Then
        '            MsgBox("Store", MsgBoxStyle.Critical, "Store")
        '            Exit Sub
        '        End If
        '        SendKey = SendKey & "-" & newMB
        '        If Not keyGen() Then
        '            MsgBox("Key not generated", MsgBoxStyle.Critical, "Key")
        '            Exit Sub
        '        End If
        '        frmKey.ShowDialog()
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Registration failed. Please retry.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End Try
        Try
            If isKeyGen = False Then
                MachineMBID = GetProcessorId() 'GetMotherBoardID() 
                Dim newMB As String = Formula(MachineMBID)

                '===============================
                Dim KeyLen As Integer = newMB.Length
                Dim StartIndex As Integer = KeyLen - 5
                Dim KeyBase As String = newMB.Trim.Substring(StartIndex, 5)

                '===============================
                'Dim serial As String = GenerateSerialFromBase(CConvert.FromBase36(newMB.Substring(0, 5)))
                Dim serial As String = GenerateSerialFromBase(CConvert.FromBase36(KeyBase))
                Dim Process As String = GetProcessorId()
                StoredUnlockEey = Process.Substring(0, 5) & "-" & serial & "-" & Process.Substring(3, 5)
                If StoredUnlockEey = "" Then
                    MsgBox("Registration fail", MsgBoxStyle.Critical, "Store")
                    Exit Sub
                End If
                SendKey = newMB
                If Not InsertRegKey() Then
                    MsgBox("Registration fail. Read the registration instructions.", MsgBoxStyle.Critical, "Programe folder readonly")
                    Exit Sub
                End If
                frmKey.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show("Registration fail. Please retry.", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    Public Function InsertRegKey() As Boolean
        Dim result As Boolean = False
        Try
            Dim cmd As New Data.OleDb.OleDbCommand("DELETE FROM Settings", NewConn)
            cmd.ExecuteNonQuery()

            cmd = New Data.OleDb.OleDbCommand("INSERT INTO Settings (FName, LName, CDSerialNo, OriginMBID," & _
                                              " SendKey, KeyGen, KeyGenDate,StoredKey, StoredMBID)" & _
                                              " VALUES (?,?,?,?,?,?,?,?,?)", NewConn)
            cmd.Parameters.Add("@FName", OleDb.OleDbType.VarChar).Value = Trim(txtFName.Text)
            cmd.Parameters.Add("@LName", OleDb.OleDbType.VarChar).Value = Trim(txtLName.Text)
            cmd.Parameters.Add("@CDSerialNo", OleDb.OleDbType.VarChar).Value = Trim(txtSlKey.Text)
            cmd.Parameters.Add("@OriginMBID", OleDb.OleDbType.VarChar).Value = MachineMBID
            cmd.Parameters.Add("@SendKey", OleDb.OleDbType.VarWChar).Value = SendKey
            cmd.Parameters.Add("@KeyGen", OleDb.OleDbType.Boolean).Value = True
            cmd.Parameters.Add("@LName", OleDb.OleDbType.Date).Value = Today
            cmd.Parameters.Add("@StoredKey", OleDb.OleDbType.VarWChar).Value = StoredUnlockEey
            cmd.Parameters.Add("@StoredMBID", OleDb.OleDbType.VarWChar).Value = xFormula(MachineMBID)
            cmd.ExecuteNonQuery()
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Private Sub frmRegistration_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getConn()
        Try
            Dim cmd As New Data.OleDb.OleDbCommand("SELECT * FROM Settings", NewConn)
            Dim rs As Data.OleDb.OleDbDataReader = cmd.ExecuteReader
            If rs.HasRows Then
                rs.Read()
                isKeyGen = rs("keygen")
            End If
            If isKeyGen = True Then
                Me.Close()
                frmKey.ShowDialog()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

End Class