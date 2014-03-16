Imports System.Drawing

Namespace ColorTables

    Public Class Vs2010DefaultToolStripColorTable
        Inherits ColorTables.Vs2010ToolStripColorTable

        Private _CommonColorTable As Vs2010CommonColorTable

        Public Sub New()
            _CommonColorTable = New Vs2010DefaultCommonColorTable()
        End Sub

        Public Overrides ReadOnly Property CommonColorTable As Vs2010CommonColorTable
            Get
                Return _CommonColorTable
            End Get
        End Property

        Public Overrides ReadOnly Property Background As System.Drawing.Color
            Get
                Return Color.FromArgb(22, 21, 20)
            End Get
        End Property

        Public Overrides ReadOnly Property Border As System.Drawing.Color
            Get
                Return Color.FromArgb(54, 54, 54)
            End Get
        End Property

        Public Overrides ReadOnly Property Grip As System.Drawing.Color
            Get
                Return Color.FromArgb(98, 115, 141)
            End Get
        End Property

        Public Overrides ReadOnly Property ParentBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(156, 170, 193)
            End Get
        End Property

        Public Overrides ReadOnly Property Separator As System.Drawing.Color
            Get
                Return Color.FromArgb(133, 145, 162)
            End Get
        End Property

        Public Overrides ReadOnly Property OverflowBackground As System.Drawing.Color
            Get
                Return Color.FromArgb(213, 220, 232)
            End Get
        End Property

    End Class

End Namespace