Imports System.Windows.Forms

Namespace Controls

    ''' <summary>
    ''' A MenuStrip control using the Visual Studio 2010 style.
    ''' </summary>
    ''' <remarks>Assign your own <see cref="Vs2010Renderers.ColorTables.Vs2010MenuStripColorTable" /> to specify a custom color scheme.</remarks>
    Public Class Vs2010MenuStrip
        Inherits MenuStrip

        Public Sub New()
            MyBase.New()

            ' Set our renderer by default, this enables it in the designer too.
            Me.Renderer = New Renderers.Vs2010MenuStripRenderer()
        End Sub

        ''' <summary>
        ''' Gets or sets the <see cref="Vs2010Renderers.Renderers.Vs2010MenuStripRenderer" /> used to draw this control.
        ''' </summary>
        ''' <returns>The <see cref="Vs2010Renderers.Renderers.Vs2010MenuStripRenderer" /> used to draw this control.</returns>
        ''' <remarks>Assign your own class inheriting <see cref="Vs2010Renderers.Renderers.Vs2010MenuStripRenderer" /> to apply a custom theme.</remarks>
        Public Overloads Property Renderer() As Renderers.Vs2010MenuStripRenderer
            Get
                Return DirectCast(MyBase.Renderer, Renderers.Vs2010MenuStripRenderer)
            End Get
            Set(ByVal value As Renderers.Vs2010MenuStripRenderer)
                MyBase.Renderer = value
            End Set
        End Property

    End Class

End Namespace