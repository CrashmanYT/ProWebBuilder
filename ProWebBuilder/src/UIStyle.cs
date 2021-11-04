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


    // TabControl Style
    class TabControlStyle
    {
        public TabControlStyle(TabControl[] tabControls)
        {
            foreach(var tabControl in tabControls)
            {
                tabControl.DrawItem += new DrawItemEventHandler(tabControl_OnDrawItem);
            }
        }

        // Draw TabControl Style
        private void tabControl_OnDrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush selectedTabPageBackColor = new SolidBrush(Color.FromArgb(0, 122, 204));
            SolidBrush defaultTabPageBackColor = new SolidBrush(Color.CornflowerBlue);
            Color selectedTabForeColor = Color.White;
            Color defaultTabPageForeColor = Color.Black;
            TabControl tabPages = ((TabControl)sender);
            TabPage tabPage = tabPages.TabPages[e.Index];
            Rectangle tabPageRect = tabPages.GetTabRect(e.Index);

            if (e.Index == ((TabControl)sender).SelectedIndex)
            {
                e.Graphics.FillRectangle(selectedTabPageBackColor, e.Bounds);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabPageRect, selectedTabForeColor);

            }
            else
            {
                e.Graphics.FillRectangle(defaultTabPageBackColor, e.Bounds);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabPageRect, defaultTabPageForeColor);
            }
            
        }
   
    }

    // Style For ProWebBuilder UI
    class UIStyle  : ToolStripProfessionalRenderer
    {
        Color defaultSelectedBackColor = Color.CornflowerBlue;
        Color defaultMarginBackColor = Color.WhiteSmoke;
        Color defaultBackColor = Color.WhiteSmoke;
        Color defaultForeColor = Color.Black;
        Color defaultSelectedForeColor = Color.White;


        public UIStyle() : base (new UIColorTable())
        {
            
        }

        public static void initUIStyle(MenuStrip menubar, ToolStrip toolstrip, Panel[] panels, ListView[] listViews, TabPage[] tabPages, Label[] labels, TabControl[] tabControls)
        {            

            menubar.Renderer = new UIStyle();
            menubar.BackColor = Color.FromArgb(214, 219, 233);
            toolstrip.Renderer = new UIStyle();
            foreach (Panel panel in panels)
            {
                panel.BackColor = Color.CornflowerBlue;
            }
            foreach(Label label in labels)
            {
                label.ForeColor = Color.White;
            }
            TabControlStyle tabControlStyle = new TabControlStyle(tabControls);

        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                e.Item.BackColor = defaultMarginBackColor;
                base.OnRenderMenuItemBackground(e);
                e.Item.ForeColor = defaultForeColor;
            }
            else
            {
                Rectangle menuItemBackground = new Rectangle(Point.Empty, e.Item.Size);
                Color selectedBgColor = e.Item.Selected ? defaultSelectedBackColor : Color.Transparent;
                using (SolidBrush brush = new SolidBrush(selectedBgColor))
                    e.Graphics.FillRectangle(brush, menuItemBackground);
                e.Item.ForeColor = defaultSelectedForeColor;

            }
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(defaultBackColor))
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
        }
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.ToolStrip.BackColor = defaultMarginBackColor;
        }
      

    }
}
