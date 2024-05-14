Imports System.Collections.Generic

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
            Return $"Error en línea {Linea}, columna {Columna}: {Mensaje}"
        End Function
    End Class

    ' Clase para realizar el análisis sintáctico de una lista de tokens
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

            ' Inicia el análisis sintáctico
            While indiceActual < tokens.Count
                Try
                    ' Lógica para analizar las declaraciones
                    AnalizarDeclaracion()
                Catch ex As Exception
                    ' Captura cualquier excepción y registra un error sintáctico
                    Dim tokenActual As Token = tokens(indiceActual)
                    erroresSintacticos.Add(New ErrorSintactico(ex.Message, tokenActual.Linea, tokenActual.Columna))
                    ' Avanza al siguiente token
                    indiceActual += 1
                End Try
            End While

            ' Retorna true si no se encontraron errores, false si hubo errores
            Return erroresSintacticos.Count = 0
        End Function

        ' Método para analizar una declaración
        Private Sub AnalizarDeclaracion()
            ' Lógica para analizar declaraciones
            ' Por ejemplo, análisis de funciones, variables, etc.
            ' Puedes añadir lógica aquí para manejar casos específicos.

            ' Avanza al siguiente token después de analizar la declaración
            indiceActual += 1
        End Sub

        ' Método para obtener la lista de errores sintácticos
        Public Function ObtenerErroresSintacticos() As List(Of ErrorSintactico)
            Return erroresSintacticos
        End Function
    End Class
End Namespace
