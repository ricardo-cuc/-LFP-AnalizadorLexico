Imports System.Collections.Generic
Imports _LFP_AnalizadorLexico.Analisis.Token

Namespace Analisis
    ' Clase para representar un error sintáctico
    Public Class ErrorSintactico
        Public Property Mensaje As String
        Public Property Linea As Integer
        Public Property Columna As Integer

        ' Constructor de la clase ErrorSintactico
        Public Sub New(mensaje As String, linea As Integer, columna As Integer)
            Me.Mensaje = mensaje
            Me.Linea = linea
            Me.Columna = columna
        End Sub

        ' Método para obtener la representación en cadena del error
        Public Overrides Function ToString() As String
            Return $"Error en la línea {Linea}, columna {Columna}: {Mensaje}"
        End Function
    End Class

    ' Clase AnalizadorSintactico para realizar el análisis sintáctico de una lista de tokens
    Public Class AnalizadorSintactico
        Private ReadOnly tokens As List(Of Token)
        Private indiceActual As Integer
        Private erroresSintacticos As List(Of ErrorSintactico)

        ' Constructor del analizador sintáctico
        Public Sub New(tokens As List(Of Token))
            Me.tokens = tokens
            Me.indiceActual = 0
            Me.erroresSintacticos = New List(Of ErrorSintactico)()
        End Sub

        ' Método para analizar la lista de tokens
        Public Function Analizar() As Boolean
            ' Inicializa la lista de errores sintácticos
            erroresSintacticos.Clear()

            ' Iniciar el análisis sintáctico desde el token actual
            While indiceActual < tokens.Count
                Try
                    AnalizarDeclaracion()
                Catch ex As Exception
                    ' Captura cualquier excepción durante el análisis y agrega un error sintáctico
                    Dim tokenActual As Token = tokens(indiceActual)
                    erroresSintacticos.Add(New ErrorSintactico(ex.Message, tokenActual.Linea, tokenActual.Columna))
                    ' Avanza al siguiente token para continuar el análisis
                    indiceActual += 1
                End Try
            End While

            ' Retorna true si no se encontraron errores, false de lo contrario
            Return erroresSintacticos.Count = 0
        End Function

        ' Método para analizar una declaración específica
        Private Sub AnalizarDeclaracion()
            ' Lógica para analizar diferentes tipos de declaraciones
            ' Ejemplo: análisis de declaraciones de variables
            If tokens(indiceActual).TipoToken = Tipo.PALABRA_CLAVE Then
                ' Lógica para manejar declaraciones
                ' Ejemplo: verificar la declaración de variables, funciones, etc.
                ' Puedes añadir la lógica para manejar declaraciones específicas aquí.

                ' Avanzar al siguiente token
                indiceActual += 1
            Else
                ' Agregar un error sintáctico si se encuentra un token inesperado
                Dim tokenActual As Token = tokens(indiceActual)
                erroresSintacticos.Add(New ErrorSintactico($"Token inesperado: {tokenActual.Valor}", tokenActual.Linea, tokenActual.Columna))

                ' Avanzar al siguiente token
                indiceActual += 1
            End If
        End Sub

        ' Método para obtener la lista de errores sintácticos encontrados durante el análisis
        Public Function ObtenerErroresSintacticos() As List(Of ErrorSintactico)
            Return erroresSintacticos
        End Function
    End Class
End Namespace
