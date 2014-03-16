Imports System.Drawing.Drawing2D
Imports System.Drawing

Namespace Renderers

    Public Class CommonDrawing

        ''' <summary>
        ''' Draws the rounded yellow selection rectangle.
        ''' </summary>
        Public Shared Sub DrawSelection(ByVal g As Graphics, _
                                        ByVal colorTable As ColorTables.Vs2010CommonColorTable, _
                                        ByVal rect As Rectangle, _
                                        ByVal rounded As Boolean)
            Dim topRect As Rectangle
            Dim bottomRect As Rectangle

            If rounded Then
                Dim fillRect As New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 1, rect.Height - 1)
                topRect = fillRect
                topRect.Height -= CInt(topRect.Height / 2)
                bottomRect = New Rectangle(topRect.X, topRect.Bottom, topRect.Width, fillRect.Height - topRect.Height)
            Else
                topRect = rect
                topRect.Height -= CInt(topRect.Height / 2)
                bottomRect = New Rectangle(topRect.X, topRect.Bottom, topRect.Width, rect.Height - topRect.Height)
            End If

            ' Top gradient
            Using b As New LinearGradientBrush(topRect, _
                                               colorTable.SelectedGradientTop, _
                                               colorTable.SelectedGradientMiddle, _
                                               LinearGradientMode.Vertical)
                g.FillRectangle(b, topRect)
            End Using

            ' Bottom
            Using b As New SolidBrush(colorTable.SelectedGradientBottom)
                g.FillRectangle(b, bottomRect)
            End Using

            ' Border
            Using p As New Pen(colorTable.SelectedBorder)
                If rounded Then
                    CommonDrawing.DrawRoundedRectangle(g, p, rect.X, rect.Y, rect.Width, rect.Height, 2)
                Else
                    g.DrawRectangle(p, rect)
                End If
            End Using

        End Sub

        Public Shared Sub DrawRoundedRectangle(ByVal g As Graphics, _
                                        ByVal p As Pen, _
                                        ByVal x As Single, _
                                        ByVal y As Single, _
                                        ByVal width As Single, _
                                        ByVal height As Single, _
                                        ByVal radius As Single)

            Using gp As New GraphicsPath()
                gp.AddLine(x + radius, y, x + width - (radius * 2), y)
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
                gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2))
                gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90)
                gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height)
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90)
                gp.AddLine(x, y + height - (radius * 2), x, y + radius)
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
                gp.CloseFigure()

                g.SmoothingMode = SmoothingMode.AntiAlias
                g.DrawPath(p, gp)
                g.SmoothingMode = SmoothingMode.Default
            End Using
        End Sub

        Public Shared Sub FillRoundedRectangle(ByVal g As Graphics, _
                                               ByVal b As Brush, _
                                               ByVal x As Single, _
                                               ByVal y As Single, _
                                               ByVal width As Single, _
                                               ByVal height As Single, _
                                               ByVal radius As Single)

            Using gp As New GraphicsPath()
                gp.AddLine(x + radius, y, x + width - (radius * 2), y)
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90)
                gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2))
                gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90)
                gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height)
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90)
                gp.AddLine(x, y + height - (radius * 2), x, y + radius)
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
                gp.CloseFigure()

                g.SmoothingMode = SmoothingMode.AntiAlias
                g.FillPath(b, gp)
                g.SmoothingMode = SmoothingMode.Default
            End Using
        End Sub

    End Class

End Namespace