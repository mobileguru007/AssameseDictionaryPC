Public NotInheritable Class SplashScreen

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        'If My.Application.Info.Title <> "" Then
        '    ApplicationTitle.Text = My.Application.Info.Title
        'Else
        '    'If the application title is missing, use the application name, without the extension
        '    ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        'End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        getConn()
        'Dim myStr As String = Nothing
        'myStr = "SELECT ID, Fakara FROM FakaTable" ' WHERE SearchChar='" & myval & "' ORDER BY ID ASC"
        'Dim objCmd As New Data.OleDb.OleDbCommand(myStr, objConn)
        'Dim rs As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        'If rs.HasRows Then
        Label1.Text = Registeredto
        'End If
      




        Version.Text = "সংস্কৰণ ৩.০" 'System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        Version.Font = New System.Drawing.Font("Asomiya_Rohini", 16.3!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright

        Timer1.Start()
        Label3.Text = "সাজু হোৱালৈকে খন্তেক অপেক্ষা কৰক..."
        Label3.Font = New System.Drawing.Font("Times New Roman", 15.3!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim strConnString As String
            strConnString = "Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" & "|DataDirectory|\" & "PINCodes.xlsx" & ";"

            Dim strSQL As String
            strSQL = "SELECT * FROM [" & "Sheet1" & "$]"

            Dim y As New Odbc.OdbcDataAdapter(strSQL, strConnString)

            y.Fill(dtPinCod)
            'Label1.Text = "wait please.."

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        Label3.Text = ""
        Timer1.Stop()

        Me.Hide()
        frmMain.ShowDialog()
        Me.Close()
    End Sub

    
    
End Class
