/**
 * File: Program.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles the cretion and handling of an Program data
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
using student_manager.info.entity;

namespace student_manager.info.opportunity
{
    public class Program : Entity
    {
        private static readonly List<Program> _population = new List<Program>();

        public static IEnumerable<Program> All => _population;

        public static int Count => _population.Count;

        public string Name { get; set; }

        public TimeSpan Duration { get; set; } = TimeSpan.FromDays(730);

        public bool IsCOOP { get; set; }

        public Outcomes Outcome { get; set; } = Outcomes.Diploma;

        public Program(string id, string name, TimeSpan duration, bool isCOOP, Outcomes outcome) : base(id)
        {
            Name = name;
            Duration = duration;
            IsCOOP = isCOOP;
            Outcome = outcome;

            Reconnect();
        }

        public Program() : base()
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