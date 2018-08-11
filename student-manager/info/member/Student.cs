using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace student_manager.info
{
    public class Student : Person
    {
        public Student(string id, string first, string last, DateTime birthDate, Gender gender, DateTime startDate) 
            : base(id, first, last, birthDate, gender, startDate)
        {

        }

        public Student() : base()
        {

        }
    }
}
