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
                          "    cout << \Hola, mundo!\ << endl;" & vbCrLf &
                          "    return 0;" & vbCrLf &
                          "}"
    End Sub

    ' Evento que se ejecuta cuando se presiona el botón para realizar el análisis léxico
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Obtiene la entrada del usuario (código C++)
        Dim entrada As String = txtEntrada.Text
        ' Inicializa el analizador léxico
        Dim analizador As New AnalizadorLexico()
        ' Realiza el análisis léxico de la entrada
        Dim listaTokens As List(Of Token) = analizador.Escanear(entrada)

        ' Limpia el cuadro de texto de salida antes de agregar los nuevos tokens
        txtSalida.Clear()

        ' Recorre la lista de tokens y los muestra en el cuadro de texto de salida
        For Each token As Token In listaTokens
            ' Utiliza los métodos correctos definidos en `Token`
            txtSalida.AppendText($"{token.ObtenerTipoComoCadena()}  <-->  {token.ObtenerValor()}{vbCrLf}")
        Next
    End Sub

End Class
