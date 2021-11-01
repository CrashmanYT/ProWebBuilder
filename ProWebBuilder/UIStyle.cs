using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProWebBuilder
{

    // ColorTable
    class UIColorTable : ProfessionalColorTable
    {
        
    }

    // Style For ProWebBuilder UI
    class UIStyle  : ToolStripProfessionalRenderer
    {
        Color defaultUIColor = Color.LightBlue;


        public UIStyle() : base (new UIColorTable())
        {
            
        }

        public static void initUIStyle(MenuStrip menubar)
        {
            menubar.Renderer = new UIStyle();
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                e.Item.BackColor = Color.White;
                base.OnRenderMenuItemBackground(e);
            } else
            {
                Rectangle menuItemBackground = new Rectangle(Point.Empty, e.Item.Size);
                Color selectedBgColor = e.Item.Selected ? defaultUIColor : Color.Transparent;
                using (SolidBrush brush = new SolidBrush(selectedBgColor))
                    e.Graphics.FillRectangle(brush, menuItemBackground);
            }
        }

    }
}
