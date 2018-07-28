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

        private void Search(object sender, EventArgs e) => Searched?.Invoke(this, e);
    }
}
