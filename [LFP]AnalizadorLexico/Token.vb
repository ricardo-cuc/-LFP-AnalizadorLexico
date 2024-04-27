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
            LIBRERIA ' Nuevo tipo de token para manejar #include y similares
        End Enum

        ' Propiedades de la clase Token
        Public Property TipoToken As Tipo
        Public Property Valor As String

        ' Constructor de la clase
        Public Sub New(ByVal tipo As Tipo, ByVal valor As String)
            Try
                Me.TipoToken = tipo
                Me.Valor = valor
            Catch ex As Exception
                Console.WriteLine($"Error al crear el token: {ex.Message}")
            End Try
        End Sub

        ' Métodos de acceso a propiedades
        Public Function ObtenerTipo() As Tipo
            Return TipoToken
        End Function

        Public Function ObtenerValor() As String
            Return Valor
        End Function

        ' Método para obtener la representación en cadena del tipo de token
        Public Function ObtenerTipoComoCadena() As String
            Try
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
                        Return "Librería" ' Nueva entrada para manejar el tipo LIBRERIA
                    Case Else
                        Return "Desconocido"
                End Select
            Catch ex As Exception
                Console.WriteLine($"Error al obtener la cadena del tipo de token: {ex.Message}")
                Return "Error"
            End Try
        End Function
    End Class
End Namespace
