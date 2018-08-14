/**
 * File: Professor.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles the managment of professors
 *
 * Group Members:
 *    - Emily Ramanna
 *    - James Grau
 *    - Nathaniel Primo
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student_manager.info.member;

namespace student_manager.info
{
    public class Professor : Person
    {
        private static readonly List<Professor> _population = new List<Professor>();

        public static IEnumerable<Professor> All => _population;

        public static int Count => _population.Count;

        public Professor(string id, string first, string last, DateTime birthDate, Gender gender, DateTime startDate)
            : base(id, first, last, birthDate, gender, startDate)
        {
            Reconnect();
        }

        public Professor() : base()
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