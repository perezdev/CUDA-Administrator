Imports System.Drawing

Namespace ColorTables

    Public Class Vs2010DefaultTabControlColorTable
        Inherits Vs2010TabControlColorTable

        Private _CommonColorTable As Vs2010CommonColorTable

        Public Sub New()
            _CommonColorTable = New Vs2010DefaultCommonColorTable()
        End Sub

        Public Overrides ReadOnly Property CommonColorTable As Vs2010CommonColorTable
            Get
                Return _CommonColorTable
            End Get
        End Property

        Public Overrides ReadOnly Property CloseButtonBorder As System.Drawing.Color
            Get
                Return Color.FromArgb(229, 195, 101)
            End Get
        End Property

        Public Overrides ReadOnly Property CloseButtonClickedBackColor As System.Drawing.Color
            Get
                Return Color.FromArgb(255, 232, 166)
            End Get
        End Property

        Public Overrides ReadOnly Property CloseButtonHoverBackColor As System.Drawing.Color
            Get
                Return Color.FromArgb(255, 252, 244)
            End Get
        End Property

        Public Overrides ReadOnly Property Background As System.Drawing.Color
            Get
                Return Color.FromArgb(22, 21, 20)
            End Get
        End Property

        Public Overrides ReadOnly Property BackgroundDotsLight As System.Drawing.Color
            Get
                Return Color.FromArgb(47, 45, 43)
            End Get
        End Property

        Public Overrides ReadOnly Property BackgroundDotsDark As System.Drawing.Color
            Get
                Return Color.FromArgb(33, 34, 31)
            End Get
        End Property

        Public Overrides ReadOnly Property InactiveColor As System.Drawing.Color
            Get
                Return Color.FromArgb(69, 89, 125)
            End Get
        End Property

        Public Overrides ReadOnly Property Border As System.Drawing.Color
            Get
                'Return Color.FromArgb(49, 65, 89)
                Return Color.FromArgb(96, 0, 0)
            End Get
        End Property

        Public Overrides ReadOnly Property HoveringHeaderGradientBottom As System.Drawing.Color
            Get
                Return Color.FromArgb(111, 0, 0)
            End Get
        End Property

        Public Overrides ReadOnly Property HoveringHeaderGradientTop As System.Drawing.Color
            Get
                Return Color.FromArgb(111, 119, 118)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectedHeaderGradientBottom As System.Drawing.Color
            Get
                'Return Color.FromArgb(49, 65, 89)
                Return Color.FromArgb(96, 0, 0)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectedHeaderGradientMiddle As System.Drawing.Color
            Get
                'Return Color.FromArgb(60, 72, 90)
                Return Color.FromArgb(100, 33, 7)
            End Get
        End Property

        Public Overrides ReadOnly Property SelectedHeaderGradientTop As System.Drawing.Color
            Get
                Return Color.FromArgb(55, 33, 7)
                'Return Color.FromArgb(105, 33, 7)
            End Get
        End Property

        Public Overrides ReadOnly Property HoveringHeaderBorder As System.Drawing.Color
            Get
                Return Color.FromArgb(155, 167, 183)
            End Get
        End Property
    End Class

End Namespace