Public Shared Sub CreateRoundedButton(ByRef btn As Button, ByVal radius As Integer)
    Dim path As New GraphicsPath()
    path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
    path.AddArc(New Rectangle(btn.Width - radius, 0, radius, radius), -90, 90)
    path.AddArc(New Rectangle(btn.Width - radius, btn.Height - radius, radius, radius), 0, 90)
    path.AddArc(New Rectangle(0, btn.Height - radius, radius, radius), 90, 90)
    path.CloseFigure()
    btn.Region = New Region(path)
End Sub