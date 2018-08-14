using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using student_manager.info.opportunity;

namespace student_manager.info.entity
{
    public abstract class Entity
    {

        private readonly List<Entity> _links = new List<Entity>();

        public IEnumerable<Entity> Links => _links;

        public Entity this[int index] => _links[index];

        public void AddLink(Entity link)
        {
            if (link == null && _links.FirstOrDefault(entity => entity.Equals(link)) != null)
            {
                return;
            }

            _links.Add(link);
        }

        public bool IsLinked(Entity link) {

            if (link == null) {

                return false;
            }

            return _links.Contains(link);
        }

        public int TotalLinks(LinkType linkType)
        {
            if (_links.Count <= 0)
            {
                return 0;
            }
            
            switch (linkType)
            {
                case LinkType.Courses:

                    return _links.Count(entity => entity is Course);
                case LinkType.Programs:
                    
                    return _links.Count(entity => entity is opportunity.Program);
                case LinkType.Students:
                    
                    return _links.Count(entity => entity is Student);
                case LinkType.Professors:
                    
                    return _links.Count(entity => entity is Professor);
            }

            return 0;
        }

        public IEnumerable<Entity> PullLinks(LinkType linkType)
        {
            if (_links.Count <= 0)
            {
                return null;
            }
            
            switch (linkType)
            {
                case LinkType.Courses:

                    return _links.Where(entity => entity is Course);
                case LinkType.Programs:
                    
                    return _links.Where(entity => entity is opportunity.Program);
                case LinkType.Students:
                    
                    return _links.Where(entity => entity is Student);
                case LinkType.Professors:
                    
                    return _links.Where(entity => entity is Professor);
            }

            return null;
        }

        public void RemoveLink(int index) => _links.RemoveAt(index);

        public void RemoveLink(Entity entity) => RemoveLink(entity.ID);

        public void RemoveLink(string id)
        {

            var selected = _links.FirstOrDefault(entity => entity.ID.Equals(id));

            if (selected == null)
            {

                return;
            }

            RemoveLink(_links.IndexOf(selected));
        }

        public void RemoveLinks(IEnumerable<Entity> entities)
        {
            if (entities == null)
            {
                return;
            }
            
            foreach (var entity in entities)
            {
                RemoveLink(entity);
            }
        }

        public string ID { get; set; } = string.Empty;

        public Entity(string id) : this()
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
