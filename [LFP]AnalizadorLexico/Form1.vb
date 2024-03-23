Imports System.Collections.Generic
Imports System.Windows.Forms ' Agrega esta importación para usar Windows Forms

Public Class Form1
    ' Se carga un texto de ejemplo para ser analizado
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEntrada.Text = "[(8-9)*8]+ (6-4) / 9 * 1 -3" ' Texto de ejemplo
    End Sub

    ' Cuando se presiona el botón, se realiza el análisis léxico
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim entrada As String = txtEntrada.Text
        ' Proceso de análisis léxico
        Dim analizador As New AnalizadorLexico()
        Dim listaTokens As List(Of Token) = analizador.Escanear(entrada)

        ' Limpiar el cuadro de texto de salida antes de agregar los nuevos tokens
        txtSalida.Text = ""

        ' Agregar cada token al cuadro de texto de salida
        For Each token As Token In listaTokens
            txtSalida.AppendText(token.getTipoEnString() & "  <-->  " & token.getValor() & vbCrLf)
        Next

        ' Mostrar caracteres no válidos
        Dim caracteresNoValidos As List(Of Char) = analizador.ObtenerCaracteresNoValidos(entrada)
        For Each caracter As Char In caracteresNoValidos
            txtSalida.AppendText(Token.Tipo.NO_VALIDO.ToString() & "  <-->  " & caracter & vbCrLf)
        Next
    End Sub
End Class
