Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms

Namespace Renderers

    'This class actually draws the TabControl/Pages, using the colors from a ColorTable which you can change should you want to
    Public Class Vs2010TabControlRenderer

        Public Sub New()
            Me.New(New ColorTables.Vs2010DefaultTabControlColorTable())
        End Sub

        Public Sub New(ByVal colorTable As ColorTables.Vs2010TabControlColorTable)
            Me.ColorTable = colorTable
        End Sub

        Private _ColorTable As ColorTables.Vs2010TabControlColorTable
        Public Property ColorTable() As ColorTables.Vs2010TabControlColorTable
            Get
                If _ColorTable Is Nothing Then
                    _ColorTable = New ColorTables.Vs2010DefaultTabControlColorTable()
                End If
                Return _ColorTable
            End Get
            Set(ByVal value As ColorTables.Vs2010TabControlColorTable)
                _ColorTable = value
            End Set
        End Property

        Private Sub DrawSelectedTabHeader(ByVal g As Graphics, ByVal rect As RectangleF)
            Dim roundRadius As Single = 2.0F
            Using brush As New LinearGradientBrush(rect, _
                                                   Me.ColorTable.SelectedHeaderGradientTop, _
                                                   Me.ColorTable.SelectedHeaderGradientMiddle, _
                                                   LinearGradientMode.Vertical)
                Dim b = New ColorBlend(4)
                b.Colors = New Color() {Me.ColorTable.SelectedHeaderGradientTop, _
                                        Me.ColorTable.SelectedHeaderGradientMiddle, _
                                        Me.ColorTable.SelectedHeaderGradientBottom, _
                                        Me.ColorTable.SelectedHeaderGradientBottom}
                b.Positions = New Single() {0.0F, 0.5F, 0.5F, 1.0F}
                brush.InterpolationColors = b

                Using gp As New GraphicsPath()
                    gp.AddLine(rect.X + roundRadius, rect.Y, rect.Right - 2 * roundRadius, rect.Y)
                    gp.AddArc(rect.Right - 2 * roundRadius, rect.Y, 2 * roundRadius, 2 * roundRadius, 270, 90)
                    gp.AddLine(rect.Right, rect.Y + roundRadius, rect.Right, rect.Bottom)
                    gp.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom)
                    gp.AddLine(rect.X, rect.Bottom, rect.X, rect.Y)
                    gp.AddArc(rect.X, rect.Y, roundRadius * 2, roundRadius * 2, 180, 90)
                    gp.CloseFigure()

                    g.SmoothingMode = SmoothingMode.AntiAlias
                    g.FillPath(brush, gp)
                    g.SmoothingMode = SmoothingMode.Default
                End Using
            End Using
        End Sub

        Private Sub DrawInactiveTabHeader(ByVal g As Graphics, ByVal rect As RectangleF)
            Dim roundRadius As Single = 2.0F
            Using brush As New SolidBrush(Me.ColorTable.InactiveColor)
                Using gp As New GraphicsPath()
                    gp.AddLine(rect.X + roundRadius, rect.Y, rect.Right - 2 * roundRadius, rect.Y)
                    gp.AddArc(rect.Right - 2 * roundRadius, rect.Y, 2 * roundRadius, 2 * roundRadius, 270, 90)
                    gp.AddLine(rect.Right, rect.Y + roundRadius, rect.Right, rect.Bottom)
                    gp.AddLine(rect.Right, rect.Bottom, rect.X, rect.Bottom)
                    gp.AddLine(rect.X, rect.Bottom, rect.X, rect.Y)
                    gp.AddArc(rect.X, rect.Y, roundRadius * 2, roundRadius * 2, 180, 90)
                    gp.CloseFigure()

                    g.SmoothingMode = SmoothingMode.HighQuality
                    g.FillPath(brush, gp)
                    g.SmoothingMode = SmoothingMode.Default
                End Using
            End Using
        End Sub

        Private Sub DrawHoveringTabHeader(ByVal g As Graphics, ByVal rect As Rectangle)
            rect = New Rectangle(rect.X, rect.Y + 1, rect.Width - 2, rect.Height + 1)
            Dim innerRect As New Rectangle(rect.X + 1, rect.Y, rect.Width - 1, rect.Height - 3)

            Using b As New LinearGradientBrush(innerRect, _
                                               Me.ColorTable.HoveringHeaderGradientTop, _
                                               Me.ColorTable.HoveringHeaderGradientBottom, _
                                               LinearGradientMode.Vertical)
                g.FillRectangle(b, innerRect)
            End Using
            Using p As New Pen(Me.ColorTable.HoveringHeaderBorder)
                CommonDrawing.DrawRoundedRectangle(g, p, rect.X, rect.Y, rect.Width, rect.Height, 2)
            End Using
        End Sub

        Public Overridable Sub OnPaintTabHeader(ByVal e As PaintHeaderEventArgs)
            Dim textColor As Color

            Select Case e.State
                Case PaintHeaderEventArgs.TabHeaderState.Active
                    Me.DrawSelectedTabHeader(e.Graphics, e.ClipRectangle)
                    textColor = Color.White

                Case PaintHeaderEventArgs.TabHeaderState.HotTracking
                    Me.DrawHoveringTabHeader(e.Graphics, e.ClipRectangle)
                    textColor = Color.Gray

                Case PaintHeaderEventArgs.TabHeaderState.Inactive
                    Me.DrawInactiveTabHeader(e.Graphics, e.ClipRectangle)
                    textColor = Color.Gray

                Case Else
                    textColor = Color.Gray
            End Select

            Dim textRect = e.ClipRectangle
            'textRect.Inflate(-2, 0)
            'textRect.Width -= e.TabPage.GetCloseButtonRectangle().Width + 2
            'textRect.Offset(1, 0)

            TextRenderer.DrawText(e.Graphics, e.TabPage.Text, e.TabPage.Font, textRect, textColor, TextFormatFlags.VerticalCenter)
        End Sub

        Public Sub OnPaintCloseButton(ByVal e As PaintCloseButtonEventArgs)
            If e.CloseButtonState = PaintCloseButtonEventArgs.CloseButtonStates.None Then Exit Sub

            Select Case e.CloseButtonState
                Case PaintCloseButtonEventArgs.CloseButtonStates.Clicked
                    Using b As New SolidBrush(Me.ColorTable.CloseButtonClickedBackColor)
                        e.Graphics.FillRectangle(b, e.ClipRectangle)
                    End Using
                    Me.DrawCloseButtonBorder(e.Graphics, e.ClipRectangle)

                Case PaintCloseButtonEventArgs.CloseButtonStates.Hovering
                    Using b As New SolidBrush(Me.ColorTable.CloseButtonHoverBackColor)
                        e.Graphics.FillRectangle(b, e.ClipRectangle)
                    End Using
                    Me.DrawCloseButtonBorder(e.Graphics, e.ClipRectangle)
            End Select

            If e.Image IsNot Nothing Then
                Dim rect = e.ClipRectangle
                rect.Inflate(-2, -2)
                rect.Height -= 2
                rect.Offset(1, 1)
                e.Graphics.DrawImage(e.Image, rect)
            End If
        End Sub

        Private Sub DrawCloseButtonBorder(ByVal g As Graphics, ByVal rect As Rectangle)
            Using p As New Pen(Me.ColorTable.CloseButtonBorder)
                g.DrawRectangle(p, rect)
            End Using
        End Sub

        Public Overridable Sub OnPaintTabHeadersBackground(ByVal e As PaintEventArgs)
            Using h1 As New HatchBrush(HatchStyle.Percent20, Me.ColorTable.BackgroundDotsLight, Me.ColorTable.Background)
                e.Graphics.FillRectangle(h1, e.ClipRectangle)
            End Using
            Using h2 As New HatchBrush(HatchStyle.Percent20, Me.ColorTable.BackgroundDotsDark, Color.Transparent)
                e.Graphics.RenderingOrigin = New Point(0, -1)
                e.Graphics.FillRectangle(h2, e.ClipRectangle)
                e.Graphics.RenderingOrigin = Point.Empty
            End Using
        End Sub

        Public Overridable Sub OnPaintBorders(ByVal e As PaintBordersEventArgs)
            Dim c As Color
            If e.Active Then
                c = Me.ColorTable.Border
            Else
                c = Me.ColorTable.InactiveColor
            End If
            Using b As New SolidBrush(c)
                e.Graphics.FillRectangle(b, e.ClipRectangle)
            End Using
        End Sub

        Public Class PaintCloseButtonEventArgs
            Inherits PaintEventArgs

            Public Enum CloseButtonStates
                None
                Transparent
                Hovering
                Clicked
            End Enum

            Public Sub New(ByVal g As Graphics, _
                           ByVal clipRect As Rectangle, _
                           ByVal state As CloseButtonStates, _
                           ByVal img As Image)
                MyBase.New(g, clipRect)
                _CloseButtonState = state
                _Image = img
            End Sub

            Private _CloseButtonState As CloseButtonStates
            Public ReadOnly Property CloseButtonState() As CloseButtonStates
                Get
                    Return _CloseButtonState
                End Get
            End Property

            Private _Image As Image
            Public ReadOnly Property Image() As Image
                Get
                    Return _Image
                End Get
            End Property

        End Class

        Public Class PaintHeaderEventArgs
            Inherits PaintEventArgs

            Public Enum TabHeaderState
                ''' <summary>
                ''' Represents a normal tab header.
                ''' </summary>
                Normal

                ''' <summary>
                ''' Represents the tab header the mouse is hovering over.
                ''' </summary>
                HotTracking

                ''' <summary>
                ''' Represents an active (selected) tab header.
                ''' </summary>
                ''' <remarks></remarks>
                Active

                ''' <summary>
                ''' Represents an inactive (selected but without focus) tab header.
                ''' </summary>
                ''' <remarks></remarks>
                Inactive
            End Enum

            Public Sub New(ByVal g As Graphics, _
                           ByVal clipRect As Rectangle, _
                           ByVal tabPage As TabPage, _
                           ByVal state As TabHeaderState, _
                           ByVal alignment As StringAlignment)
                MyBase.New(g, clipRect)
                _TabPage = tabPage
                _State = state
                _TextAlignment = alignment
            End Sub

            Private _State As TabHeaderState
            Public ReadOnly Property State() As TabHeaderState
                Get
                    Return _State
                End Get
            End Property

            Private _TabPage As TabPage
            Public ReadOnly Property TabPage() As TabPage
                Get
                    Return _TabPage
                End Get
            End Property

            Private _TextAlignment As StringAlignment
            Public ReadOnly Property TextAlignment() As StringAlignment
                Get
                    Return _TextAlignment
                End Get
            End Property

        End Class

        Public Class PaintBordersEventArgs
            Inherits PaintEventArgs

            Public Enum BorderSide
                Top
                Bottom
            End Enum

            Public Sub New(ByVal g As Graphics, ByVal clipRect As Rectangle, ByVal side As BorderSide, ByVal active As Boolean)
                MyBase.New(g, clipRect)
                _Side = side
                _Active = active
            End Sub

            Private _Side As BorderSide
            Public ReadOnly Property Side() As BorderSide
                Get
                    Return _Side
                End Get
            End Property

            Private _Active As Boolean
            Public ReadOnly Property Active() As Boolean
                Get
                    Return _Active
                End Get
            End Property

        End Class

    End Class

End Namespace