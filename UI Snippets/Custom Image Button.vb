Imports System.ComponentModel

Public Class CustomButton
    Inherits Button

    Private _imageBox As PictureBox

    Public Sub New()
        MyBase.New()
        Me.Size = New Size(178, 35)
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0
        Me.ForeColor = Color.FromArgb(64, 64, 64)
        Me.Font = New Font("Microsoft Sans Serif", 11.25, FontStyle.Bold)
        Me.TabStop = False
        Me.FlatAppearance.MouseOverBackColor = Color.White
        Me.FlatAppearance.MouseDownBackColor = Color.White
        UI.RoundedControl(Me, Color.WhiteSmoke, CONFIGS.rounded_arc)


        _imageBox = New PictureBox()
        _imageBox.Size = New Size(25, 25)
        _imageBox.Location = New Point(3, 5)
        _imageBox.BackColor = Color.Transparent
        _imageBox.SizeMode = PictureBoxSizeMode.StretchImage
        Me.Controls.Add(_imageBox)

        Me.TextAlign = ContentAlignment.MiddleCenter

        ' Add event handlers
        AddHandler Me.MouseEnter, AddressOf CustomButton_MouseEnter
        AddHandler Me.MouseLeave, AddressOf CustomButton_MouseLeave
        AddHandler _imageBox.MouseEnter, AddressOf ImageBox_MouseEnter
        AddHandler _imageBox.MouseLeave, AddressOf ImageBox_MouseLeave
        AddHandler _imageBox.Click, AddressOf Me.PerformClick

    End Sub

    Private Sub ImageBox_MouseEnter(sender As Object, e As EventArgs)
        If MainWindow.isMenuWide Then
            UI.AnimateColorTransition(Me, Color.WhiteSmoke, Color.White, 50)
        End If
        UI.AnimateColorTransition(_imageBox, Color.WhiteSmoke, Color.White, 50)
    End Sub

    Private Sub ImageBox_MouseLeave(sender As Object, e As EventArgs)
        If MainWindow.isMenuWide Then
            UI.AnimateColorTransition(Me, Color.White, Color.WhiteSmoke, 50)
        End If
        UI.AnimateColorTransition(_imageBox, Color.White, Color.WhiteSmoke, 50)
    End Sub

    Private Sub CustomButton_MouseEnter(sender As Object, e As EventArgs)
        If MainWindow.isMenuWide Then
            UI.AnimateColorTransition(Me, Color.WhiteSmoke, Color.White, 50)
            UI.AnimateColorTransition(_imageBox, Color.WhiteSmoke, Color.White, 50)
        End If
    End Sub

    Private Sub CustomButton_MouseLeave(sender As Object, e As EventArgs)
        If MainWindow.isMenuWide Then
            UI.AnimateColorTransition(Me, Color.White, Color.WhiteSmoke, 50)
            UI.AnimateColorTransition(_imageBox, Color.White, Color.WhiteSmoke, 50)
        End If
    End Sub

    <Browsable(True)>
    <EditorBrowsable(EditorBrowsableState.Always)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
        End Set
    End Property

    <Browsable(True)>
    <EditorBrowsable(EditorBrowsableState.Always)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property Width() As Integer
        Get
            Return MyBase.Width
        End Get
        Set(ByVal value As Integer)
            MyBase.Width = value
        End Set
    End Property

    <Browsable(True)>
    <EditorBrowsable(EditorBrowsableState.Always)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Shadows Property Height() As Integer
        Get
            Return MyBase.Height
        End Get
        Set(ByVal value As Integer)
            MyBase.Height = value
        End Set
    End Property

    <Browsable(True)>
    <EditorBrowsable(EditorBrowsableState.Always)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property ImageBox() As PictureBox
        Get
            Return _imageBox
        End Get
        Set(ByVal value As PictureBox)
            _imageBox = value
        End Set
    End Property

    <Browsable(True)>
    <EditorBrowsable(EditorBrowsableState.Always)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property ImageButton() As Image
        Get
            Return _imageBox.Image
        End Get
        Set(ByVal value As Image)
            _imageBox.Image = value
        End Set
    End Property

End Class
