Imports System.Collections.Generic
Imports _LFP_AnalizadorLexico.Analisis

Public Class AnalizadorLexico
    ' Variable que representa la lista de tokens
    Private salida As List(Of Token)

    ' Listas de palabras clave, operadores y símbolos especiales de C++
    Private palabrasClave As HashSet(Of String) = New HashSet(Of String) From {"#include", "using", "int", "double", "char", "class", "public", "private", "while", "if", "else", "return"}
    Private operadores As HashSet(Of String) = New HashSet(Of String) From {"<", ">", "=", "+", "-", "*", "/", "!", "&", "|", "^", "~", "%", "<<", ">>"}
    Private simbolosEspeciales As HashSet(Of Char) = New HashSet(Of Char) From {"{", "}", "(", ")", ";", ",", "."}

    ' Método utilizado para realizar el análisis léxico
    Public Function Escanear(ByVal entrada As String) As List(Of Token)
        ' Añade un espacio adicional para facilitar el análisis
        entrada &= " "
        salida = New List(Of Token)
        Dim lexema As String = ""
        Dim estadoEnLiteral As Boolean = False

        Try
            For i As Integer = 0 To entrada.Length - 1
                Dim c As Char = entrada(i)

                ' Manejo de literales de cadena
                If c = """" Then
                    ' Si ya estaba en un literal, finaliza el literal
                    If estadoEnLiteral Then
                        lexema &= c
                        salida.Add(New Token(Token.Tipo.LITERAL, lexema))
                        lexema = ""
                        estadoEnLiteral = False
                    Else
                        ' Comienza un nuevo literal
                        lexema &= c
                        estadoEnLiteral = True
                    End If
                ElseIf Char.IsWhiteSpace(c) AndAlso Not estadoEnLiteral Then
                    ' Si es un espacio fuera de un literal, agrega el token correspondiente al lexema actual
                    If lexema <> "" Then
                        AgregarToken(lexema)
                        lexema = ""
                    End If
                ElseIf estadoEnLiteral Then
                    ' Si está dentro de un literal, agregarlo al lexema actual
                    lexema &= c
                ElseIf simbolosEspeciales.Contains(c) Then
                    ' Si es un símbolo especial, agrégalo como token correspondiente
                    salida.Add(New Token(Token.Tipo.SIMBOLO_ESPECIAL, c.ToString()))
                ElseIf operadores.Contains(c.ToString()) Then
                    ' Si es un operador, agrégalo como token correspondiente
                    salida.Add(New Token(Token.Tipo.OPERADOR, c.ToString()))
                ElseIf c = "<" OrElse c = ">" Then
                    ' Manejar operadores dobles << y >>
                    If i + 1 < entrada.Length AndAlso entrada(i + 1) = c Then
                        lexema &= c
                        lexema &= entrada(i + 1)
                        salida.Add(New Token(Token.Tipo.OPERADOR, lexema))
                        i += 1 ' Avanza el índice para manejar operadores dobles
                        lexema = ""
                    Else
                        salida.Add(New Token(Token.Tipo.OPERADOR, c.ToString()))
                    End If
                ElseIf Char.IsLetterOrDigit(c) Then
                    lexema &= c
                Else
                    ' Maneja otros caracteres no válidos
                    salida.Add(New Token(Token.Tipo.NO_VALIDO, c.ToString()))
                End If
            Next

            ' Si hay algún lexema restante al final, agréguelo como token
            If lexema <> "" Then
                AgregarToken(lexema)
            End If

        Catch ex As Exception
            ' Manejar cualquier excepción durante el análisis léxico
            Console.WriteLine($"Error durante el análisis léxico: {ex.Message}")
            ' Puedes manejar la excepción de acuerdo a tus necesidades, por ejemplo, agregar un token de error
        End Try

        Return salida
    End Function

    ' Método utilizado para agregar tokens a la lista de tokens
    Private Sub AgregarToken(ByVal lexema As String)
        ' Verifica si el lexema es una palabra clave
        If palabrasClave.Contains(lexema) Then
            salida.Add(New Token(Token.Tipo.PALABRA_CLAVE, lexema))
            ' Verifica si es un operador
        ElseIf operadores.Contains(lexema) Then
            salida.Add(New Token(Token.Tipo.OPERADOR, lexema))
            ' Verifica si es un identificador
        ElseIf Char.IsLetterOrDigit(lexema(0)) Then
            salida.Add(New Token(Token.Tipo.IDENTIFICADOR, lexema))
            ' Verifica si es un literal
        ElseIf lexema.StartsWith("""") AndAlso lexema.EndsWith("""") Then
            salida.Add(New Token(Token.Tipo.LITERAL, lexema))
        Else
            salida.Add(New Token(Token.Tipo.NO_VALIDO, lexema))
        End If
    End Sub
End Class
