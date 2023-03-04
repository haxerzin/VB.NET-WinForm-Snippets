Public Shared Sub FadeInForm(form As Form)
    form.Opacity = 0
    form.Show()
    Dim fadeIn As New Timer With {.Interval = 10}
    AddHandler fadeIn.Tick, Sub()
        If form.Opacity < 1 Then
            form.Opacity += 0.05
        Else
            fadeIn.Stop()
        End If
    End Sub
    fadeIn.Start()
End Sub

Public Shared Sub FadeOutForm(form As Form)
    Dim fadeOut As New Timer With {.Interval = 10}
    AddHandler fadeOut.Tick, Sub()
        If form.Opacity > 0 Then
            form.Opacity -= 0.05
        Else
            fadeOut.Stop()
            form.Close()
        End If
    End Sub
    fadeOut.Start()
End Sub
