using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_manager.ui.display
{
    public partial class EntityDisplay : UserControl
    {
        public string Header {
            get
            {

                return lblheader.Text;
            } set
            {

                lblheader.Text = value;
            }
        }

        public string SubHeading
        {
            get
            {

                return lblSub.Text;
            }
            set
            {

                lblSub.Text = value;
            }
        }

        public string Additional
        {
            get
            {

                return lblAdditional.Text;
            }
            set
            {

                lblAdditional.Text = value;
            }
        }

        public string Flags
        {
            get
            {

                return lblTag.Text;
            }
            set
            {

                lblTag.Text = value;
            }
        }

        public EntityDisplay()
        {
            InitializeComponent();
        }

        private void ClickTrough(object sender, EventArgs e) => OnClick(e);

        private void DoubleClickThrough(object sender, EventArgs e)  => OnDoubleClick(e);
    }
}
