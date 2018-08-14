using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_manager.info
{
    public class Professor : Person
    {

        private static readonly List<Professor> _population = new List<Professor>();

        public static IEnumerable<Professor> All => _population;

        public static int Count => _population.Count;

        public Professor(string id, string first, string last, DateTime birthDate, Gender gender, DateTime startDate)
            : base(id, first, last, birthDate, gender, startDate)
        {
            Reconnect();
        }

        public Professor() : base()
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
