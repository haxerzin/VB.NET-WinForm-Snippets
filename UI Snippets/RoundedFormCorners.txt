Public Shared Sub RoundFormCorners(ByVal form As Form, ByVal radius As Integer)
    Using path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddLine(radius, 0, form.Width - radius, 0)
        path.AddArc(New Rectangle(form.Width - radius, 0, radius, radius), -90, 90)
        path.AddLine(form.Width, radius, form.Width, form.Height - radius)
        path.AddArc(New Rectangle(form.Width - radius, form.Height - radius, radius, radius), 0, 90)
        path.AddLine(form.Width - radius, form.Height, radius, form.Height)
        path.AddArc(New Rectangle(0, form.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()
        form.Region = New Region(path)
    End Using
End Sub
