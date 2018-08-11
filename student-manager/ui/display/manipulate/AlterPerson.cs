using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using student_manager.info;
using student_manager.info.entity;
using student_manager.ui.functionality;

namespace student_manager.ui.display.manipulate
{
    public partial class AlterPerson : AlterBox
    {
        private Person _person;

        public override Entity Entity
        {

            get => base.Entity;
            set
            {
                base.Entity = value;

                if (!(value is Person))
                {
                    return;
                }

                _person = (Person) value;

                errID.Text = _person.ID;
                errFirst.Text = _person.FirstName;
                errLast.Text = _person.LastName;
                dpStart.Value = _person.StartDate;
                dpBirth.Value = _person.BirthDate;
                cbGender.SelectedIndex = (int)_person.Gender;
            }
        }

        public AlterPerson()
        {
            InitializeComponent();

            cbGender.SelectedIndex = 0;
        }

        private void SavePerson(object sender, EventArgs e)
        {

            if (_entity == null || !_isClean)
            {
                return;
            }
            _person.ID = errID.Text;
            _person.FirstName = errFirst.Text;
            _person.LastName = errLast.Text;
            _person.StartDate = dpStart.Value;
            _person.BirthDate = dpBirth.Value;
            _person.Gender = (Gender)cbGender.SelectedIndex;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void AbortRequested(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ValidateID(object sender, EventArgs e)
        {
            if (IDVerifacator == null) {

                return;
            }

            if (!IDVerifacator.Invoke(errID.Text)) {

                _isClean = false;
                errID.Status = Status.Normal;
                return;
            }

            _isClean = true;
            errID.Status = Status.Error;

            errID.Focus();
        }

        private void ValidateRequired(object sender, EventArgs e)
        {
            if (!(sender is ErrorTextBox))
            {
                return;
            }

            var errBox = ((ErrorTextBox)sender);

            if (string.IsNullOrWhiteSpace(errBox.Text))
            {

                _isClean = false;
                errBox.Status = Status.Normal;
            }

            _isClean = true;
            errBox.Status = Status.Error;

            errBox.Focus();
        }
    }
}