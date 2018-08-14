using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student_manager.info.entity;

namespace student_manager.info.opportunity
{
    public class Program : Entity
    {

        private static readonly List<Program> _population = new List<Program>();

        public static IEnumerable<Program> All => _population;

        public static int Count => _population.Count;
        
        public string Name { get; set; }
        
        public TimeSpan Duration { get; set; } = TimeSpan.FromDays(730);

        public bool IsCOOP { get; set; }

        public Outcomes Outcome { get; set; } = Outcomes.Diploma;
        
        public Program(string id, string name, TimeSpan duration, bool isCOOP, Outcomes outcome) : base(id)
        {
            Name = name;
            Duration = duration;
            IsCOOP = isCOOP;
            Outcome = outcome;
            
            Reconnect();
        }

        public Program() : base()
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
