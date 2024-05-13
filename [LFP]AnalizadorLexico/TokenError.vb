Public Class TokenError
    ' Propiedades para almacenar la información sobre el error
    Public Property TipoError As String
    Public Property DescripcionError As String
    Public Property Linea As Integer
    Public Property Columna As Integer

    ' Constructor de la clase
    Public Sub New(tipoError As String, descripcionError As String, linea As Integer, columna As Integer)
        Me.TipoError = tipoError
        Me.DescripcionError = descripcionError
        Me.Linea = linea
        Me.Columna = columna
    End Sub

    ' Método para obtener la representación en cadena del error
    Public Overrides Function ToString() As String
        Return $"Error de tipo {TipoError} en la línea {Linea}, columna {Columna}: {DescripcionError}"
    End Function
End Class
