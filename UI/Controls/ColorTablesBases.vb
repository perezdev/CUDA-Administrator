Imports System.Drawing

Namespace ColorTables

    ''' <summary>
    ''' Holds the colors for elements common to all strips, such as selection colors.
    ''' </summary>
    ''' <remarks>Inherit this class, override all properties and return your desired colors.</remarks>
    Public MustInherit Class Vs2010CommonColorTable

        ''' <summary>
        ''' Gets the color of the text on all items.
        ''' </summary>
        ''' <returns>The color of the text on all items.</returns>
        Public MustOverride ReadOnly Property TextColor As Color

        ''' <summary>
        ''' Gets the color of the border of a selected item.
        ''' </summary>
        ''' <returns>The color of the border of a selected item.</returns>
        Public MustOverride ReadOnly Property SelectedBorder As Color

        ''' <summary>
        ''' Gets the top color of the gradient making up a selection rectangle.
        ''' </summary>
        ''' <returns>The top color of the gradient making up a selection rectangle.</returns>
        Public MustOverride ReadOnly Property SelectedGradientTop As Color

        ''' <summary>
        ''' Gets the bottom color of the gradient making up a selection rectangle.
        ''' </summary>
        ''' <returns>The bottom color of the gradient making up a selection rectangle.</returns>
        Public MustOverride ReadOnly Property SelectedGradientMiddle As Color

        ''' <summary>
        ''' Gets the color of the solid bottom making up a selection rectangle.
        ''' </summary>
        ''' <returns>The color of the solid bottom making up a selection rectangle.</returns>
        Public MustOverride ReadOnly Property SelectedGradientBottom As Color

        ''' <summary>
        ''' Gets the background color of a pressed item.
        ''' </summary>
        ''' <returns>The background color of a pressed item.</returns>
        Public MustOverride ReadOnly Property PressedBackground As Color

        ''' <summary>
        ''' Gets the background color of a checked item.
        ''' </summary>
        ''' <returns>The background color of a checked item.</returns>
        Public MustOverride ReadOnly Property CheckedBackground As Color

        ''' <summary>
        ''' Gets the background color of a checked and selected item.
        ''' </summary>
        ''' <returns>The background color of a checked and selected item.</returns>
        Public MustOverride ReadOnly Property CheckedSelectedBackground As Color

        ''' <summary>
        ''' Gets the border color of a dropdown menu.
        ''' </summary>
        ''' <returns>The border color of a dropdown menu.</returns>
        Public MustOverride ReadOnly Property DropdownBorder As Color

        ''' <summary>
        ''' Gets the color of the arrow for both menus and dropdown buttons.
        ''' </summary>
        ''' <returns>The color of the arrow for both menus and dropdown buttons.</returns>
        Public MustOverride ReadOnly Property Arrow As Color

    End Class

    ''' <summary>
    ''' Holds the colors used by a <see cref="Vs2010Renderers.Renderers.Vs2010MenuStripRenderer" />.
    ''' </summary>
    ''' <remarks>Inherit this class, override all properties and return your desired colors.</remarks>
    Public MustInherit Class Vs2010MenuStripColorTable

        ''' <summary>
        ''' Gets the <see cref="Vs2010CommonColorTable" /> used to draw the common elements.
        ''' </summary>
        ''' <returns>The <see cref="Vs2010CommonColorTable" /> used to draw the common elements.</returns>
        ''' <remarks>Override this property and return an instance of your desired <see cref="Vs2010CommonColorTable" />.</remarks>
        Public MustOverride ReadOnly Property CommonColorTable As Vs2010CommonColorTable

        ''' <summary>
        ''' Gets the color of the border underneath the <see cref="Vs2010Renderers.Controls.Vs2010MenuStrip" />.
        ''' </summary>
        ''' <returns>The color of the border underneath the <see cref="Vs2010Renderers.Controls.Vs2010MenuStrip" />.</returns>
        Public MustOverride ReadOnly Property BottomBorder As Color

        ''' <summary>
        ''' Gets the background top gradient color.
        ''' </summary>
        ''' <returns>The background top gradient color.</returns>
        Public MustOverride ReadOnly Property BackgroundGradientTop As Color

        ''' <summary>
        ''' Gets the background bottom gradient color.
        ''' </summary>
        ''' <returns>The background bottom gradient color.</returns>
        Public MustOverride ReadOnly Property BackgroundGradientBottom As Color

        ''' <summary>
        ''' Gets the background color of a menu header item that is currently dropped down.
        ''' </summary>
        ''' <returns>The background color of a menu header item that is currently dropped down.</returns>
        Public MustOverride ReadOnly Property DroppedDownItemBackground As Color

        ''' <summary>
        ''' Gets the background top gradient color of a dropdown menu.
        ''' </summary>
        ''' <returns>The background top gradient color of a dropdown menu.</returns>
        Public MustOverride ReadOnly Property DropdownGradientTop As Color

        ''' <summary>
        ''' Gets the background bottom gradient color of a dropdown menu.
        ''' </summary>
        ''' <returns>The background bottom gradient color of a dropdown menu.</returns>
        Public MustOverride ReadOnly Property DropdownGradientBottom As Color

        ''' <summary>
        ''' Gets the color of the image margin of a dropdown menu.
        ''' </summary>
        ''' <returns>The color of the image margin of a dropdown menu.</returns>
        Public MustOverride ReadOnly Property ImageMargin As Color

        ''' <summary>
        ''' Gets the color of a separator item.
        ''' </summary>
        ''' <returns>The color of a separator item.</returns>
        Public MustOverride ReadOnly Property Separator As Color

    End Class

    Public MustInherit Class Vs2010ToolStripColorTable

        ''' <summary>
        ''' Gets the <see cref="Vs2010CommonColorTable" /> used to draw the common elements.
        ''' </summary>
        ''' <returns>The <see cref="Vs2010CommonColorTable" /> used to draw the common elements.</returns>
        ''' <remarks>Override this property and return an instance of your desired <see cref="Vs2010CommonColorTable" />.</remarks>
        Public MustOverride ReadOnly Property CommonColorTable As Vs2010CommonColorTable

        ''' <summary>
        ''' Gets the background color.
        ''' </summary>
        ''' <returns>The background top gradient color.</returns>
        Public MustOverride ReadOnly Property Background As Color

        ''' <summary>
        ''' Gets the border color.
        ''' </summary>
        ''' <returns>The border color.</returns>
        Public MustOverride ReadOnly Property Border As Color

        ''' <summary>
        ''' Gets the color of a parent <see cref="ToolStripPanel" />.
        ''' </summary>
        ''' <returns>The color of a parent <see cref="ToolStripPanel" />.</returns>
        ''' <remarks>When parented by a <see cref="ToolStripPanel" />, the background of this <see cref="ToolStripPanel" /> will be set to this color.</remarks>
        Public MustOverride ReadOnly Property ParentBackground As Color

        ''' <summary>
        ''' Gets the color of the grip handle.
        ''' </summary>
        ''' <returns>The color of the grip handle.</returns>
        Public MustOverride ReadOnly Property Grip As Color

        ''' <summary>
        ''' Gets the color of a separator item.
        ''' </summary>
        ''' <returns>The color of a separator item.</returns>
        Public MustOverride ReadOnly Property Separator As Color

        ''' <summary>
        ''' Gets the background color of the overflow indicator.
        ''' </summary>
        ''' <returns>The background color of the overflow indicator.</returns>
        Public MustOverride ReadOnly Property OverflowBackground As Color

    End Class

End Namespace
