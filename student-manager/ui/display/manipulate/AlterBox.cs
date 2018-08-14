using student_manager.info;
using student_manager.info.entity;
using student_manager.info.opportunity;
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
    public abstract partial class AlterBox : Form
    {
        protected Entity _entity;

        public Action Confirming;

        public abstract void Confirm(bool confirmed = true);

        protected bool _isClean = true;

        protected abstract bool isValidID(string ID);

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
                        case Course _:

                            lblTitle.Text = value.IsEmpty() ? "New Course" : "Edit Course";

                        break;
                        case info.opportunity.Program _:

                            lblTitle.Text = value.IsEmpty() ? "New Program" : "Edit Program";

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
