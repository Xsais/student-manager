using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student_manager.info.entity
{
    public abstract class Entity
    {
        private readonly List<Entity> _links = new List<Entity>();

        public Entity this[int index] => _links[index];

        public void AddLink(Entity link)
        {
            if (link == null && _links.FirstOrDefault(entity => entity.Equals(link)) != null)
            {
                return;
            }

            _links.Add(link);
        }

        public void RemoveLink(int index) => _links.RemoveAt(index);

        public void RemoveLink(string id)
        {

            var selected = _links.FirstOrDefault(entity => entity.ID.Equals(id));

            if (selected == null)
            {

                return;
            }

            RemoveLink(_links.IndexOf(selected));
        }

        public string ID { get; set; }

        public Entity(string id)
        {

            ID = id;
        }

        public Entity()
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
            {

                return false;
            }

            return string.Equals(((Entity)obj).ID, ID);
        }

        public bool IsEmpty() => ID == null || ID.Equals("");
    }
}
