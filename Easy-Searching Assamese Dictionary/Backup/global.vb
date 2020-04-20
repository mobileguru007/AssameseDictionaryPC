Imports System.Data
Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module _global
    Public objConn As OleDbConnection
    Dim btn As DataGridViewButtonColumn
    Dim sChar As Object
    Public IsRegistered As Boolean = False
    Public Registeredto As String = ""
    Public NewConn As OleDbConnection
    Dim ran As New Random
    Dim MainDB As String = "asetting0.dll"
    Dim MainPwd As String = "2012@DGogoi"
    Dim DemoDB As String = "dsetting0.dll"
    Dim DemoPwd As String = "IMDurlav@2012"
    Dim SettingsDB As String = "ssetting0.dll"
    Dim SettPwd As String = "IMDurlav@Aug2012"
    Public strEncodeString As String = "a9pk" ' "s3e3df5"
    Public path As String = Application.StartupPath.ToString
    Public dtPinCod As New DataTable




    Public Sub getConn()
        Try
            If IsNothing(objConn) Then
                'Dim NewStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Path & "\" & SettingsDB & ";Persist Security Info=True;Jet OLEDB:Database Password=" & SettPwd

                Dim NewStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\" & SettingsDB & ";Persist Security Info=True;Jet OLEDB:Database Password=" & SettPwd
                'Dim NewStr = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=|DataDirectory|\" & SettingsDB & ";Persist Security Info=True;Jet OLEDB:Database Password=" & SettPwd

                NewConn = New Data.OleDb.OleDbConnection(NewStr)
                Dim result As String = ""
                If NewConn.State = ConnectionState.Closed Then NewConn.Open()
                Dim cmd As New Data.OleDb.OleDbCommand
                Dim MBStatus As Boolean = False
                Dim CheckCDKey As Boolean = True
                Dim MachineMBID As String = GetProcessorId()
                Dim newMB As String = Formula(MachineMBID)
                Dim GetMBIDd As String = xFormula(newMB)

                cmd = New Data.OleDb.OleDbCommand("SELECT * FROM Settings", NewConn)
                Dim rs As Data.OleDb.OleDbDataReader = cmd.ExecuteReader
                If rs.HasRows Then
                    rs.Read()

                    Dim CdKey As String = IIf(IsDBNull(rs("CDSerialNo")), "", rs("CDSerialNo"))
                    Dim KeyGenStatus As Boolean = rs("KeyGen")
                    Dim RegStatus As Boolean = rs("IsRegistered")
                    Dim SendKey As String = IIf(IsDBNull(rs("SendKey")), "", rs("SendKey"))
                    Dim SendMBID As String = SendKey.Trim

                    'get the system mbid from the send mbid
                    Dim GetMBID As String = xFormula(SendMBID)
                    '==============================check the cd key is genuine
                    If CdKey = "" Then
                        CheckCDKey = False
                    End If
                    If Not ValidateCDKEY(CdKey.Trim.Substring(0, 5)) Then
                        CheckCDKey = False
                    End If
                    If Not ValidateCDKEY(CdKey.Trim.Substring(6, 5)) Then
                        CheckCDKey = False
                    End If
                    If Val(CdKey.Trim.Substring(12, 5)) < 47253 Or Val(CdKey.Trim.Substring(12, 5)) > 57252 Then
                        CheckCDKey = False
                    End If
                    '==============================
                    If MachineMBID.Trim.Length <> 0 And GetMBID.Trim.Length <> 0 Then
                        If MachineMBID = GetMBID Then
                            MBStatus = True
                        End If
                    End If
                    Dim OriginMBID As String = IIf(IsDBNull(rs("OriginMBID")), "", rs("OriginMBID"))

                    If CheckCDKey = True Then
                        If MBStatus = True Then
                            If OriginMBID <> "" Then
                                If MachineMBID = OriginMBID Then
                                    If RegStatus = True And KeyGenStatus = False And MBStatus = True Then
                                        IsRegistered = True
                                        Dim F As String = IIf(IsDBNull(rs("FName")), "", rs("FName"))
                                        Dim L As String = IIf(IsDBNull(rs("LName")), "", rs("LName"))
                                        Registeredto = UCase(F.Substring(0, 1)) & F.Substring(1) & " " & UCase(L.Substring(0, 1)) & L.Substring(1)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                '=============Checking the year if it is 2015 or not============
                Dim SYear As Integer = Today.Date.Year
                If SYear > 2020 Then
                    IsRegistered = True
                    Dim F As String = "Full"
                    Dim L As String = "Version"
                    Registeredto = UCase(F.Substring(0, 1)) & F.Substring(1) & " " & UCase(L.Substring(0, 1)) & L.Substring(1)
                End If
                '=============

                Dim xconnstr As String = ""
                If IsRegistered = False Then
                    Registeredto = "Unregistered"
                    xconnstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\" & DemoDB & ";Persist Security Info=True;Jet OLEDB:Database Password=" & DemoPwd
                Else
                    NewConn.Close()
                    Registeredto = "Registered to: " & Registeredto
                    xconnstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\" & MainDB & ";Persist Security Info=True;Jet OLEDB:Database Password=" & MainPwd
                End If
                objConn = New Data.OleDb.OleDbConnection(xconnstr)
            End If
            If objConn.State = ConnectionState.Closed Then objConn.Open()
        Catch ex As Exception
            MsgBox("Error in loading the programme. Please read the installation guide.", MsgBoxStyle.Critical, "Error")
            SplashScreen.Close()
            Exit Sub
        End Try
    End Sub

    Public Sub loadComboCharacters(ByVal gvcomposit As DataGridView)
        Dim i As Integer
        Dim j As Integer
        Dim x As Integer
        Dim colsArray As Object
        sChar = New String() {"ক", "খ", "গ", "ঘ", "ঙ", "চ", "ছ", "জ", "ঞ", "ট", "ড", "ণ", "ত", "থ", "দ", "ধ", "ন", "প", "ফ", "ব", "ভ", "ম", "ল", "শ", "ষ", "স", "হ", "ক্ষ"}
        ' 28 nos
        Dim y As Integer = UBound(sChar)
        For i = 0 To UBound(sChar)
            gvcomposit.Rows.Add()
            gvcomposit.Rows(i).Height = 35
            gvcomposit.Rows(i).Cells(0).Value = sChar(i)
            gvcomposit.Rows(i).Cells(0).Style.ForeColor = System.Drawing.Color.Blue
            gvcomposit.Rows(i).Cells(0).Style.BackColor = System.Drawing.Color.DarkGray
            gvcomposit.Rows(i).Cells(0).Selected = False
            gvcomposit.Rows(i).Cells(0).ReadOnly = True
            colsArray = ComboCharacters(i)
            x = UBound(colsArray)

            If gvcomposit.ColumnCount >= UBound(colsArray) Then
                For j = 0 To UBound(colsArray)
                    gvcomposit.Rows(i).Cells(j + 1).Value = colsArray(j)
                    gvcomposit.Rows(i).Cells(j + 1).Style.ForeColor = System.Drawing.Color.Blue
                    gvcomposit.Rows(i).Cells(j + 1).Style.BackColor = System.Drawing.Color.DarkGray
                    gvcomposit.Columns(j + 1).Width = 35
                Next
            ElseIf gvcomposit.ColumnCount >= 1 And gvcomposit.ColumnCount <= UBound(colsArray) Then
                For j = 0 To UBound(colsArray)
                    If gvcomposit.ColumnCount = 1 Then
                        btn = New DataGridViewButtonColumn
                        btn.Width = 35
                    ElseIf (gvcomposit.ColumnCount) <= (j + 1) Then
                        btn = New DataGridViewButtonColumn
                        btn.Width = 35
                    End If
                    gvcomposit.Rows(i).Cells(j + 1).Value = colsArray(j)
                    gvcomposit.Rows(i).Cells(j + 1).Style.ForeColor = System.Drawing.Color.Blue
                    gvcomposit.Rows(i).Cells(j + 1).Style.BackColor = System.Drawing.Color.DarkGray
                    gvcomposit.Columns(j + 1).Width = 35
                Next
            End If
        Next
    End Sub

    Public Function ComboCharacters(ByVal i As Integer) As Object
        Dim LChar(28) As Object

        LChar(0) = New String() {"ক্ক", "ক্ট", "ক্ট্ৰ", "ক্ত", "ক্ব", "ক্ন", "ক্ম", "ক্ৰ", "ক্ল", "ক্স"}
        LChar(1) = New String() {"খ্ৰ", "খ্ৰু"}
        LChar(2) = New String() {"গু", "গ্গ", "গ্ধ", "গ্ন", "গ্ম", "গ্ৰ", "গ্ল", "গ্ব"}
        LChar(3) = New String() {"ঘ্ন", "ঘ্ৰ"}
        LChar(4) = New String() {"ঙ্ক", "ঙ্খ", "ঙ্গ", "ঙ্ঘ", "ঙ্ক্ষ"}
        LChar(5) = New String() {"চ্চ", "চ্ছ", "চ্ছ্ৰ", "চ্ছ্ব", "চ্ঞ"}
        LChar(6) = New String() {"ছ্ৰ"}
        LChar(7) = New String() {"জ্জ", "জ্ঞ", "জ্ৰ", "জ্ব", "জ্জ্ব"}
        LChar(8) = New String() {"ঞ্চ", "ঞ্ছ", "ঞ্জ", "ঞ্ঝ"}
        LChar(9) = New String() {"ট্ট", "ট্ৰ"}
        LChar(10) = New String() {"ড্ড", "ড্ৰ"}
        LChar(11) = New String() {"ণ্ট", "ণ্ট্ৰ", "ণ্ঠ", "ণ্ড", "ণ্ড্ৰ", "ণ্ঢ", "ণ্ণ", "ণ্ম", "ণ্ব"}
        LChar(12) = New String() {"ত্ত", "ত্ত্ব", "ত্থ", "ত্ন", "ত্ম", "ত্ৰ", "ত্ৰু", "ত্ব"}
        LChar(13) = New String() {"থ্ৰ", "থ্ব"}
        LChar(14) = New String() {"দ্ঘ", "দ্দ", "দ্দ্ব", "দ্ধ", "দ্ভ", "দ্ভ্র", "দ্ম", "দ্ৰ", "দ্ব"}
        LChar(15) = New String() {"ধ্ন", "ধ্ৰ", "ধ্ব"}
        LChar(16) = New String() {"ন্ত", "ন্তু", "ন্ত্র", "ন্ত্ব", "ন্থ", "ন্দ", "ন্দ্ৰ", "ন্ধ", "ন্ধ্ৰ", "ন্ন", "ন্ব", "ন্ম", "ন্স"}
        LChar(17) = New String() {"প্ট", "প্ত", "প্ন", "প্প", "প্ৰ", "প্ল", "প্স"}
        LChar(18) = New String() {"ফ্ৰ", "ফ্ল"}
        LChar(19) = New String() {"ব্জ", "ব্দ", "ব্ধ", "ব্ব", "ব্ভ", "ব্ৰ", "ব্ল"}
        LChar(20) = New String() {"ভ্ৰ"}
        LChar(21) = New String() {"ম্প", "ম্প্ৰ", "ম্ফ", "ম্ফ্ৰ", "ম্ব", "ম্ব্ৰ", "ম্ভ", "ম্ভ্ৰ", "ম্ম", "ম্ৰ", "ম্ল"}
        LChar(22) = New String() {"ল্ক", "ল্গ", "ল্ট", "ল্ড", "ল্প", "ল্ব", "ল্ম", "ল্ল"}
        LChar(23) = New String() {"শ্চ", "শ্ছ", "শ্ন", "শ্ম", "শ্ৰ", "শ্ল", "শ্ব"}
        LChar(24) = New String() {"ষ্ক", "ষ্ক্ৰ", "ষ্ট", "ষ্ট্ৰ", "ষ্ঠ", "ষ্ণ", "ষ্প", "ষ্প্ৰ", "ষ্ফ", "ষ্ম"}
        LChar(25) = New String() {"স্ক", "স্ক্ৰ", "স্খ", "স্ত", "স্ত্ৰ", "স্ত্ব", "স্থ", "স্ন", "স্প", "স্প্ৰ", "স্ফ", "স্ম", "স্ৰ", "স্ল", "স্ব"}
        LChar(26) = New String() {"হ্ম", "হ্ৰ", "হ্ল", "হ্ব"}
        LChar(27) = New String() {"ক্ষ্ন", "ক্ষ্ম"}

        ComboCharacters = LChar(i)

    End Function

    Public Function VowelCharacters(ByVal i As Integer) As Object
        Dim LChar(2) As Object
        LChar(0) = New String() {"আ", "ই", "ঈ"}
        LChar(1) = New String() {"ঊ", "ঋ"}
        LChar(2) = New String() {"ঐ", "ও", "ঔ"}
        VowelCharacters = LChar(i)
    End Function

    Public Sub loadVowel(ByVal gvVowel As DataGridView)
        Dim i As Integer
        Dim j As Integer
        Dim colsArray As Object
        sChar = New String() {"অ", "উ", "এ"}
        For i = 0 To UBound(sChar)
            gvVowel.Rows.Add()
            gvVowel.Rows(i).Height = 39
            gvVowel.Rows(i).Cells(0).Value = sChar(i)
            gvVowel.Rows(i).Cells(0).Style.ForeColor = System.Drawing.Color.Black
            gvVowel.Rows(i).Cells(0).Style.BackColor = System.Drawing.Color.DarkGray
            gvVowel.Rows(i).Cells(0).Selected = False
            gvVowel.Rows(i).Cells(0).ReadOnly = True
            colsArray = VowelCharacters(i)
            Dim x As Integer = UBound(colsArray)

            If gvVowel.ColumnCount >= UBound(colsArray) Then
                For j = 0 To UBound(colsArray)
                    gvVowel.Rows(i).Cells(j + 1).Value = colsArray(j)
                    gvVowel.Rows(i).Cells(j + 1).Style.ForeColor = System.Drawing.Color.Black
                    gvVowel.Rows(i).Cells(j + 1).Style.BackColor = System.Drawing.Color.DarkGray
                    gvVowel.Columns(j + 1).Width = 39
                Next
            ElseIf gvVowel.ColumnCount >= 1 And gvVowel.ColumnCount <= UBound(colsArray) Then
                For j = 0 To UBound(colsArray)
                    If gvVowel.ColumnCount = 1 Then
                        btn = New DataGridViewButtonColumn
                        btn.Width = 39
                        gvVowel.Columns.Add(btn)
                    ElseIf (gvVowel.ColumnCount) <= (j + 1) Then
                        btn = New DataGridViewButtonColumn
                        btn.Width = 39
                        gvVowel.Columns.Add(btn)
                    End If
                    gvVowel.Rows(i).Cells(j + 1).Value = colsArray(j)
                    gvVowel.Rows(i).Cells(j + 1).Style.ForeColor = System.Drawing.Color.Black
                    gvVowel.Rows(i).Cells(j + 1).Style.BackColor = System.Drawing.Color.DarkGray
                    gvVowel.Columns(j + 1).Width = 39
                Next
            End If
        Next
    End Sub

    Public Function ConsCharacters(ByVal i As Integer) As Object
        Dim LChar(8) As Object

        LChar(0) = New String() {"খ", "গ", "ঘ", "ঙ"}
        LChar(1) = New String() {"ছ", "জ", "ঝ", "ঞ"}
        LChar(2) = New String() {"ঠ", "ড", "ঢ", "ণ"}

        LChar(3) = New String() {"থ", "দ", "ধ", "ন"}
        LChar(4) = New String() {"ফ", "ব", "ভ", "ম"}
        LChar(5) = New String() {"ৰ", "ল", "ৱ"}

        LChar(6) = New String() {"ষ", "স", "হ"}
        LChar(7) = New String() {"ড়", "ঢ়", "য়"}
        LChar(8) = New String() {"ং", "ঃ", "ঁ"}
        ConsCharacters = LChar(i)
    End Function


    Public Sub loadConsonent(ByVal gvcons As DataGridView)
        Dim i As Integer
        Dim j As Integer
        Dim colsArray As Object
        sChar = New String() {"ক", "চ", "ট", "ত", "প", "য", "শ", "ক্ষ", "ৎ"}
        For i = 0 To UBound(sChar)
            gvcons.Rows.Add()
            gvcons.Rows(i).Height = 30
            gvcons.Rows(i).Cells(0).Value = sChar(i)
            gvcons.Rows(i).Cells(0).Style.ForeColor = System.Drawing.Color.Black
            gvcons.Rows(i).Cells(0).Style.BackColor = System.Drawing.Color.DarkGray
            gvcons.Rows(i).Cells(0).Selected = False
            gvcons.Rows(i).Cells(0).ReadOnly = True
            colsArray = ConsCharacters(i)
            Dim x As Integer = UBound(colsArray)

            If gvcons.ColumnCount >= UBound(colsArray) Then
                For j = 0 To UBound(colsArray)
                    gvcons.Rows(i).Cells(j + 1).Value = colsArray(j)
                    gvcons.Rows(i).Cells(j + 1).Style.ForeColor = System.Drawing.Color.Black
                    gvcons.Rows(i).Cells(j + 1).Style.BackColor = System.Drawing.Color.DarkGray
                    gvcons.Columns(j + 1).Width = 30
                Next
            ElseIf gvcons.ColumnCount >= 1 And gvcons.ColumnCount <= UBound(colsArray) Then
                For j = 0 To UBound(colsArray)
                    If gvcons.ColumnCount = 1 Then
                        btn = New DataGridViewButtonColumn
                        btn.Width = 30
                        gvcons.Columns.Add(btn)
                    ElseIf (gvcons.ColumnCount) <= (j + 1) Then
                        btn = New DataGridViewButtonColumn
                        btn.Width = 30
                        gvcons.Columns.Add(btn)
                    End If
                    gvcons.Rows(i).Cells(j + 1).Value = colsArray(j)
                    gvcons.Rows(i).Cells(j + 1).Style.ForeColor = System.Drawing.Color.Black
                    gvcons.Rows(i).Cells(j + 1).Style.BackColor = System.Drawing.Color.DarkGray
                    gvcons.Columns(j + 1).Width = 30
                Next
            End If
        Next
    End Sub

    Public Function GenerateRandomKey() As String
        Dim serial As String = ""
        Dim key As Long = ran.Next(0, 60466175)
        Dim lst As New List(Of List(Of String))

        Dim arr1() As String = {"L", "L", "B", "C", "C", "D", "E", "E", "F", "G", "G", "H", "I", "I", "J", "K", "K", "L", "K", "K", "1", "5", "5", "P", "Q", "Q", "R", "S", "S", "T", "U", "U", "B", "W", "W", "X", "Y", "Y", "5", "L", "L", "9", "2", "2", "3", "4", "4", "5", "6", "6", "7", "6", "6", "9"}
        Dim arr2() As String = {"B", "C", "D", "F", "G", "H", "J", "K", "L", "K", "1", "P", "Q", "R", "S", "T", "B", "W", "X", "Y", "5", "L", "9", "2", "3", "4", "5", "6", "7", "6", "9"}
        Dim arr3() As String = {"L", "E", "I", "5", "U", "L", "9", "2", "3", "4", "5", "6", "7", "6", "9", "L", "9", "2", "3", "4", "5", "6", "7", "6", "9", "L", "9", "2", "3", "4", "5", "6", "7", "6", "9"}
        Dim arr4() As String = {"L", "2", "4", "6", "6", "L", "C", "E", "G", "I", "K", "K", "5", "Q", "S", "U", "W", "Y"}
        Dim arr5() As String = {"L", "9", "2", "6", "7", "6", "L", "B", "C", "G", "H", "I", "K", "1", "5", "S", "T", "U", "Y", "5"}
        Dim arr6() As String = {"L", "X", "K", "1", "T", "5", "P", "U", "B", "Q", "W", "L", "K", "L", "2", "4", "5", "6", "6", "9"}
        Dim arr7() As String = {"1", "T", "5", "S", "P", "R", "I", "E", "L", "X", "Q", "5", "C", "B", "H", "6", "7", "2", "9", "6", "L", "3"}
        Dim arr8() As String = {"L", "S", "D", "K", "1", "5", "Q", "R", "S", "1", "B", "Q", "Y", "Q", "K", "X", "C", "L", "4", "5", "9", "2"}
        Dim arr9() As String = {"9", "7", "6", "4", "3", "9", "Q", "E", "T", "U", "5", "L", "S", "F", "H", "K", "5", "C", "B", "K"}
        Dim arr10() As String = {"9", "6", "7", "3", "2", "9", "5", "5", "5", "W", "R", "Y", "I", "P", "S", "F", "H", "K", "5", "C", "B", "K"}
        Dim arr11() As String = {"Q", "R", "I", "L", "F", "J", "5", "B", "K", "E", "U", "P", "D", "H", "L", "C", "1", "L", "2", "3", "5", "7", "6"}
        Dim arr12() As String = {"Q", "L", "5", "E", "D", "C", "T", "G", "B", "U", "J", "K", "5", "L", "7", "4", "5", "6", "3", "2"}
        Dim arr13() As String = {"Q", "L", "S", "E", "R", "F", "G", "H", "Y", "U", "J", "K", "I", "5", "L", "5", "X", "S", "D", "F", "B", "B", "G", "H", "J", "K", "K", "9", "5", "9", "7", "5", "3"}
        Dim arr14() As String = {"Q", "W", "E", "T", "Y", "U", "5", "P", "L", "D", "F", "G", "J", "K", "L", "X", "C", "B", "1", "K", "9", "4", "6", "9"}
        Dim arr15() As String = {"Q", "L", "5", "X", "C", "D", "E", "R", "T", "G", "B", "1", "K", "J", "U", "I", "5", "L", "9", "5", "4", "6", "6", "2", "3"}
        Dim arr16() As String = {"W", "E", "D", "C", "B", "B", "G", "T", "Y", "U", "J", "K", "K", "L", "5", "H", "F", "S", "9", "5", "4", "2", "3"}
        Dim arr17() As String = {"5", "I", "U", "T", "G", "B", "C", "X", "5", "Q", "W", "E", "R", "F", "B", "B", "1", "K"}
        Dim arr18() As String = {"Q", "L", "5", "X", "S", "D", "C", "B", "F", "R", "T", "G", "B", "1", "H", "J", "K", "K", "I", "5", "L", "P", "9", "3", "2", "5", "6", "7", "9"}
        Dim arr19() As String = {"L", "I", "L", "K", "I", "S", "C", "5", "5", "L", "I", "S", "1", "T", "H", "E", "3", "3", "3"}

        Dim arr20() As String = {"L", "S", "D", "I", "S", "C", "5", "5", "L", "S", "5", "I", "S", "C", "5", "C", "L", "I", "1", "E", "L", "1", "D", "P", "5", "T", "L", "1", "D", "K", "E", "T", "H"}

        lst.Add(New List(Of String)(arr1))
        lst.Add(New List(Of String)(arr2))
        lst.Add(New List(Of String)(arr3))
        lst.Add(New List(Of String)(arr4))
        lst.Add(New List(Of String)(arr5))
        lst.Add(New List(Of String)(arr6))
        lst.Add(New List(Of String)(arr7))
        lst.Add(New List(Of String)(arr8))
        lst.Add(New List(Of String)(arr9))
        lst.Add(New List(Of String)(arr10))
        lst.Add(New List(Of String)(arr11))
        lst.Add(New List(Of String)(arr12))
        lst.Add(New List(Of String)(arr13))
        lst.Add(New List(Of String)(arr14))
        lst.Add(New List(Of String)(arr15))
        lst.Add(New List(Of String)(arr16))
        lst.Add(New List(Of String)(arr17))
        lst.Add(New List(Of String)(arr18))
        lst.Add(New List(Of String)(arr19))
        lst.Add(New List(Of String)(arr20))

        serial &= CConvert.ToBase36(key)
        Do Until serial.Length = 5
            serial = "0" + serial
        Loop
        Dim r1 As New Random(key)
        Dim s As String = r1.ToString
        Dim x As Integer
        Do Until serial.Length = 11
            x = serial.Length
            If x Mod 6 = 5 Then
                serial &= "-"
            Else
                serial &= lst.Item(x - (5 + (x + 1) \ 6)).Item(r1.Next(0, lst.Item(x - (5 + (x + 1) \ 6)).Count - 1))
            End If
        Loop
        Return serial
    End Function


    Public Function GenerateSerialFromBase(ByVal Key As Integer)
        Dim serial As String
        Dim lst As New List(Of List(Of String))

        Dim arr1() As String = {"L", "L", "B", "C", "C", "D", "E", "E", "F", "G", "G", "H", "I", "I", "J", "K", "K", "L", "K", "K", "1", "5", "5", "P", "Q", "Q", "R", "S", "S", "T", "U", "U", "B", "W", "W", "X", "Y", "Y", "5", "L", "L", "9", "2", "2", "3", "4", "4", "5", "6", "6", "7", "6", "6", "9"}
        Dim arr2() As String = {"B", "C", "D", "F", "G", "H", "J", "K", "L", "K", "1", "P", "Q", "R", "S", "T", "B", "W", "X", "Y", "5", "L", "9", "2", "3", "4", "5", "6", "7", "6", "9"}
        Dim arr3() As String = {"L", "E", "I", "5", "U", "L", "9", "2", "3", "4", "5", "6", "7", "6", "9", "L", "9", "2", "3", "4", "5", "6", "7", "6", "9", "L", "9", "2", "3", "4", "5", "6", "7", "6", "9"}
        Dim arr4() As String = {"L", "2", "4", "6", "6", "L", "C", "E", "G", "I", "K", "K", "5", "Q", "S", "U", "W", "Y"}
        Dim arr5() As String = {"L", "9", "2", "6", "7", "6", "L", "B", "C", "G", "H", "I", "K", "1", "5", "S", "T", "U", "Y", "5"}
        Dim arr6() As String = {"L", "X", "K", "1", "T", "5", "P", "U", "B", "Q", "W", "L", "K", "L", "2", "4", "5", "6", "6", "9"}
        Dim arr7() As String = {"1", "T", "5", "S", "P", "R", "I", "E", "L", "X", "Q", "5", "C", "B", "H", "6", "7", "2", "9", "6", "L", "3"}
        Dim arr8() As String = {"L", "S", "D", "K", "1", "5", "Q", "R", "S", "1", "B", "Q", "Y", "Q", "K", "X", "C", "L", "4", "5", "9", "2"}
        Dim arr9() As String = {"9", "7", "6", "4", "3", "9", "Q", "E", "T", "U", "5", "L", "S", "F", "H", "K", "5", "C", "B", "K"}
        Dim arr10() As String = {"9", "6", "7", "3", "2", "9", "5", "5", "5", "W", "R", "Y", "I", "P", "S", "F", "H", "K", "5", "C", "B", "K"}
        Dim arr11() As String = {"Q", "R", "I", "L", "F", "J", "5", "B", "K", "E", "U", "P", "D", "H", "L", "C", "1", "L", "2", "3", "5", "7", "6"}
        Dim arr12() As String = {"Q", "L", "5", "E", "D", "C", "T", "G", "B", "U", "J", "K", "5", "L", "7", "4", "5", "6", "3", "2"}
        Dim arr13() As String = {"Q", "L", "S", "E", "R", "F", "G", "H", "Y", "U", "J", "K", "I", "5", "L", "5", "X", "S", "D", "F", "B", "B", "G", "H", "J", "K", "K", "9", "5", "9", "7", "5", "3"}
        Dim arr14() As String = {"Q", "W", "E", "T", "Y", "U", "5", "P", "L", "D", "F", "G", "J", "K", "L", "X", "C", "B", "1", "K", "9", "4", "6", "9"}
        Dim arr15() As String = {"Q", "L", "5", "X", "C", "D", "E", "R", "T", "G", "B", "1", "K", "J", "U", "I", "5", "L", "9", "5", "4", "6", "6", "2", "3"}
        Dim arr16() As String = {"W", "E", "D", "C", "B", "B", "G", "T", "Y", "U", "J", "K", "K", "L", "5", "H", "F", "S", "9", "5", "4", "2", "3"}
        Dim arr17() As String = {"5", "I", "U", "T", "G", "B", "C", "X", "5", "Q", "W", "E", "R", "F", "B", "B", "1", "K"}
        Dim arr18() As String = {"Q", "L", "5", "X", "S", "D", "C", "B", "F", "R", "T", "G", "B", "1", "H", "J", "K", "K", "I", "5", "L", "P", "9", "3", "2", "5", "6", "7", "9"}
        Dim arr19() As String = {"L", "I", "L", "K", "I", "S", "C", "5", "5", "L", "I", "S", "1", "T", "H", "E", "3", "3", "3"}

        Dim arr20() As String = {"L", "S", "D", "I", "S", "C", "5", "5", "L", "S", "5", "I", "S", "C", "5", "C", "L", "I", "1", "E", "L", "1", "D", "P", "5", "T", "L", "1", "D", "K", "E", "T", "H"}



        lst.Add(New List(Of String)(arr1))
        lst.Add(New List(Of String)(arr2))
        lst.Add(New List(Of String)(arr3))
        lst.Add(New List(Of String)(arr4))
        lst.Add(New List(Of String)(arr5))
        lst.Add(New List(Of String)(arr6))
        lst.Add(New List(Of String)(arr7))
        lst.Add(New List(Of String)(arr8))
        lst.Add(New List(Of String)(arr9))
        lst.Add(New List(Of String)(arr10))
        lst.Add(New List(Of String)(arr11))
        lst.Add(New List(Of String)(arr12))
        lst.Add(New List(Of String)(arr13))
        lst.Add(New List(Of String)(arr14))
        lst.Add(New List(Of String)(arr15))
        lst.Add(New List(Of String)(arr16))
        lst.Add(New List(Of String)(arr17))
        lst.Add(New List(Of String)(arr18))
        lst.Add(New List(Of String)(arr19))
        lst.Add(New List(Of String)(arr20))

        Dim r1 As New Random(Key)
        serial = CConvert.ToBase36(Key)
        Do Until serial.Length = 5
            serial = "0" + serial
        Loop
        Dim x As Integer
        Do Until serial.Length = 23
            x = serial.Length
            If x Mod 6 = 5 Then
                serial &= "-"
            Else
                serial &= lst.Item(x - (5 + (x + 1) \ 6)).Item(r1.Next(0, lst.Item(x - (5 + (x + 1) \ 6)).Count - 1))
            End If
        Loop
        Return serial
    End Function


    Public Function GetMotherBoardID() As String
        Dim strMotherBoardID As String = String.Empty
        Try
            Dim query As New SelectQuery("Win32_BaseBoard")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strMotherBoardID = info("SerialNumber").ToString()
            Next
        Catch ex As Exception
            MsgBox("MID not found", MsgBoxStyle.Critical, "MID")
            Exit Try
        End Try
        If strMotherBoardID = "" Then
            strMotherBoardID = "324BLN"
        End If
        Return strMotherBoardID
        'Return strMotherBoardID.Trim.Substring(0, 6)
    End Function

    Friend Function GetProcessorId() As String

        Dim strProcessorId As String = String.Empty
        Try
            Dim query As New SelectQuery("Win32_processor")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strProcessorId = info("processorId").ToString()
            Next
        Catch ex As Exception
            MsgBox("ID not found", MsgBoxStyle.Critical, "ID")
            Exit Try
        End Try
        If strProcessorId = "" Then
            strProcessorId = "PROGRESS"
        End If
        'If strProcessorId.Trim.Length < 9 Then
        '    strProcessorId = strProcessorId & "DCB123456"
        'End If
        'Return strProcessorId.Trim.Substring(0, 9)
        Return strProcessorId.Trim
    End Function

    Public Function Formula(ByVal sword As String) As String

        Dim mword As String
        Dim xword As Object
        Dim yword As Object
        Dim a As Integer = 0
        Dim b As Integer = 0
        xword = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "5", "6", "7", "8", "9", "0"}
        yword = New String() {"H", "I", "J", "K", "L", "M", "N", "A", "B", "C", "D", "E", "F", "G", "O", "P", "R", "S", "T", "U", "Z", "1", "2", "3", "5", "6", "7", "8", "9", "0", "V", "W", "X", "Y"}

        mword = ""
        Try
            Dim x As Integer = UBound(xword)
            For a = 0 To UBound(xword)
                b = InStr(1, sword, xword(a))
                If b > 0 Then
                    mword = Replace(sword, xword(a), yword(a))
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message & "Formula")
            Exit Try
        End Try
        If mword = "" Then
            mword = "X1D43GHL"
        End If
        Return UCase(mword)
    End Function

    Public Function xFormula(ByVal sword As String) As String


        Dim mword As String
        Dim xword As Object
        Dim yword As Object
        Dim a As Integer = 0
        Dim b As Integer = 0

        If sword = "X1D43GHL" Then
            mword = "KI9U7NM"
            Return mword
            Exit Function
        End If
        yword = New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "5", "6", "7", "8", "9", "0"}
        xword = New String() {"H", "I", "J", "K", "L", "M", "N", "A", "B", "C", "D", "E", "F", "G", "O", "P", "R", "S", "T", "U", "Z", "1", "2", "3", "5", "6", "7", "8", "9", "0", "V", "W", "X", "Y"}

        mword = ""
        Dim x As Integer = UBound(xword)
        Try
            For a = 0 To UBound(xword)
                b = InStr(1, sword, xword(a))
                If b > 0 Then
                    mword = Replace(sword, xword(a), yword(a))
                    Exit For
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Try
        End Try

        Return UCase(mword)
    End Function


    Public Function ValidateCode(ByVal serial As String) As Boolean
        Dim result As Boolean = False
        Try
            If serial = GenerateSerialFromBase(CConvert.FromBase36(serial.Substring(0, 5))) Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Try
        End Try
        Return result
    End Function


    Public Function ValidateCDKEY(ByVal serial As String) As Boolean
        Dim result As Boolean = False
        Try
            If serial = GenerateSerialFromCDKEY(CConvert.FromBase36(serial.Trim)) Then
                result = True
            Else
                result = False
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Try
        End Try

        Return result
    End Function


    Public Function GenerateSerialFromCDKEY(ByVal Key As Integer)
        Dim serial As String
        Dim lst As New List(Of List(Of String))

        Dim arr1() As String = {"H", "H", "K", "C", "C", "D", "E", "E", "F", "G", "G", "H", "I", "I", "J", "K", "K", "H", "K", "K", "1", "5", "5", "P", "Q", "Q", "R", "S", "S", "T", "U", "U", "K", "W", "W", "X", "Y", "Y", "5", "H", "H", "M", "2", "2", "3", "4", "4", "5", "6", "6", "7", "6", "6", "M"}
        Dim arr2() As String = {"K", "C", "D", "F", "G", "H", "J", "K", "H", "K", "1", "P", "Q", "R", "8", "T", "K", "W", "X", "Y", "5", "H", "M", "2", "3", "4", "5", "6", "7", "6", "M"}
        Dim arr3() As String = {"H", "E", "I", "5", "U", "H", "M", "2", "3", "4", "5", "6", "7", "6", "M", "H", "M", "2", "3", "4", "5", "6", "7", "6", "M", "H", "M", "2", "3", "4", "5", "6", "7", "6", "M"}
        Dim arr4() As String = {"H", "2", "4", "6", "6", "H", "C", "E", "G", "I", "K", "K", "5", "Q", "S", "U", "W", "Y"}
        Dim arr5() As String = {"H", "M", "2", "6", "7", "6", "H", "L", "C", "G", "H", "I", "K", "1", "5", "S", "T", "U", "Y", "5"}
        Dim arr6() As String = {"L", "X", "K", "1", "T", "5", "P", "U", "K", "Q", "W", "H", "K", "H", "2", "4", "5", "6", "6", "M"}
        Dim arr7() As String = {"1", "T", "5", "S", "P", "R", "I", "E", "H", "X", "Q", "5", "U", "K", "H", "6", "7", "2", "M", "6", "H", "3"}
        Dim arr8() As String = {"H", "S", "D", "K", "1", "5", "Q", "R", "S", "1", "K", "Q", "Y", "Q", "K", "X", "C", "H", "4", "5", "M", "2"}
        Dim arr9() As String = {"M", "7", "6", "4", "3", "M", "Q", "E", "T", "U", "5", "H", "S", "F", "H", "K", "5", "C", "K", "K"}
        Dim arr10() As String = {"M", "6", "7", "3", "2", "M", "5", "5", "5", "W", "R", "P", "I", "P", "S", "F", "H", "K", "5", "C", "K", "K"}
        Dim arr11() As String = {"Q", "R", "I", "H", "F", "J", "5", "K", "K", "E", "U", "P", "D", "H", "H", "C", "1", "H", "2", "3", "5", "7", "6"}
        Dim arr12() As String = {"L", "H", "5", "E", "D", "C", "T", "G", "K", "U", "J", "K", "5", "H", "7", "4", "5", "6", "3", "2"}
        Dim arr13() As String = {"Q", "H", "S", "E", "R", "F", "G", "H", "Y", "U", "J", "K", "I", "5", "H", "5", "X", "S", "D", "F", "K", "K", "G", "H", "J", "K", "K", "M", "5", "M", "7", "5", "3"}
        Dim arr14() As String = {"Q", "W", "E", "T", "Y", "U", "5", "P", "H", "L", "F", "G", "J", "K", "H", "X", "C", "K", "1", "K", "M", "4", "6", "M"}
        Dim arr15() As String = {"B", "H", "5", "X", "C", "D", "E", "R", "T", "G", "K", "1", "K", "J", "U", "I", "5", "H", "M", "5", "4", "6", "6", "2", "3"}
        Dim arr16() As String = {"W", "E", "D", "C", "K", "K", "G", "T", "Y", "U", "J", "K", "K", "H", "5", "H", "F", "S", "M", "5", "4", "2", "3"}
        Dim arr17() As String = {"V", "I", "U", "T", "G", "K", "C", "X", "5", "Q", "W", "E", "R", "F", "K", "K", "1", "K"}
        Dim arr18() As String = {"Q", "H", "5", "X", "S", "D", "C", "K", "F", "R", "T", "G", "K", "1", "H", "J", "K", "K", "I", "5", "H", "P", "M", "3", "2", "5", "6", "7", "M"}
        Dim arr19() As String = {"H", "I", "H", "K", "I", "S", "C", "5", "5", "H", "I", "S", "1", "T", "H", "E", "3", "3", "3"}

        Dim arr20() As String = {"H", "S", "D", "I", "S", "C", "5", "5", "H", "S", "5", "I", "S", "C", "5", "C", "H", "I", "1", "E", "H", "1", "D", "P", "5", "T", "H", "1", "D", "K", "E", "T", "H"}


        lst.Add(New List(Of String)(arr1))
        lst.Add(New List(Of String)(arr2))
        lst.Add(New List(Of String)(arr3))
        lst.Add(New List(Of String)(arr4))
        lst.Add(New List(Of String)(arr5))
        lst.Add(New List(Of String)(arr6))
        lst.Add(New List(Of String)(arr7))
        lst.Add(New List(Of String)(arr8))
        lst.Add(New List(Of String)(arr9))
        lst.Add(New List(Of String)(arr10))
        lst.Add(New List(Of String)(arr11))
        lst.Add(New List(Of String)(arr12))
        lst.Add(New List(Of String)(arr13))
        lst.Add(New List(Of String)(arr14))
        lst.Add(New List(Of String)(arr15))
        lst.Add(New List(Of String)(arr16))
        lst.Add(New List(Of String)(arr17))
        lst.Add(New List(Of String)(arr18))
        lst.Add(New List(Of String)(arr19))
        lst.Add(New List(Of String)(arr20))

        Dim r1 As New Random(Key)
        serial = CConvert.ToBase36(Key)
        Try
            Do Until serial.Length = 5
                serial = "0" + serial
            Loop
            Dim x As Integer
            Do Until serial.Length = 6
                x = serial.Length
                If x Mod 6 = 5 Then
                    serial &= "-"
                Else
                    serial &= lst.Item(x - (5 + (x + 1) \ 6)).Item(r1.Next(0, lst.Item(x - (5 + (x + 1) \ 6)).Count - 1))
                End If
            Loop
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Try
        End Try
        Return serial.Substring(0, 5)
    End Function

    Public Function EachCharacterEncrypt(ByVal xword As String, ByVal code As String) As String
        Dim xCharacters As String = ""
        For i As Integer = 0 To xword.Length - 1
            Dim eccodedText As String = xword.Substring(i, 1)
            If eccodedText <> "" Then
                xCharacters = xCharacters & Encrypt(eccodedText, code)
            End If
        Next
        Return xCharacters
    End Function

    Public Function eachCharDecrept(ByVal xword As String, ByVal code As String) As String
        Dim decodedtext As String = ""
        Dim array() As String = Nothing
        If xword <> "" Then
            array = xword.Split("=")
        End If
        Dim DecWord As String = ""
        For i As Integer = 0 To Array.Count - 1
            Dim eccodedText As String = Array(i).ToString
            If eccodedText <> "" Then
                eccodedText = eccodedText & "="
                decodedtext = decodedtext & Decrypt(eccodedText, "a9pk")
            End If
        Next
        Return decodedtext
    End Function


    Public Function Encrypt(ByVal text As String, ByVal key As String) As String
        If text.Trim = "" Then
            Return ""
        End If
        Try
            Dim crp As New TripleDESCryptoServiceProvider
            Dim uEncode As New UTF8Encoding
            Dim bytPlainText() As Byte = uEncode.GetBytes(text)
            Dim stmCipherText As New MemoryStream
            Dim slt() As Byte = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
            Dim pdb As New Rfc2898DeriveBytes(key, slt)
            Dim bytDerivedKey() As Byte = pdb.GetBytes(24)

            crp.Key = bytDerivedKey
            crp.IV = pdb.GetBytes(8)

            Dim csEncrypted As New CryptoStream(stmCipherText, crp.CreateEncryptor(), CryptoStreamMode.Write)

            csEncrypted.Write(bytPlainText, 0, bytPlainText.Length)
            csEncrypted.FlushFinalBlock()
            'RichTextBox1.Text = Convert.ToBase64String(stmCipherText.ToArray())
            Return Convert.ToBase64String(stmCipherText.ToArray())
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function Decrypt(ByVal text As String, ByVal key As String) As String
        If text.Trim = "" Then
            Return ""
        End If
        Dim crp As TripleDESCryptoServiceProvider
        Try
            crp = New TripleDESCryptoServiceProvider
            Dim uEncode As New UTF8Encoding
            Dim bytCipherText() As Byte = Convert.FromBase64String(text)
            Dim stmPlainText As New MemoryStream
            Dim stmCipherText As New MemoryStream(bytCipherText)
            Dim slt() As Byte = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
            Dim pdb As New Rfc2898DeriveBytes(key, slt)
            Dim bytDerivedKey() As Byte = pdb.GetBytes(24)
            crp.Key = bytDerivedKey
            crp.IV = pdb.GetBytes(8)

            Dim csDecrypted As New CryptoStream(stmCipherText, crp.CreateDecryptor(), CryptoStreamMode.Read)
            Dim sw As New StreamWriter(stmPlainText)
            Dim sr As New StreamReader(csDecrypted)
            sw.Write(sr.ReadToEnd)
            sw.Flush()
            csDecrypted.Clear()
            crp.Clear()
            Return uEncode.GetString(stmPlainText.ToArray())
        Catch ex As Exception
            Throw
        End Try
    End Function
End Module
