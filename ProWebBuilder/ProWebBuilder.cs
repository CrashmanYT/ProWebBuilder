using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProWebBuilder.src;

namespace ProWebBuilder
{
    public partial class ProWebBuilder : Form
    {
        public ProWebBuilder()
        {
            InitializeComponent();
            UIStyle.initUIStyle(Menubar, Toolbar, new Panel[] {ComponentListPanel, DesignAreaPanel, ToolboxPanel } ,new ListView[] {ToolboxList, ComponentList}, new TabPage[] {PropertiesTab, ProjectExplorerTab}, new Label[] {ComponentPanelLabel, ToolboxPanelLabel }, new TabControl[] {DesignAndCodeTab, PropertiesAndExplorerTab });
            PWBEvent.InitProWebBuilderEvent(this);
            
        }
        private void ExitSubMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
