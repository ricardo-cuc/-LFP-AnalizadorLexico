Imports System.Collections.Generic
Imports System.Windows.Forms
Imports _LFP_AnalizadorLexico.Analisis

Public Class Form1
    ' Evento que se ejecuta cuando se carga el formulario
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configura un ejemplo de código C++ para el análisis
        txtEntrada.Text = "#include <iostream>" & vbCrLf &
                          "using namespace std;" & vbCrLf &
                          "int main()" & vbCrLf &
                          "{" & vbCrLf &
                          "    cout << ""Hola, mundo!"" << endl;" & vbCrLf &
                          "    return 0;" & vbCrLf &
                          "}"
    End Sub

    ' Evento que se ejecuta cuando se presiona el botón para realizar el análisis léxico y sintáctico
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtiene la entrada del usuario (código C++)
        Dim entrada As String = txtEntrada.Text

        ' Inicializa el analizador léxico
        Dim analizadorLexico As New AnalizadorLexico()
        ' Realiza el análisis léxico de la entrada
        Dim listaTokens As List(Of Token) = analizadorLexico.Escanear(entrada)

        ' Limpia los cuadros de texto de salida antes de agregar los nuevos tokens
        txtSalida.Clear()
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
        txtSintaxis.Clear()
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
        txtSintaxis.Clear()
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
        txtSintaxis.Clear()
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
        txtSintaxis.Clear()
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d

        ' Recorre la lista de tokens y los muestra en el cuadro de texto de salida
        For Each token As Token In listaTokens
            txtSalida.AppendText($"{token.ObtenerTipoComoCadena()}  <-->  {token.Valor}{vbCrLf}")
        Next

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        ' Realiza el análisis sintáctico
=======
=======
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
=======
>>>>>>> 7db3361e926fdac4b153158bb0f4236f3dd5c24d
        ' Inicializa el analizador sintáctico con la lista de tokens
        Dim analizadorSintactico As New AnalizadorSintactico(listaTokens)

        ' Realiza el análisis sintáctico
        Dim esSintaxisCorrecta As Boolean
        Try
            esSintaxisCorrecta = analizadorSintactico.Analizar()
            If esSintaxisCorrecta Then
                txtSintaxis.AppendText("El programa es sintácticamente correcto." & vbCrLf)
            Else
                txtSintaxis.AppendText("El programa tiene errores de sintaxis." & vbCrLf)
                ' Mostrar detalles de los errores
                Dim list = DirectCast(analizadorSintactico.ObtenerErroresSintacticos(), IList)

                For i = 0 To list.Count - 1
                    Dim errorSintactico As ErrorSintactico = DirectCast(list(i), ErrorSintactico)
                    txtSintaxis.AppendText($"{errorSintactico}{vbCrLf}")
                Next
            End If
        Catch ex As Exception
            ' Manejar cualquier excepción inesperada
            txtSintaxis.AppendText("Error de análisis sintáctico: " & ex.Message & vbCrLf)
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtSintaxis.TextChanged

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
    End Sub
End Class
