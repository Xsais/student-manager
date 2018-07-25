using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student_manager.info.entity;

namespace student_manager.info
{
    public abstract class Person : Entity
    {

        public Name FullName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public DateTime StartDate { get; set; }

        public Person(string id, Name fullName, DateTime birthDate, Gender gender, DateTime startDate) : base(id)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            StartDate = startDate;
        }

        public override string ToString()
        {
            return $"{FullName.FirstName} {FullName.LastName} ({ID})";
        }
    }
}
