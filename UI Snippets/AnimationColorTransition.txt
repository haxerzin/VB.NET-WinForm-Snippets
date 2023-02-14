    Public Shared Sub AnimateColorTransition(control As Control, startColor As Color, endColor As Color, duration As Integer)
        Dim startTime As DateTime = DateTime.Now
        Dim timer As New Timer()
        Dim controlCopy As Control = control
        AddHandler timer.Tick, Sub(sender As Object, e As EventArgs)
                                   Dim elapsed As TimeSpan = DateTime.Now - startTime
                                   Dim progress As Double = elapsed.TotalMilliseconds / duration
                                   If progress >= 1 Then
                                       controlCopy.BackColor = endColor
                                       timer.Stop()
                                       timer.Dispose()
                                       Exit Sub
                                   End If
                                   Dim startHSL As Single() = ColorToHSL(startColor)
                                   Dim endHSL As Single() = ColorToHSL(endColor)
                                   Dim currentHSL As Single() = {
                                   startHSL(0) + (endHSL(0) - startHSL(0)) * CSng(progress),
                                   startHSL(1) + (endHSL(1) - startHSL(1)) * CSng(progress),
                                   startHSL(2) + (endHSL(2) - startHSL(2)) * CSng(progress)
                               }
                                   controlCopy.BackColor = HSLToColor(currentHSL)
                               End Sub
        timer.Interval = 10
        timer.Start()
    End Sub

    Private Shared Function ColorToHSL(color As Color) As Single()
        Dim r As Integer = color.R
        Dim g As Integer = color.G
        Dim b As Integer = color.B
        Dim max As Integer = Math.Max(r, Math.Max(g, b))
        Dim min As Integer = Math.Min(r, Math.Min(g, b))
        Dim h As Single, s As Single, l As Single = (max + min) >> 1
        If max = min Then
            h = 0
            s = 0
        Else
            Dim d As Integer = max - min
            s = If(l > 127, d \ (510 - max - min), d \ (max + min))
            Select Case max
                Case r
                    h = (g - b + If(g < b, 1530, 0)) / (d * 6)
                Case g
                    h = (b - r + 510) / (d * 6)
                Case b
                    h = (r - g + 1020) / (d * 6)
            End Select
            h = If(h < 0, h + 1, h)
        End If
        Return {h, s, l / 255}
    End Function

    Private Shared Function HSLToColor(hsl As Single()) As Color
        Dim h As Single = hsl(0)
        Dim s As Single = hsl(1)
        Dim l As Single = hsl(2)
        Dim r As Integer, g As Integer, b As Integer
        If s = 0 Then
            r = l * 255
            g = l * 255
            b = l * 255
        Else
            Dim q As Integer = If(l < 0.5, l * (1 + s) * 255, (l + s - l * s) * 255)
            Dim p As Integer = (2 * l - q) * 255
            r = HueToRGB(p, q, h + 1 / 3)
            g = HueToRGB(p, q, h)
            b = HueToRGB(p, q, h - 1 / 3)
        End If
        Return Color.FromArgb(r, g, b)
    End Function

    Private Shared Function HueToRGB(p As Integer, q As Integer, t As Single) As Integer
        If t < 0 Then t += 1
        If t > 1 Then t -= 1
        If t < 1 / 6 Then Return p + ((q - p) * 6 * t) \ 255
        If t < 1 / 2 Then Return q \ 255
        If t < 2 / 3 Then Return p + ((q - p) * (2 / 3 - t) * 6) \ 255
        Return p \ 255
    End Function