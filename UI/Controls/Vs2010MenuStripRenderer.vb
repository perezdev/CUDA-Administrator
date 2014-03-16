Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Drawing

Namespace Renderers

    Public Class Vs2010MenuStripRenderer
        Inherits ToolStripProfessionalRenderer

        Public Sub New()
            Me.New(New ColorTables.Vs2010DefaultMenuStripColorTable())
        End Sub

        Public Sub New(ByVal colorTable As ColorTables.Vs2010MenuStripColorTable)
            Me.ColorTable = colorTable
        End Sub

        Private _ColorTable As ColorTables.Vs2010MenuStripColorTable
        Public Overloads Property ColorTable() As ColorTables.Vs2010MenuStripColorTable
            Get
                If _ColorTable Is Nothing Then
                    _ColorTable = New ColorTables.Vs2010DefaultMenuStripColorTable()
                End If
                Return _ColorTable
            End Get
            Set(ByVal value As ColorTables.Vs2010MenuStripColorTable)
                _ColorTable = value
            End Set
        End Property

#Region " Backgrounds and borders "

        Protected Overrides Sub OnRenderToolStripBackground(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            MyBase.OnRenderToolStripBackground(e)

            ' The main background gradient
            Using b As New LinearGradientBrush(e.AffectedBounds,
                                               Me.ColorTable.BackgroundGradientTop,
                                               Me.ColorTable.BackgroundGradientBottom,
                                               LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(b, e.AffectedBounds)
            End Using
        End Sub

        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            'MyBase.OnRenderToolStripBorder(e)

            ' This check is to make sure only the dropdown borders are painted, and not a border around the entire ToolStrip
            If e.ToolStrip.Parent Is Nothing Then

                ' Border around dropdown
                Dim borderRect As New Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1)
                Using p As New Pen(Me.ColorTable.CommonColorTable.DropdownBorder)
                    e.Graphics.DrawRectangle(p, borderRect)
                End Using

                ' Fill in the 'connected area' (gap between dropdown and owner item)
                Using b As New SolidBrush(Me.ColorTable.DroppedDownItemBackground)
                    e.Graphics.FillRectangle(b, e.ConnectedArea)
                End Using

            Else
                ' Border underneath main toolstrip
                Using p As New Pen(Me.ColorTable.BottomBorder)
                    e.Graphics.DrawLine(p, e.AffectedBounds.X, e.AffectedBounds.Bottom - 1, e.AffectedBounds.Right, e.AffectedBounds.Bottom - 1)
                End Using
            End If
        End Sub

        Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
            ' Only draw something if the item is enabled. If not, don't even draw the real selection (which is a blue border)
            If e.Item.Enabled Then

                ' MyBase.OnRenderMenuItemBackground(e)

                If e.Item.Selected Then

                    If Not e.Item.IsOnDropDown Then
                        ' Item is menu header and selected: yellow selection gradient
                        Dim rect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
                        CommonDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, rect, True)
                    Else
                        ' Item is NOT menuheader (but subitem) and selected: slightly smaller yellow selection gradient
                        Dim rect As New Rectangle(2, 0, e.Item.Width - 4, e.Item.Height - 1)
                        CommonDrawing.DrawSelection(e.Graphics, Me.ColorTable.CommonColorTable, rect, True)
                    End If

                End If

                If CType(e.Item, ToolStripMenuItem).DropDown.Visible AndAlso Not e.Item.IsOnDropDown Then
                    ' Item is menu header and dropdown is showing: solid gray background

                    Dim borderRect As New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height)

                    ' Background
                    Dim bgRect As New Rectangle(1, 1, e.Item.Width - 2, e.Item.Height + 2)
                    Using b As New SolidBrush(Me.ColorTable.DroppedDownItemBackground)
                        e.Graphics.FillRectangle(b, bgRect)
                    End Using

                    ' Border
                    Using p As New Pen(Me.ColorTable.CommonColorTable.DropdownBorder)
                        CommonDrawing.DrawRoundedRectangle(e.Graphics, p, borderRect.X, borderRect.Y, borderRect.Width, borderRect.Height, 2)
                    End Using
                End If

                e.Item.ForeColor = Me.ColorTable.CommonColorTable.TextColor
            End If

        End Sub

#End Region

#Region " Items "

        Protected Overrides Sub OnRenderItemText(ByVal e As System.Windows.Forms.ToolStripItemTextRenderEventArgs)
            e.TextColor = Me.ColorTable.CommonColorTable.TextColor
            MyBase.OnRenderItemText(e)
        End Sub

        Protected Overrides Sub OnRenderItemCheck(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
            MyBase.OnRenderItemCheck(e)

            Dim rect As New Rectangle(3, 1, e.Item.Height - 3, e.Item.Height - 3)

            Dim c As Color
            If e.Item.Selected Then
                c = Me.ColorTable.CommonColorTable.CheckedSelectedBackground
            Else
                c = Me.ColorTable.CommonColorTable.CheckedBackground
            End If

            Using b As New SolidBrush(c)
                e.Graphics.FillRectangle(b, rect)
            End Using
            Using p As New Pen(Me.ColorTable.CommonColorTable.SelectedBorder)
                e.Graphics.DrawRectangle(p, rect)
            End Using

            'TODO: draw vs2010 checkmark
            e.Graphics.DrawImage(e.Image, New Point(5, 3))
        End Sub

        Protected Overrides Sub OnRenderImageMargin(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            MyBase.OnRenderImageMargin(e)

            ' Dropdown background gradient
            Dim bgRect As New Rectangle(0, -1, e.ToolStrip.Width, e.ToolStrip.Height + 1)
            Using b As New LinearGradientBrush(bgRect,
                                               Me.ColorTable.DropdownGradientTop,
                                               Me.ColorTable.DropdownGradientBottom,
                                               LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(b, bgRect)
            End Using

            ' Image margin
            Using b As New SolidBrush(Me.ColorTable.ImageMargin)
                e.Graphics.FillRectangle(b, e.AffectedBounds)
            End Using
        End Sub

        Protected Overrides Sub OnRenderSeparator(ByVal e As System.Windows.Forms.ToolStripSeparatorRenderEventArgs)
            MyBase.OnRenderSeparator(e)
            Dim x1 As Integer = 28
            Dim x2 As Integer = e.Item.Width
            Dim y As Integer = 3
            Using p As New Pen(Me.ColorTable.Separator)
                e.Graphics.DrawLine(p, x1, y, x2, y)
            End Using
        End Sub

#End Region

#Region " Misc "

        Protected Overrides Sub OnRenderArrow(ByVal e As System.Windows.Forms.ToolStripArrowRenderEventArgs)
            e.ArrowColor = Me.ColorTable.CommonColorTable.Arrow
            MyBase.OnRenderArrow(e)
        End Sub

#End Region

    End Class

End Namespace