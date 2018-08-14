/**
 * File: Student.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles the managment of students
 *
 * Group Members:
 *    - Emily Ramanna
 *    - James Grau
 *    - Nathaniel Primo
**/

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using student_manager.info.member;

namespace student_manager.info
{
    public class Student : Person
    {
        private static readonly List<Student> _population = new List<Student>();

        public static IEnumerable<Student> All => _population;

        public static int Count => _population.Count;

        public Student(string id, string first, string last, DateTime birthDate, Gender gender, DateTime startDate)
            : base(id, first, last, birthDate, gender, startDate)
        {
            Reconnect();
        }

        public Student() : base()
        {
            Reconnect();
        }

        /// <summary>
        /// Removes the entity from the global allage
        /// </summary>
        public void Disconnet()
        {
            _population.Remove(this);
        }


        /// <summary>
        /// Adds an entity to the global allage
        /// </summary>
        public void Reconnect()
        {
            _population.Add(this);
        }
    }
}