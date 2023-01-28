Public Shared Sub SetButtonBackground(ByVal btn As Button, ByVal image As Image)
    btn.BackgroundImageLayout = ImageLayout.Stretch
    btn.BackgroundImage = New Bitmap(image)
End Sub
