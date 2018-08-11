using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_manager.info
{
    public class Professor : Person
    {

        public Professor(string id, string first, string last, DateTime birthDate, Gender gender, DateTime startDate)
            : base(id, first, last, birthDate, gender, startDate)
        {
        }

        public Professor() : base()
        {
        }
    }
}
