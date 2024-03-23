Imports System.Collections.Generic

Public Class AnalizadorLexico
    ' Variable que representa la lista de tokens
    Private salida As List(Of Token)
    ' Variable que representa el estado actual
    Private estado As Integer
    ' Variable que representa el lexema que actualmente se está acumulando
    Private auxLex As String
    ' Lista de caracteres válidos
    Private caracteresValidos As String = "[]()+-*/134689" ' Solo se consideran caracteres válidos

    ' Método utilizado para realizar el análisis léxico
    Public Function Escanear(ByVal entrada As String) As List(Of Token)
        ' Agrego caracter de fin de cadena porque hay lexemas que aceptan con 
        ' el primer caracter del siguiente lexema y si este caracter no existe entonces
        ' perdemos el lexema
        entrada = entrada
        salida = New List(Of Token)
        estado = 0
        auxLex = ""
        Dim c As Char
        ' Ciclo que recorre de izquierda a derecha caracter por caracter la cadena de entrada
        For i As Integer = 0 To entrada.Length - 1 Step 1
            c = entrada.Chars(i)
            ' Verificar si el caracter es válido
            If EsCaracterValido(c) Then
                ' Select en el que cada caso representa cada uno de los estados del conjunto de estados
                Select Case estado
                    Case 0
                        ' Para cada caso (o estado) hay un if elseif elseif ... else que representan el conjunto de transiciones que 
                        ' salen de dicho estado, por ejemplo, estando en el estado 0 si el caracter reconocido es un dígito entonces, 
                        ' pasamos al estado 1 y acumulamos el caracter reconocido en auxLex, que es el auxiliar de lexemas.
                        If Char.IsDigit(c) Then
                            estado = 1
                            auxLex += c
                        ElseIf (c = "+") Then
                            auxLex += c
                            addToken(Token.Tipo.SIGNO_MAS)
                        ElseIf (c = "-") Then
                            auxLex += c
                            addToken(Token.Tipo.SIGNO_MEN)
                        ElseIf (c = "*") Then
                            auxLex += c
                            addToken(Token.Tipo.SIGNO_POR)
                        ElseIf (c = "/") Then
                            auxLex += c
                            addToken(Token.Tipo.SIGNO_DIV)

                        ElseIf (c = "[") Then
                            auxLex += c
                            addToken(Token.Tipo.CORCHETE_IZQ)
                        ElseIf (c = "]") Then
                            auxLex += c
                            addToken(Token.Tipo.CORCHETE_DER)
                        ElseIf (c = "(") Then
                            auxLex += c
                            addToken(Token.Tipo.PARENTESIS_IZQ)
                        ElseIf (c = ")") Then
                            auxLex += c
                            addToken(Token.Tipo.PARENTESIS_DER)
                        ElseIf (c = " " Or c = vbCr Or c = vbLf Or c = vbCrLf Or c = vbTab) Then

                        Else
                            If (c = "#" And i = entrada.Length() - 1) Then
                                ' Hemos concluido el análisis léxico.
                                Console.WriteLine("Hemos concluido el análisis léxico satisfactoriamente")
                            Else
                                Console.WriteLine("Error léxico con: " + c)
                                estado = 0
                            End If
                        End If
                    Case 1
                        If (Char.IsDigit(c)) Then
                            estado = 1
                            auxLex += c
                        Else
                            addToken(Token.Tipo.NUMERO_ENTERO)
                            i -= 1
                        End If
                End Select
            Else
                ' Si el caracter no es válido, agregar token de tipo NO_VALIDO
                addToken(Token.Tipo.NO_VALIDO)
                Console.WriteLine("Caracter no válido: " & c)
            End If
        Next
        Return salida
    End Function

    ' Método utilizado para agregar Tokens a la lista de tokens
    Private Sub addToken(ByVal tipo As Token.Tipo)
        salida.Add(New Token(tipo, auxLex))
        auxLex = ""
        estado = 0
    End Sub

    ' Método para verificar si un caracter es válido
    Private Function EsCaracterValido(ByVal c As Char) As Boolean
        Return caracteresValidos.Contains(c)
    End Function

    ' Método para obtener caracteres no válidos en la entrada
    Public Function ObtenerCaracteresNoValidos(ByVal entrada As String) As List(Of Char)
        Dim caracteresNoValidos As New List(Of Char)
        For Each c As Char In entrada
            If Not EsCaracterValido(c) Then
                caracteresNoValidos.Add(c)
            End If
        Next
        Return caracteresNoValidos
    End Function
End Class
