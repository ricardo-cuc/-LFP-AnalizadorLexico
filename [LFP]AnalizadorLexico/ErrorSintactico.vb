Public Class ErrorSintactico
    Public Property Linea As Integer
    Public Property Columna As Integer
    Public Property Descripcion As String

    Public Sub New(linea As Integer, columna As Integer, descripcion As String)
        Me.Linea = linea
        Me.Columna = columna
        Me.Descripcion = descripcion
    End Sub

    Public Overrides Function ToString() As String
        Return $"Error de sintaxis en línea {Linea}, columna {Columna}: {Descripcion}"
    End Function
End Class
