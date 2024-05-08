Namespace Analisis
    Public Class Token
        ' Definición de tipos de tokens
        Enum Tipo
            PALABRA_CLAVE
            IDENTIFICADOR
            LITERAL
            OPERADOR
            SIMBOLO_ESPECIAL
            NO_VALIDO
            LIBRERIA
            NUMERO
            CADENA
            COMENTARIO
            OTRO
            VARIABLE  ' Nuevo tipo de token para manejar variables
        End Enum

        ' Propiedades de la clase Token
        Public Property TipoToken As Tipo
        Public Property Valor As String
        Public Property Linea As Integer
        Public Property Columna As Integer

        ' Constructor de la clase
        Public Sub New(ByVal tipo As Tipo, ByVal valor As String)
            Me.TipoToken = tipo
            Me.Valor = valor
        End Sub

        ' Método para obtener la representación en cadena del tipo de token
        Public Function ObtenerTipoComoCadena() As String
            Select Case TipoToken
                Case Tipo.PALABRA_CLAVE
                    Return "Palabra clave"
                Case Tipo.IDENTIFICADOR
                    Return "Identificador"
                Case Tipo.LITERAL
                    Return "Literal"
                Case Tipo.OPERADOR
                    Return "Operador"
                Case Tipo.SIMBOLO_ESPECIAL
                    Return "Símbolo especial"
                Case Tipo.NO_VALIDO
                    Return "Caracter no válido"
                Case Tipo.LIBRERIA
                    Return "Librería"
                Case Tipo.VARIABLE
                    Return "Variable"  ' Representación en cadena para variables
                Case Else
                    Return "Desconocido"
            End Select
        End Function
    End Class
End Namespace
