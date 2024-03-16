Imports System.Collections.Generic

Public Class Form1
    ' Se carga un texto de ejemplo para ser analizado
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEntrada.Text = "si x > 5:" & vbCrLf & "para i in rango(10):" & vbCrLf & "print(i)" & vbCrLf & "sino:" & vbCrLf & "mientras y < 100:" & vbCrLf & "y += 10"
    End Sub

    ' Cuando se presiona el botón, se realiza el análisis léxico
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim entrada As String = txtEntrada.Text
        ' Proceso de análisis léxico
        Dim analizador As New AnalizadorLexico()
        Dim listaTokens As List(Of Token) = analizador.escanear(entrada)

        ' Limpiar el cuadro de texto de salida antes de agregar los nuevos tokens
        txtSalida.Text = ""

        ' Agregar cada token al cuadro de texto de salida
        For Each token As Token In listaTokens
            txtSalida.AppendText(token.getTipoEnString() & "  <-->  " & token.getValor() & vbCrLf)
        Next
    End Sub
End Class
