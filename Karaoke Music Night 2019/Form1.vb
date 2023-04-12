Public Class Form1
    Private _decSong As Decimal = 2.99D
    Private _decHourlyRate As Decimal = 8.99D
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Threading.Thread.Sleep(3000)
        ClearForm()
    End Sub
    Private Function ValidateInput() As Boolean
        Dim intNumber As Integer
        Dim blnValid As Boolean = False
        Try
            intNumber = Convert.ToInt32(txtValue.Text)
            If intNumber > 0D Then
                blnValid = True
            Else
                MsgBox("Please enter a number greater than 0", , "Error")
                txtValue.Focus()
                txtValue.Clear()
            End If
        Catch Exception As FormatException
            MsgBox("Please enter a valid amount", , "Error")
            txtValue.Focus()
            txtValue.Clear()
        Catch Exception As OverflowException
            MsgBox("please enter a reasonable amount", , "Error")
            txtValue.Focus()
            txtValue.Clear()
        Catch Exception As SystemException
            MsgBox("Entry invalid. Please enter a valid number representing the number of people in your party", , "Error")
            txtValue.Focus()
            txtValue.Clear()
        End Try
        Return blnValid
    End Function

    Private Function ComputeSongCost(ByVal intPass As Integer) As Decimal
        Dim decPassCost As Decimal
        decPassCost = intPass * _decSong

        Return decPassCost
    End Function

    Private Function ComputeRoomCost(ByVal intPass As Integer) As Decimal
        Dim decTicketCost As Decimal
        decTicketCost = intPass * _decHourlyRate

        Return decTicketCost
    End Function

    Private Sub ClearForm()
        cboOption.SelectedIndex = -1
        lblInstructions.Visible = False
        txtValue.Visible = False
        btnCalculate.Visible = False
        btnClear.Visible = False
        lblTotal.Visible = False
        txtValue.Clear()
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim blnIsValid As Boolean = False
        Dim intValue As Integer
        Dim decTotal As Decimal
        blnIsValid = ValidateInput()
        If blnIsValid = True Then
            intValue = Convert.ToInt32(txtValue.Text)
            If cboOption.SelectedIndex = 0 Then
                decTotal = ComputeSongCost(intValue)
            Else
                decTotal = ComputeRoomCost(intValue)
            End If
            lblTotal.Visible = True
            lblTotal.Text = "Total Cost of Karaoke Night - " & decTotal.ToString("C")
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub cboOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOption.SelectedIndexChanged
        If cboOption.SelectedIndex = 0 Then
            lblInstructions.Text = "Number of Karaoke Songs"
            lblInstructions.Visible = True
            lblTotal.Visible = False
            txtValue.Visible = True
            btnCalculate.Visible = True
            btnClear.Visible = True
            txtValue.Focus()
        End If
        If cboOption.SelectedIndex = 1 Then
            lblInstructions.Text = "Hourly Rental of Karaoke Room"
            lblInstructions.Visible = True
            lblTotal.Visible = False
            txtValue.Visible = True
            btnCalculate.Visible = True
            btnClear.Visible = True
            txtValue.Focus()
        End If
    End Sub
End Class
