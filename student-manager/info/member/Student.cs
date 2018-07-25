using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_manager.info
{
    public class Student : Person
    {
        public Student(string id, Name fullName, DateTime birthDate, Gender gender, DateTime startDate) 
            : base(id, fullName, birthDate, gender, startDate)
        {

        } 
    }
}
