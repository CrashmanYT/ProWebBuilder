using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProWebBuilder.src
{
     class PWBEvent
    {
        ProWebBuilder pwbForm;

        public PWBEvent(ProWebBuilder pwbForm)
        {
            this.pwbForm = pwbForm;
        }

        public static void InitProWebBuilderEvent(ProWebBuilder pwrForm)
        {
            PWBEvent events = new PWBEvent(pwrForm);
            pwrForm.DesignAndCodeTab.SelectedIndexChanged += new EventHandler(events.OnDesignAndCodeTabChanged);
            pwrForm.OpenSubMenuItem.Click += new EventHandler(events.OnOpenClicked);
        }

        //ProWebBuilder Event

        //TabChanged Event
        private void OnDesignAndCodeTabChanged(object sender, EventArgs e)
        {
            
        }

        //Click Event
        private void OnOpenClicked(object sender, EventArgs e)
        {
            pwbForm.OpenDialog.FileName = "";
            pwbForm.OpenDialog.Title = "Opening a file...";
            pwbForm.OpenDialog.Filter = "HTML Files|*.html|CSS Files|*.css|All Files|*.*";
            if (pwbForm.OpenDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

    }
}
