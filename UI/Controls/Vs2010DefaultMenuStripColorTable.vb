Imports System.Drawing

Namespace ColorTables

    Public Class Vs2010DefaultMenuStripColorTable
        Inherits ColorTables.Vs2010MenuStripColorTable

        Private _CommonColorTable As Vs2010CommonColorTable

        Public Sub New()
            _CommonColorTable = New Vs2010DefaultCommonColorTable()
        End Sub

        Public Overrides ReadOnly Property CommonColorTable As Vs2010CommonColorTable
            Get
                Return _CommonColorTable
            End Get
        End Property

        Public Overrides ReadOnly Property BottomBorder As System.Drawing.Color
            Get
                Return Color.FromArgb(54, 54, 54)
            End Get
        End Property

        Public Overrides ReadOnly Property BackgroundGradientBottom As System.Drawing.Color
            Get
                Return Color.FromArgb(22, 22, 21)
            End Get
        End Property

        Public Overrides ReadOnly Property BackgroundGradientTop As System.Drawing.Color
            Get
                Return Color.FromArgb(75, 71, 68)
            End Get
        End Property

        Public Overrides ReadOnly Property DropdownGradientBottom As System.Drawing.Color
            Get
                Return Color.FromArgb(26, 24, 23)
            End Get
        End Property

        Public Overrides ReadOnly Property DropdownGradientTop As System.Drawing.Color
            Get
                Return Color.FromArgb(75, 71, 68)
            End Get
        End Property

        Public Overrides ReadOnly Property DroppedDownItemBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(75, 71, 68)
            End Get
        End Property

        Public Overrides ReadOnly Property ImageMargin As System.Drawing.Color
            Get
                Return Color.FromArgb(75, 71, 68)
            End Get
        End Property

        Public Overrides ReadOnly Property Separator As System.Drawing.Color
            Get
                Return Color.FromArgb(190, 195, 203)
            End Get
        End Property

    End Class

End Namespace