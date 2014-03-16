Imports System.Windows.Forms

Namespace Controls

    ''' <summary>
    ''' A ToolStrip control using the Visual Studio 2010 style.
    ''' </summary>
    ''' <remarks>Assign your own <see cref="Vs2010Renderers.ColorTables.Vs2010ToolStripColorTable" /> to specify a custom color scheme.</remarks>
    Public Class Vs2010ToolStrip
        Inherits ToolStrip

        Public Sub New()
            MyBase.New()

            ' Set our renderer by default, this enables it in the designer too.
            Me.Renderer = New Renderers.Vs2010ToolStripRenderer()
            Me.BackColor = Me.Renderer.ColorTable.ParentBackground
        End Sub

        Private _AutoParentBackColor As Boolean
        ''' <summary>
        ''' Gets or sets a value indicating whether a parent <see cref="ToolStripPanel" /> control will automatically adjust its BackColor.
        ''' </summary>
        ''' <returns>A value indicating whether a parent <see cref="ToolStripPanel" /> control will automatically adjust its BackColor.</returns>
        Public Property AutoParentBackColor() As Boolean
            Get
                Return _AutoParentBackColor
            End Get
            Set(ByVal value As Boolean)
                _AutoParentBackColor = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the <see cref="Vs2010Renderers.Renderers.Vs2010ToolStripRenderer" /> used to draw this control.
        ''' </summary>
        ''' <returns>The <see cref="Vs2010Renderers.Renderers.Vs2010ToolStripRenderer" /> used to draw this control.</returns>
        ''' <remarks>Assign your own class inheriting <see cref="Vs2010Renderers.Renderers.Vs2010ToolStripRenderer" /> to apply a custom theme.</remarks>
        Public Overloads Property Renderer() As Renderers.Vs2010ToolStripRenderer
            Get
                Return DirectCast(MyBase.Renderer, Renderers.Vs2010ToolStripRenderer)
            End Get
            Set(ByVal value As Renderers.Vs2010ToolStripRenderer)
                MyBase.Renderer = value
                Me.ChangeParentBackColor()
            End Set
        End Property

        Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)
            MyBase.OnParentChanged(e)
            Me.ChangeParentBackColor()
        End Sub

        ' Change the background of a parenting ToolStripPanel to the ParentBackground automatically.
        Private Sub ChangeParentBackColor()
            If Me.Parent IsNot Nothing Then
                If TypeOf Me.Parent Is ToolStripPanel Then

                    If Me.AutoParentBackColor Then
                        Me.Parent.BackColor = Me.Renderer.ColorTable.ParentBackground
                    Else
                        Me.Parent.BackColor = ToolStripPanel.DefaultBackColor
                    End If

                    Me.Parent.Invalidate()
                End If
            End If
        End Sub
    End Class

End Namespace