Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Namespace Controls

    '<Designer(GetType(Vs2010TabControlDesigner))> _
    Public Class Vs2010TabControl
        Inherits TabControl

        <DllImport("user32.dll")>
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Int32, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function

        'These are required for calculating the tab size properly
        Private Const WM_SETFONT = &H30
        Private Const WM_FONTCHANGE = &H1D
        Private Const TAB_HEIGHT As Integer = 26

        Private _HotTrackIndex As Integer = -1

        Public Sub New()
            Me.DrawMode = TabDrawMode.OwnerDrawFixed

            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.UserPaint, True)

            Me.TabTextAlignment = StringAlignment.Near
            Me.BackColor = Me.Renderer.ColorTable.Background
            Me.Active = True
            Me.ItemSize = New Size(Me.ItemSize.Width, TAB_HEIGHT)
            Me.HotTrack = True
        End Sub

        'I made this for modularity, so the tab control can easily use different renderers
        'You can give it a different Renderers.Vs2010TabControlRenderer if you wanted to
        'or you can just ignore this
        Private _Renderer As Renderers.Vs2010TabControlRenderer
        Public Property Renderer() As Renderers.Vs2010TabControlRenderer
            Get
                If _Renderer Is Nothing Then
                    _Renderer = New Renderers.Vs2010TabControlRenderer()
                End If
                Return _Renderer
            End Get
            Set(ByVal value As Renderers.Vs2010TabControlRenderer)
                _Renderer = value
            End Set
        End Property

        Private _TabTextAlignment As StringAlignment
        Public Property TabTextAlignment() As StringAlignment
            Get
                Return _TabTextAlignment
            End Get
            Set(ByVal value As StringAlignment)
                _TabTextAlignment = value
            End Set
        End Property

        'This indicates whether it is the 'active' tab control. In VS for example, if you have multiple tabs side-by-side (in tab groups),
        'the tab control with the focused tab (this is what i call 'active') looks different (other colors) 
        Private _Active As Boolean
        Public Property Active() As Boolean
            Get
                Return _Active
            End Get
            Set(ByVal value As Boolean)
                _Active = value
                Me.Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            Me.OnFontChanged(EventArgs.Empty)
        End Sub

        'This takes care of tab text measurement
        'if you are just drawing using GDI+ the tab size is off (too small for small text, too large for long text)
        Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
            MyBase.OnFontChanged(e)
            Dim hFont As IntPtr = Me.Font.ToHfont()
            SendMessage(Me.Handle, WM_SETFONT, hFont, New IntPtr(-1))
            SendMessage(Me.Handle, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero)
            Me.UpdateStyles()
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)

            'Invalidating the tabs
            If e.Button = System.Windows.Forms.MouseButtons.Left Then
                For i As Integer = 0 To Me.TabCount - 1
                    Me.Invalidate(Me.GetTabRect(i))
                Next
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)

            'Invalidating the tabs
            For i As Integer = 0 To Me.TabCount - 1
                Me.Invalidate(Me.GetTabRect(i))
            Next
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseMove(e)

            If Me.HotTrack Then
                'Invalidating the tabs
                For i As Integer = 0 To Me.TabCount - 1
                    Dim rect = Me.GetTabRect(i)

                    If rect.Contains(e.Location) Then
                        If _HotTrackIndex <> -1 Then Me.Invalidate(Me.GetTabRect(_HotTrackIndex))
                        _HotTrackIndex = i
                        Me.Invalidate(rect)
                        Exit For
                    End If
                Next i
            End If
        End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            MyBase.OnMouseLeave(e)

            'Invalidating the tabs
            If Me.HotTrack AndAlso _HotTrackIndex <> -1 AndAlso _HotTrackIndex < Me.TabCount Then
                Me.Invalidate(Me.GetTabRect(_HotTrackIndex))
                _HotTrackIndex = -1
            End If
        End Sub

        Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
            MyBase.OnDrawItem(e)

            'I think this was for testing purposes, dunno but you can probably ignore/remove it
            Dim rect = e.Bounds
            rect.Inflate(5, 5)
            e.Graphics.DrawRectangle(Pens.Red, rect)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)

            ' Tab headers
            For i As Integer = 0 To Me.TabPages.Count - 1
                Dim tab = Me.TabPages(i)

                'This is just trial and error (+1, +3, -5, etc)
                Dim tabRect As Rectangle = Me.GetTabRect(i)
                tabRect = New Rectangle(tabRect.X + 1, tabRect.Y + 3, tabRect.Width, tabRect.Height - 5)

                Dim tabHeaderState = Me.GetTabHeaderState(i)
                Dim headerEventArgs As New Renderers.Vs2010TabControlRenderer.PaintHeaderEventArgs(e.Graphics, _
                                                                                         tabRect, _
                                                                                         tab, _
                                                                                         tabHeaderState, _
                                                                                         Me.TabTextAlignment)
                'The actual drawing is all done in the Renderer for modularity
                Me.Renderer.OnPaintTabHeader(headerEventArgs)
            Next

            ' Borders
            Dim topBorderRect As New Rectangle(4, Me.ItemSize.Height, Me.Width - 8, 4)
            Dim bottomBorderRect As New Rectangle(4, Me.Height - 4, Me.Width - 8, 4)
            Dim borderEventArgs As New Renderers.Vs2010TabControlRenderer.PaintBordersEventArgs(e.Graphics, _
                                                                                      topBorderRect, _
                                                                                      Renderers.Vs2010TabControlRenderer.PaintBordersEventArgs.BorderSide.Top, _
                                                                                      Me.Active)
            Me.Renderer.OnPaintBorders(borderEventArgs)
            borderEventArgs = New Renderers.Vs2010TabControlRenderer.PaintBordersEventArgs(e.Graphics, _
                                                                                bottomBorderRect, _
                                                                                Renderers.Vs2010TabControlRenderer.PaintBordersEventArgs.BorderSide.Bottom, _
                                                                                Me.Active)
            Me.Renderer.OnPaintBorders(borderEventArgs)
        End Sub

        Private Function GetTabHeaderState(ByVal tabIndex As Integer) As Renderers.Vs2010TabControlRenderer.PaintHeaderEventArgs.TabHeaderState
            Dim tab = Me.TabPages(tabIndex)
            Dim state As Renderers.Vs2010TabControlRenderer.PaintHeaderEventArgs.TabHeaderState

            If Me.SelectedTab Is tab Then
                If Me.Active Then
                    state = Renderers.Vs2010TabControlRenderer.PaintHeaderEventArgs.TabHeaderState.Active
                Else
                    state = Renderers.Vs2010TabControlRenderer.PaintHeaderEventArgs.TabHeaderState.Inactive
                End If
            ElseIf tabIndex = _HotTrackIndex Then
                state = Renderers.Vs2010TabControlRenderer.PaintHeaderEventArgs.TabHeaderState.HotTracking
            Else
                state = Renderers.Vs2010TabControlRenderer.PaintHeaderEventArgs.TabHeaderState.Normal
            End If
            Return state
        End Function

        Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaintBackground(pevent)

            Dim bgRect As New Rectangle(0, 0, Me.Width, Me.Height)
            Dim bgEventArgs As New PaintEventArgs(pevent.Graphics, bgRect)
            Me.Renderer.OnPaintTabHeadersBackground(bgEventArgs)
        End Sub

        Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
            MyBase.OnEnter(e)
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
            MyBase.OnLeave(e)
            Me.Invalidate()
        End Sub

    End Class

End Namespace