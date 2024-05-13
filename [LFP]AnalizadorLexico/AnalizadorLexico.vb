Imports System.Collections.Generic
Imports _LFP_AnalizadorLexico.Analisis
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
Imports Analisis
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
Imports Analisis
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
Imports Analisis
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
Imports Analisis
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d

Public Class AnalizadorLexico
    ' Lista de tokens
    Private salida As List(Of Token) = New List(Of Token)()

    ' Conjuntos de palabras clave, operadores y símbolos especiales de C++
    Private palabrasClave As HashSet(Of String) = New HashSet(Of String) From {"using", "int", "double", "char", "bool", "class", "public", "private", "while", "if", "else", "return", "float"}
    Private operadores As HashSet(Of String) = New HashSet(Of String) From {"<", ">", "=", "+", "-", "*", "/", "!", "&", "|", "^", "~", "%", "<<", ">>", "++", "--"}
    Private simbolosEspeciales As HashSet(Of Char) = New HashSet(Of Char) From {"{", "}", "(", ")", ";", ",", "."}

    ' Método para realizar el análisis léxico
    Public Function Escanear(ByVal entrada As String) As List(Of Token)
        ' Añade un espacio adicional al final para facilitar el análisis
        entrada &= " "
        salida.Clear()  ' Limpia la lista de salida antes de empezar a escanear

        ' Variables para el análisis
        Dim lexema As String = ""
        Dim estadoEnLiteral As Boolean = False
        Dim i As Integer = 0

        ' Procesar la entrada carácter por carácter
        While i < entrada.Length
            Dim c As Char = entrada(i)

            ' Manejo de directivas de preprocesador
            If c = "#" Then
                lexema = c.ToString()
                i += 1

                ' Continúa hasta el final de la línea
                While i < entrada.Length AndAlso Not (entrada(i) = vbLf OrElse entrada(i) = vbCr)
                    lexema &= entrada(i)
                    i += 1
                End While

                ' Clasifica la línea completa como Librería
                salida.Add(New Token(Token.Tipo.LIBRERIA, lexema))
                Continue While
            End If

            ' Manejo de literales de cadena
            If c = """" Then
                lexema &= c
                If estadoEnLiteral Then
                    salida.Add(New Token(Token.Tipo.LITERAL, lexema))
                    lexema = ""
                    estadoEnLiteral = False
                Else
                    estadoEnLiteral = True
                End If
            ElseIf estadoEnLiteral Then
                ' Si está dentro de un literal, agregarlo al lexema actual
                lexema &= c
            ElseIf Char.IsWhiteSpace(c) Then
                ' Maneja el final de un lexema
                If lexema <> "" Then
                    AgregarToken(lexema)
                    lexema = ""
                End If
            ElseIf simbolosEspeciales.Contains(c) Then
                ' Si es un símbolo especial, agrégalo como token correspondiente
                salida.Add(New Token(Token.Tipo.SIMBOLO_ESPECIAL, c.ToString()))
            ElseIf operadores.Contains(c.ToString()) Then
                ' Si es un operador, agrégalo como token correspondiente
                salida.Add(New Token(Token.Tipo.OPERADOR, c.ToString()))
            ElseIf Char.IsLetterOrDigit(c) Then
                lexema &= c
            Else
                ' Si se encuentra un carácter no válido
                If lexema <> "" Then
                    AgregarToken(lexema)
                    lexema = ""
                End If
                ' Agregar el carácter como token no válido
                salida.Add(New Token(Token.Tipo.NO_VALIDO, c.ToString()))
            End If
            i += 1
        End While

        ' Si hay un lexema restante al final de la entrada, agrégalo como token
        If lexema <> "" Then
            AgregarToken(lexema)
        End If

        Return salida
    End Function

    ' Método para agregar tokens a la lista de tokens
    Private Sub AgregarToken(ByVal lexema As String)
        ' Verifica si el lexema es una palabra clave
        If palabrasClave.Contains(lexema) Then
            salida.Add(New Token(Token.Tipo.PALABRA_CLAVE, lexema))
        ElseIf operadores.Contains(lexema) Then
            salida.Add(New Token(Token.Tipo.OPERADOR, lexema))
        ElseIf lexema.StartsWith("""") AndAlso lexema.EndsWith("""") Then
            salida.Add(New Token(Token.Tipo.LITERAL, lexema))
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        ElseIf lexema.StartsWith("using") Then
            salida.Add(New Token(Token.Tipo.PALABRA_CLAVE, lexema))
        ElseIf lexema.StartsWith("#include") Then
            salida.Add(New Token(Token.Tipo.LIBRERIA, lexema))
        ElseIf lexema.StartsWith("int") OrElse lexema.StartsWith("double") OrElse lexema.StartsWith("char") OrElse lexema.StartsWith("bool") OrElse lexema.StartsWith("float") Then
            ' Si el lexema comienza con un tipo de dato, considerarlo como una posible declaración de variable
            salida.Add(New Token(Token.Tipo.PALABRA_CLAVE, lexema))
        ElseIf lexema.StartsWith("return") Then
            salida.Add(New Token(Token.Tipo.PALABRA_CLAVE, lexema))
        ElseIf lexema.StartsWith("endl") Then
            salida.Add(New Token(Token.Tipo.IDENTIFICADOR, lexema)) ' Corregir aquí
        ElseIf Char.IsLetterOrDigit(lexema(0)) Then
            ' Verifica si hay un tipo de dato antes del lexema actual, seguido de un identificador y un operador de asignación
            Dim esVariable As Boolean = False

            ' Verifica si el lexema es precedido por un tipo de dato, seguido por un identificador y un operador de asignación
            For i As Integer = salida.Count - 1 To 0 Step -1
                If salida(i).TipoToken = Token.Tipo.PALABRA_CLAVE AndAlso palabrasClave.Contains(salida(i).Valor) AndAlso i < salida.Count - 2 AndAlso salida(i + 1).TipoToken = Token.Tipo.IDENTIFICADOR AndAlso salida(i + 2).Valor = "=" Then
                    esVariable = True
                    Exit For
                ElseIf salida(i).TipoToken <> Token.Tipo.IDENTIFICADOR Then
                    esVariable = False
                    Exit For
                End If
            Next

            ' Agrega el lexema como una variable o identificador según el resultado anterior
            If esVariable Then
                salida.Add(New Token(Token.Tipo.VARIABLE, lexema))
            Else
                salida.Add(New Token(Token.Tipo.IDENTIFICADOR, lexema))
            End If
        Else
            salida.Add(New Token(Token.Tipo.NO_VALIDO, lexema))
        End If
    End Sub


=======
        ElseIf Char.IsLetterOrDigit(lexema(0)) Then
            ' Verifica si hay palabras clave antes del lexema actual, lo que podría indicar la declaración de una variable
            Dim esVariable As Boolean = False

            ' Verifica si el lexema es precedido por una palabra clave
            For i As Integer = salida.Count - 1 To 0 Step -1
                If salida(i).TipoToken = Token.Tipo.PALABRA_CLAVE Then
                    esVariable = True
                    Exit For
                ElseIf salida(i).TipoToken <> Token.Tipo.IDENTIFICADOR Then
                    esVariable = False
                    Exit For
                End If
            Next

=======
        ElseIf Char.IsLetterOrDigit(lexema(0)) Then
            ' Verifica si hay palabras clave antes del lexema actual, lo que podría indicar la declaración de una variable
            Dim esVariable As Boolean = False

            ' Verifica si el lexema es precedido por una palabra clave
            For i As Integer = salida.Count - 1 To 0 Step -1
                If salida(i).TipoToken = Token.Tipo.PALABRA_CLAVE Then
                    esVariable = True
                    Exit For
                ElseIf salida(i).TipoToken <> Token.Tipo.IDENTIFICADOR Then
                    esVariable = False
                    Exit For
                End If
            Next

>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
        ElseIf Char.IsLetterOrDigit(lexema(0)) Then
            ' Verifica si hay palabras clave antes del lexema actual, lo que podría indicar la declaración de una variable
            Dim esVariable As Boolean = False

            ' Verifica si el lexema es precedido por una palabra clave
            For i As Integer = salida.Count - 1 To 0 Step -1
                If salida(i).TipoToken = Token.Tipo.PALABRA_CLAVE Then
                    esVariable = True
                    Exit For
                ElseIf salida(i).TipoToken <> Token.Tipo.IDENTIFICADOR Then
                    esVariable = False
                    Exit For
                End If
            Next

>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
        ElseIf Char.IsLetterOrDigit(lexema(0)) Then
            ' Verifica si hay palabras clave antes del lexema actual, lo que podría indicar la declaración de una variable
            Dim esVariable As Boolean = False

            ' Verifica si el lexema es precedido por una palabra clave
            For i As Integer = salida.Count - 1 To 0 Step -1
                If salida(i).TipoToken = Token.Tipo.PALABRA_CLAVE Then
                    esVariable = True
                    Exit For
                ElseIf salida(i).TipoToken <> Token.Tipo.IDENTIFICADOR Then
                    esVariable = False
                    Exit For
                End If
            Next

>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
            ' Agrega el lexema como una variable o identificador según el resultado anterior
            If esVariable Then
                salida.Add(New Token(Token.Tipo.VARIABLE, lexema))
            Else
                salida.Add(New Token(Token.Tipo.IDENTIFICADOR, lexema))
            End If
        Else
            salida.Add(New Token(Token.Tipo.NO_VALIDO, lexema))
        End If
    End Sub
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
End Class
