Public Shared Sub AnimateControlHeight(control As Control, targetHeight As Integer, duration As Integer)
        Dim initialHeight As Integer = control.Height
        Dim changeInHeight As Integer = targetHeight - initialHeight
        Dim elapsedTime As Integer = 0
        Dim timerInterval As Integer = 10
        Dim heightIncrement As Integer = changeInHeight / (duration / timerInterval)

        Dim timer As New Timer()
        AddHandler timer.Tick, Sub(sender, e)
                                   elapsedTime += timerInterval
                                   If elapsedTime >= duration Then
                                       control.Height = targetHeight
                                       timer.Stop()
                                   Else
                                       control.Height = initialHeight + CInt(heightIncrement * elapsedTime / timerInterval)
                                   End If
                               End Sub
        timer.Interval = timerInterval
        timer.Start()
    End Sub