using student_manager.info;
using student_manager.info.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_manager.ui.display.manipulate
{
    public partial class AlterBox : Form
    {
        private Entity _entity;

        public virtual Entity Entity
        {

            get => _entity;
            set
            {
                if (value == null || value == _entity)
                {

                    return;
                }

                    switch (value)
                    {
                        case Student _:
                            
                            lblTitle.Text = value.IsEmpty() ? "New Student" : "Edit Student";

                            break;
                        case Professor _:

                            lblTitle.Text = value.IsEmpty() ? "New Professor" : "Edit Professor";

                            break;
                    }

                _entity = value;
                }
        }

        public AlterBox()
        {
            InitializeComponent();
        }

        private void CancelRequested(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
