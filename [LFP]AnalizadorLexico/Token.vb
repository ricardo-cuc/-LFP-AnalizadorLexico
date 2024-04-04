Public Class Token
    ' Tipos de tokens reconocidos por el analizador
    Enum Tipo
        SONIDO_DO
        SONIDO_RE
        SONIDO_MI
        SONIDO_FA
        SONIDO_SOL
        SONIDO_LA
        SONIDO_SI
        NO_VALIDO ' Nuevo tipo para caracteres no válidos
    End Enum

    ' Atributo que almacena el tipo de token
    Private tipoToken As Tipo
    ' Atributo que almacena el valor específico que fue reconocido, el lexema
    Private valor As String

    ' Constructor de la clase
    Public Sub New(ByVal tipo As Tipo, ByVal auxLex As String)
        Me.tipoToken = tipo
        Me.valor = auxLex
    End Sub

    ' Función que devuelve el valor almacenado, es decir, el lexema
    Public Function getValor() As String
        Return valor
    End Function

    ' Función utilizada para devolver en cadena el tipo específico del token
    Public Function getTipoEnString() As String
        Select Case tipoToken
            Case Tipo.SONIDO_DO
                Return "Sonido DO"
            Case Tipo.SONIDO_RE
                Return "Sonido RE"
            Case Tipo.SONIDO_MI
                Return "Sonido MI"
            Case Tipo.SONIDO_FA
                Return "Sonido FA"
            Case Tipo.SONIDO_SOL
                Return "Sonido SOL"
            Case Tipo.SONIDO_LA
                Return "Sonido LA"
            Case Tipo.SONIDO_SI
                Return "Sonido SI"
            Case Tipo.NO_VALIDO ' Nuevo caso para caracteres no válidos
                Return "Caracter no válido"
            Case Else
                Return "Desconocido"
        End Select
    End Function
End Class
