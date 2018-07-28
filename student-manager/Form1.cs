﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using student_manager.info;

namespace student_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            edStudents.SelectionChanged += (sender, args) =>
            {

                bool isVisible = edStudents.Selected != null;

                picEdit.Visible = isVisible;
                picMinus.Visible = isVisible;
                picLink.Visible = isVisible;
            };

            searchBox.Searched += (sender, e) =>
            {

                Console.WriteLine($"New User Search: \"{searchBox.Text}\"");
            };

            edStudents.AddEntity(new Professor("A115H", new info.Name("Max", "Lee"), DateTime.Now, Gender.Male, DateTime.Now, true));
            edStudents.AddEntity(new Student("A115H", new info.Name("Art", "Punk"), DateTime.Now, Gender.Male, DateTime.Now));
            edStudents.AddEntity(new Student("A115H", new info.Name("Art", "Punk"), DateTime.Now, Gender.Male, DateTime.Now));
            edStudents.AddEntity(new Student("A115H", new info.Name("Art", "Punk"), DateTime.Now, Gender.Male, DateTime.Now));
            edStudents.AddEntity(new Student("A115H", new info.Name("Art", "Punk"), DateTime.Now, Gender.Male, DateTime.Now));
            edStudents.AddEntity(new Student("A2215H", new info.Name("Art", "Punk"), DateTime.Now, Gender.Male, DateTime.Now));
        }
    }
}
