Imports System.Drawing

''' <summary>
''' Module used to change the form's background colors
''' </summary>
''' <remarks></remarks>
Public Module BackgroundColors
    Public ReadOnly Property BackgroundColor As System.Drawing.Color
        Get
            Return Color.FromArgb(22, 21, 20)
        End Get
    End Property

    Public ReadOnly Property BackgroundDotsLight As System.Drawing.Color
        Get
            Return Color.FromArgb(47, 45, 43)
        End Get
    End Property

    Public ReadOnly Property BackgroundDotsDark As System.Drawing.Color
        Get
            Return Color.FromArgb(33, 34, 31)
        End Get
    End Property
End Module
