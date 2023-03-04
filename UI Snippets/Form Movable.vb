Public Shared Sub MoveFormOnMouseDown(form As Form, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            form.Capture = False
            Const WM_NCLBUTTONDOWN As Integer = &HA1
            Const HT_CAPTION As Integer = 2
            SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub