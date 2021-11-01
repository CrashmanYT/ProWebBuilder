using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProWebBuilder
{
    public partial class ProWebBuilder : Form
    {
        public ProWebBuilder()
        {
            InitializeComponent();
            UIStyle.initUIStyle(Menubar);
        }
    }
}
