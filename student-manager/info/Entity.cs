using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_manager.info.entity
{
    public abstract class Entity
    {
        public string ID { get; set; }

        public Entity(string id)
        {

            ID = id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
            {

                return false;
            }

            return ((Entity)obj).ID == ID;
        }
    }
}
