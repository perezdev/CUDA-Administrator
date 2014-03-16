Imports System.Drawing
Imports System.Windows.Forms

Namespace Renderers

    Public Class Vs2010ToolStripRenderer
        Inherits Vs2010MenuStripRenderer

        Public Sub New()
            Me.New(New ColorTables.Vs2010DefaultToolStripColorTable())
        End Sub

        Public Sub New(ByVal colorTable As ColorTables.Vs2010ToolStripColorTable)
            Me.ColorTable = colorTable
        End Sub

        Private _ColorTable As ColorTables.Vs2010ToolStripColorTable
        Public Overloads Property ColorTable() As ColorTables.Vs2010ToolStripColorTable
            Get
                If _ColorTable Is Nothing Then
                    _ColorTable = New ColorTables.Vs2010DefaultToolStripColorTable()
                End If
                Return _ColorTable
            End Get
            Set(ByVal value As ColorTables.Vs2010ToolStripColorTable)
                _ColorTable = value
            End Set
        End Property

#Region " Backgrounds and borders "

        Protected Overrides Sub OnRenderToolStripBackground(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            MyBase.OnRenderToolStripBackground(e)

            Dim roundedRect As New Rectangle(e.AffectedBounds.X, _
                            e.AffectedBounds.Y + 1, _
                            e.AffectedBounds.Width, _
                            e.AffectedBounds.Height - 3)
            Using b As New SolidBrush(Me.ColorTable.Background)
                e.Graphics.FillRectangle(b, roundedRect)
            End Using
        End Sub

        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            If e.ToolStrip.Parent IsNot Nothing Then
                Dim rect As New Rectangle(e.AffectedBounds.X, _
                                          e.AffectedBounds.Y, _
                                          e.AffectedBounds.Width, _
                                          e.AffectedBounds.Height - 2)
                Using p As New Pen(Me.ColorTable.Border)
                    CommonDrawing.DrawRoundedRectangle(e.Graphics, _
                                                       p, _
                                                       rect.X, _
                                                       rect.Y, _
                                                       rect.Width, _
                                                       rect.Height, _
                                                       2)
                End Using
            Else
                ' Call base (menu strip renderer) OnRenderToolStripBorder method
                MyBase.OnRenderToolStripBorder(e)

                ' But now fill in the top border completely
                Using p As New Pen(Me.ColorTable.CommonColorTable.DropdownBorder)
                    e.Graphics.DrawLine(p, e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Right, e.AffectedBounds.Y)
                End Using
            End If
        End Sub

#End Region

#Region " Items "

        Protected Overrides Sub OnRenderItemText(ByVal e As System.Windows.Forms.ToolStripItemTextRenderEventArgs)
            e.TextColor = Me.ColorTable.CommonColorTable.TextColor
            MyBase.OnRenderItemText(e)
        End Sub

#Region " Buttons "

        Protected Overrides Sub OnRenderButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            Dim rect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
            Dim checked As Boolean = CType(e.Item, ToolStripButton).Checked
            Dim drawBorder As Boolean = False

            If checked Then
                drawBorder = True

                If e.Item.Selected AndAlso Not e.Item.Pressed Then
                    Using b As New SolidBrush(Me.ColorTable.CommonColorTable.CheckedSelectedBackground)
                        e.Graphics.FillRectangle(b, rect)
                    End Using
                Else
                    Using b As New SolidBrush(Me.ColorTable.CommonColorTable.CheckedBackground)
                        e.Graphics.FillRectangle(b, rect)
                    End Using
                End If

            Else

                If e.Item.Pressed Then
                    drawBorder = True
                    Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                        e.Graphics.FillRectangle(b, rect)
                    End Using
                ElseIf e.Item.Selected Then
                    drawBorder = True
                    CommonDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, rect, False)
                End If

            End If

            If drawBorder Then
                Using p As New Pen(Me.ColorTable.CommonColorTable.SelectedBorder)
                    e.Graphics.DrawRectangle(p, rect)
                End Using
            End If
        End Sub

        Protected Overrides Sub OnRenderDropDownButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            Dim rect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
            Dim drawBorder As Boolean = False

            If e.Item.Pressed Then
                drawBorder = True
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                    e.Graphics.FillRectangle(b, rect)
                End Using
            ElseIf e.Item.Selected Then
                drawBorder = True
                CommonDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, rect, False)
            End If

            If drawBorder Then
                Using p As New Pen(Me.ColorTable.CommonColorTable.SelectedBorder)
                    e.Graphics.DrawRectangle(p, rect)
                End Using
            End If
        End Sub

        Protected Overrides Sub OnRenderSplitButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            MyBase.OnRenderSplitButtonBackground(e)

            Dim drawBorder As Boolean = False
            Dim drawSeparator As Boolean = True

            Dim item = DirectCast(e.Item, ToolStripSplitButton)

            Dim btnRect As New Rectangle(0, 0, item.ButtonBounds.Width - 1, item.ButtonBounds.Height - 1)
            Dim borderRect As New Rectangle(0, 0, item.Bounds.Width - 1, item.Bounds.Height - 1)

            If item.DropDownButtonPressed Then
                drawBorder = True
                drawSeparator = False
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                    e.Graphics.FillRectangle(b, borderRect)
                End Using
            ElseIf item.DropDownButtonSelected Then
                drawBorder = True
                CommonDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, borderRect, False)
            End If

            If item.ButtonPressed Then
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                    e.Graphics.FillRectangle(b, btnRect)
                End Using
            End If

            If drawBorder Then
                Using p As New Pen(Me.ColorTable.CommonColorTable.SelectedBorder)
                    e.Graphics.DrawRectangle(p, borderRect)
                    If drawSeparator Then e.Graphics.DrawRectangle(p, btnRect)
                End Using

                Me.DrawCustomArrow(e.Graphics, item)
            End If
        End Sub

        Private Sub DrawCustomArrow(ByVal g As Graphics, ByVal item As ToolStripSplitButton)
            Dim dropWidth As Integer = item.DropDownButtonBounds.Width - 1
            Dim dropHeight As Integer = item.DropDownButtonBounds.Height - 1
            Dim triangleWidth As Single = dropWidth / 2.0F + 1
            Dim triangleLeft As Single = item.DropDownButtonBounds.Left + (dropWidth - triangleWidth) / 2.0F
            Dim triangleHeight As Single = triangleWidth / 2.0F
            Dim triangleTop As Single = item.DropDownButtonBounds.Top + (dropHeight - triangleHeight) / 2.0F + 1
            Dim arrowRect As New RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight)

            Me.DrawCustomArrow(g, item, Rectangle.Round(arrowRect))
        End Sub

        Private Sub DrawCustomArrow(ByVal g As Graphics, ByVal item As ToolStripItem, ByVal rect As Rectangle)
            Dim arrowEventArgs As New ToolStripArrowRenderEventArgs(g, _
                                                        item, _
                                                        rect, _
                                                        Me.ColorTable.CommonColorTable.Arrow, _
                                                        ArrowDirection.Down)
            MyBase.OnRenderArrow(arrowEventArgs)
        End Sub

        Protected Overrides Sub OnRenderOverflowButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            Dim rect, rectEnd As Rectangle
            rect = New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 2)
            rectEnd = New Rectangle(rect.X - 5, rect.Y, rect.Width - 5, rect.Height)

            If e.Item.Pressed Then
                Using b As New SolidBrush(Me.ColorTable.CommonColorTable.PressedBackground)
                    e.Graphics.FillRectangle(b, rect)
                End Using
            ElseIf e.Item.Selected Then
                CommonDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, rect, False)
            Else
                Using b As New SolidBrush(Me.ColorTable.OverflowBackground)
                    e.Graphics.FillRectangle(b, rect)
                End Using
            End If

            Using b As New SolidBrush(Me.ColorTable.Background)
                CommonDrawing.FillRoundedRectangle(e.Graphics, b, rectEnd.X, rectEnd.Y, rectEnd.Width, rectEnd.Height, 3)
            End Using

            ' Icon
            Dim w As Integer = rect.Width - 1
            Dim h As Integer = rect.Height - 1
            Dim triangleWidth As Single = w / 2.0F + 1
            Dim triangleLeft As Single = rect.Left + (w - triangleWidth) / 2.0F + 3
            Dim triangleHeight As Single = triangleWidth / 2.0F
            Dim triangleTop As Single = rect.Top + (h - triangleHeight) / 2.0F + 7
            Dim arrowRect As New RectangleF(triangleLeft, triangleTop, triangleWidth, triangleHeight)
            Me.DrawCustomArrow(e.Graphics, e.Item, Rectangle.Round(arrowRect))

            Using p As New Pen(Me.ColorTable.CommonColorTable.Arrow)
                e.Graphics.DrawLine(p, triangleLeft + 2, triangleTop - 2, triangleLeft + triangleWidth - 2, triangleTop - 2)
            End Using
        End Sub

#End Region

#End Region

#Region " Misc "

        Protected Overrides Sub OnRenderGrip(ByVal e As System.Windows.Forms.ToolStripGripRenderEventArgs)
            If e.GripDisplayStyle = ToolStripGripDisplayStyle.Vertical Then

                Dim h As Integer = e.GripBounds.Height - 3
                Dim ratio As Single = 14.0F / 22.0F

                Dim totalDotsHeight As Integer = CInt(h * ratio)
                Dim singleDotHeight As Integer = CInt(totalDotsHeight / 7.0F)
                Dim dotsStart As Integer = CInt((h - totalDotsHeight) / 2.0F) + 1

                Using b As New SolidBrush(Me.ColorTable.Grip)

                    Dim bounds As New Rectangle(e.GripBounds.X, dotsStart, singleDotHeight, singleDotHeight)
                    For i As Integer = 0 To 3
                        e.Graphics.FillRectangle(b, bounds)
                        bounds.Offset(0, 2 * singleDotHeight)
                    Next

                End Using
            End If
        End Sub

        Protected Overrides Sub OnRenderSeparator(ByVal e As System.Windows.Forms.ToolStripSeparatorRenderEventArgs)
            Dim rect As New Rectangle(3, 3, 1, e.Item.Height - 6)
            Using b As New SolidBrush(Me.ColorTable.Separator)
                e.Graphics.FillRectangle(b, rect)
            End Using
        End Sub

#End Region

    End Class

End Namespace