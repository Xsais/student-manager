using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student_manager.info.entity;

namespace student_manager.info.opportunity
{
    public class Course : Entity
    {

        private static readonly List<Course> _population = new List<Course>();

        public static IEnumerable<Course> All => _population;

        public static int Count => _population.Count;
        
        public string Name { get; set; }

        public int Capacity { get; set; } = 100;

        public double Credits { get; set; } = 3;

        public Course(string id, string name, int capacity, double credits) : base(id)
        {
            Name = name;
            Capacity = capacity;
            Credits = credits;
            
            Reconnect();
        }

        public Course() : base()
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
