using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_manager.ui.functionality
{
    public partial class SearchBox : UserControl
    {
        public EventHandler Searched;

        public override string Text { get => txtSearchBox.Text; set => txtSearchBox.Text = value; }

        public SearchBox()
        {
            InitializeComponent();
        }

        private void Search(object sender, EventArgs e)
        {
            Searched?.Invoke(this, e);
        }

        private void Searching(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                if (picSearch.Visible)
                {
                    picSearch.Visible = false;
                    pcExit.Visible = true;
                }
            }
            else
            {

                picSearch.Visible = true;
                pcExit.Visible = false;
            }
        }

        private void ClearSearch(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";
            Searched?.Invoke(this, e);
        }
    }
}
