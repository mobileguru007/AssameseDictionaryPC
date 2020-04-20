Imports System.Data.OleDb
Imports System.Data

Public Class DAL
   'Dim objConn As OleDbConnection = New OleDbConnection(My.Settings.conn)

    Public Function setData(ByVal objCmd As OleDbCommand) As Boolean
        Try
            objCmd.Connection = objConn
            objConn.Open()
            objCmd.ExecuteNonQuery()
            objConn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function getData(ByVal objCmd As OleDbCommand) As DataSet
        Dim ds As New DataSet
        Try
            objCmd.Connection = objConn
            Dim objAdpt As New OleDbDataAdapter(objCmd)
            objAdpt.Fill(ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function
End Class
