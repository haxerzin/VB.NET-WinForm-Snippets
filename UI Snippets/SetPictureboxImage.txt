Public Shared Sub SetPictureBoxImage(ByVal pictureBox As PictureBox, ByVal image As Image)
    If pictureBox.Image IsNot Nothing Then
        pictureBox.Image.Dispose()
    End If
    pictureBox.Image = New Bitmap(image)
End Sub

// usage //

SetPictureBoxImage(pictureBox1, Image.FromFile("path\to\image.jpg"))
