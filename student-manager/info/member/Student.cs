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

        private static readonly List<Student> _population = new List<Student>();

        public static IEnumerable<Student> All => _population;

        public static int Count => _population.Count;

        public Student(string id, string first, string last, DateTime birthDate, Gender gender, DateTime startDate) 
            : base(id, first, last, birthDate, gender, startDate)
        {
            Reconnect();
        }

        public Student() : base()
        {
            Reconnect();
        }

        public void Disconnet()
        {
            _population.Remove(this);
        }

        public void Reconnect()
        {
            _population.Add(this);
        }
    }
}
