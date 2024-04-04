Imports System.Collections.Generic

Public Class AnalizadorLexico
    ' Variable que representa la lista de tokens
    Private salida As List(Of Token)

    ' Método utilizado para realizar el análisis léxico
    Public Function Escanear(ByVal entrada As String) As List(Of Token)
        ' Agrego caracter de fin de cadena porque hay lexemas que aceptan con 
        ' el primer caracter del siguiente lexema y si este caracter no existe entonces
        ' perdemos el lexema
        entrada &= " "
        salida = New List(Of Token)
        Dim lexema As String = ""

        For Each c As Char In entrada
            If Char.IsWhiteSpace(c) Then
                ' Si es un espacio, agregar el token correspondiente al lexema actual
                If lexema <> "" Then
                    AgregarToken(lexema)
                    lexema = ""
                End If
            ElseIf EsCaracterValido(c) Then
                ' Si el caracter es válido, agregarlo al lexema actual
                lexema &= c
            Else
                ' Si es un caracter no válido, marcar como error léxico
                Console.WriteLine("Caracter no válido: " & c)
            End If
        Next

        Return salida
    End Function

    ' Método utilizado para agregar Tokens a la lista de tokens
    Private Sub AgregarToken(ByVal lexema As String)
        ' Se decide qué tipo de token agregar dependiendo del lexema
        Select Case lexema
            Case "DO"
                salida.Add(New Token(Token.Tipo.SONIDO_DO, lexema))
            Case "RE"
                salida.Add(New Token(Token.Tipo.SONIDO_RE, lexema))
            Case "MI"
                salida.Add(New Token(Token.Tipo.SONIDO_MI, lexema))
            Case "FA"
                salida.Add(New Token(Token.Tipo.SONIDO_FA, lexema))
            Case "SOL"
                salida.Add(New Token(Token.Tipo.SONIDO_SOL, lexema))
            Case "LA"
                salida.Add(New Token(Token.Tipo.SONIDO_LA, lexema))
            Case "SI"
                salida.Add(New Token(Token.Tipo.SONIDO_SI, lexema))
            Case Else
                salida.Add(New Token(Token.Tipo.NO_VALIDO, lexema))
        End Select
    End Sub

    ' Método para verificar si un caracter es válido
    Private Function EsCaracterValido(ByVal c As Char) As Boolean
        Dim caracteresValidos As String = "DOREMIFASOLSILA" ' Se incluyen las notas musicales
        Return caracteresValidos.Contains(c)
    End Function
End Class
