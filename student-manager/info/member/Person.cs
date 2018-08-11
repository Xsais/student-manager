using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using student_manager.info.entity;

namespace student_manager.info
{
    public abstract class Person : Entity
    {
        private readonly Name _fullName = new Name("", "");
        
        public Name FullName => _fullName;

        public string FirstName
        {
            get => _fullName.FirstName;
            set => _fullName.FirstName = value;
        }

        public string LastName
        {
            get => _fullName.LastName;
            set => _fullName.LastName = value;
        }

        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-20);

        public Gender Gender { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public Person(string id, string first, string last, DateTime birthDate, Gender gender, DateTime startDate) : base(id)
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
