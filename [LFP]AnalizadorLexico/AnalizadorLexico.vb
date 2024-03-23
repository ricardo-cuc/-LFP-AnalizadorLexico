Public Function escanear(ByVal entrada As String) As List(Of Token)
    ' Agrego caracter de fin de cadena porque hay lexemas que aceptan con 
    ' el primer caracter del siguiente lexema y si este caracter no existe entonces
    ' perdemos el lexema
    entrada = entrada + "#"
    salida = New List(Of Token)
    estado = 0
    auxLex = ""
    Dim c As Char
    ' Ciclo que recorre de izquierda a derecha caracter por caracter la cadena de entrada
    For i As Integer = 0 To entrada.Length - 1 Step 1
        c = entrada.Chars(i)
        ' Select en el que cada caso representa cada uno de los estados del conjunto de estados
        Select Case estado
            Case 0
                ' Para cada caso (o estado) hay un if elseif elseif ... else que representan el conjunto de transiciones que 
                ' salen de dicho estado, por ejemplo, estando en el estado 0 si el caracter reconocido es un dígito entonces, 
                ' pasamos al estado 1 y acumulamos el caracter reconocido en auxLex, que es el auxiliar de lexemas.
                If Char.IsDigit(c) Then
                    estado = 1
                    auxLex += c
                ElseIf (c = "(") Then
                    auxLex += c
                    addToken(Token.Tipo.PARENTESIS_IZQ)
                ElseIf (c = ")") Then
                    auxLex += c
                    addToken(Token.Tipo.PARENTESIS_DER)
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
                    If (c = " " Or c = vbCr Or c = vbLf Or c = vbCrLf Or c = vbTab) Then
                        addToken(Token.Tipo.NUMERO_ENTERO)
                    Else
                        Console.WriteLine("Error léxico con: " + c)
                    End If
                    i -= 1
                End If
        End Select
    Next
    Return salida
End Function
