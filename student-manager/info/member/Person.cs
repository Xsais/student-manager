/**
 * File: Person.cs
 * Assignment: Final_Project
 * Creation date: August 6, 2018
 * Last Modified: August 14, 2018
 * Description: Handles the managment of professors and students
 *
 * Group Members:
 *    - Emily Ramanna
 *    - James Grau
 *    - Nathaniel Primo
**/

using System;
using student_manager.info.entity;

namespace student_manager.info.member
{
    public abstract class Person : Entity
    {
        public Name FullName { get; } = new Name("", "");

        public string FirstName
        {
            get => FullName.FirstName;
            set => FullName.FirstName = value;
        }

        public string LastName
        {
            get => FullName.LastName;
            set => FullName.LastName = value;
        }

        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-20);

        public Gender Gender { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public Person(string id, string first, string last, DateTime birthDate, Gender gender,
            DateTime startDate) : base(id)
        {
            FirstName = first;
            LastName = last;
            BirthDate = birthDate;
            Gender = gender;
            StartDate = startDate;
        }

        public Person() : base()
        {
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({ID})";
        }
    }
}