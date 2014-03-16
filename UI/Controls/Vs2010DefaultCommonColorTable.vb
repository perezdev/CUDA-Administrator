Imports System.Drawing

Namespace ColorTables

    Public Class Vs2010DefaultCommonColorTable
        Inherits Vs2010CommonColorTable

        Public Overrides ReadOnly Property CheckedBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(160, 160, 160)
            End Get
        End Property

        Public Overrides ReadOnly Property CheckedSelectedBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(192, 192, 192)
            End Get
        End Property

        Public Overrides ReadOnly Property PressedBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(39, 38, 35)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectedBorder As System.Drawing.Color
            Get
                Return Color.FromArgb(54, 54, 54)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectedGradientBottom As System.Drawing.Color
            Get
                'Return Color.FromArgb(49, 65, 89)
                Return Color.FromArgb(96, 0, 0)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectedGradientMiddle As System.Drawing.Color
            Get
                'Return Color.FromArgb(60, 72, 90)
                Return Color.FromArgb(100, 33, 7)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectedGradientTop As System.Drawing.Color
            Get
                'Return Color.FromArgb(99, 97, 95)
                Return Color.FromArgb(55, 33, 7)
            End Get
        End Property

        Public Overrides ReadOnly Property TextColor As System.Drawing.Color
            Get
                Return Color.FromArgb(255, 255, 255)
            End Get
        End Property

        Public Overrides ReadOnly Property DropdownBorder As System.Drawing.Color
            Get
                Return Color.FromArgb(0, 0, 0)
            End Get
        End Property

        Public Overrides ReadOnly Property Arrow As System.Drawing.Color
            Get
                Return Color.Black
            End Get
        End Property

    End Class

End Namespace