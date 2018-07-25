using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_manager.info
{
    public class Professor : Person
    {

        public bool IsFullTime { get; set; }

        public Professor(string id, Name fullName, DateTime birthDate, Gender gender, DateTime startDate, bool isFullTime)
            : base(id, fullName, birthDate, gender, startDate)
        {
            IsFullTime = isFullTime;
        }
    }
}
