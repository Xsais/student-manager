/**
 * File: Course.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles the cretion and handling of an course data
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
    public class Course : Entity
    {
        private static readonly List<Course> _population = new List<Course>();

        public static IEnumerable<Course> All => _population;

        public static int Count => _population.Count;

        public string Name { get; set; }

        public int Capacity { get; set; } = 100;

        public double Credits { get; set; } = 3;

        public Course(string id, string name, int capacity, double credits) : base(id)
        {
            Name = name;
            Capacity = capacity;
            Credits = credits;

            Reconnect();
        }

        public Course() : base()
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