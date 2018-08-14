﻿/**
 * File: AlterPersson.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Allows for the modification of a person entity
 *
 * Group Members:
 *    - Emily Ramanna
 *    - James Grau
 *    - Nathaniel Primo
**/

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
using student_manager.info.member;
using student_manager.ui.functionality;

namespace student_manager.ui.display.manipulate
{
    public partial class AlterPerson : AlterBox
    {
        private Person _person;

        protected override bool isValidID(string ID) =>
            _entity.ID.Equals(ID) || Professor.All.Count(entity => entity.ID.Equals(ID)) == 0;

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
                cbGender.SelectedIndex = (int) _person.Gender;

                errID.Status = Status.Normal;
                errFirst.Status = Status.Normal;
                errLast.Status = Status.Normal;
            }
        }

        /// <summary>
        /// Init the box a creates all needed controls
        /// </summary>
        public AlterPerson()
        {
            InitializeComponent();

            cbGender.SelectedIndex = 0;
        }

        /// <summary>
        /// Saves a person that has been edited
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending arguments</param>
        private void SavePerson(object sender, EventArgs e)
        {
            if (_entity == null || !_isClean)
            {
                return;
            }

            if (Confirming != null && !_entity.IsEmpty())
            {
                Confirming.Invoke();
                DialogResult = DialogResult.Ignore;

                Close();
            }
            else
            {
                CleanUpEntity();

                DialogResult = DialogResult.OK;
            }

            Close();
        }

        /// <summary>
        /// Clears the display for the next use
        /// </summary>
        private void CleanUpEntity()
        {
            if (_entity == null)
            {
                return;
            }

            _person.ID = errID.Text;
            _person.FirstName = errFirst.Text;
            _person.LastName = errLast.Text;
            _person.StartDate = dpStart.Value;
            _person.BirthDate = dpBirth.Value;
            _person.Gender = (Gender) cbGender.SelectedIndex;

            _entity = null;
        }

        /// <summary>
        /// Raises an event when the user chooses to cancel altering
        /// </summary>
        /// <param name="sender">The sening object</param>
        /// <param name="e">Any sent arguments</param>
        private void AbortRequested(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ValidateID(object sender, EventArgs e)
        {
            // Makes sure the id field is not null or blank
            ValidateRequired(sender, e);

            // Shows an error message if the id is aleady taken
            if (_isClean && !isValidID(errID.Text))
            {
                _isClean = false;
                errID.Status = Status.Error;

                errID.ErrorText = $"The ID must be unique";
                errID.Text = "";

                errID.Focus();
            }
        }

        /// <summary>
        /// Validates an control when the focus is lost
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The sending event arguments</param>
        private void ValidateRequired(object sender, EventArgs e)
        {
            if (!(sender is ErrorTextBox))
            {
                return;
            }

            var errBox = (ErrorTextBox) sender;

            if (string.IsNullOrWhiteSpace(errBox.Text))
            {
                _isClean = false;
                errBox.Status = Status.Error;

                errBox.ErrorText = $"The {errBox.DisplayName} is required";

                errBox.Focus();
                return;
            }

            _isClean = true;
            errBox.Status = Status.Normal;
        }

        /// <summary>
        /// Allows for the approval of changes to be made
        /// </summary>
        /// <param name="confirmed">is the changes approved</param>
        public override void Confirm(bool confirmed)
        {
            if (confirmed)
            {
                CleanUpEntity();
            }

            _entity = null;
        }
    }
}