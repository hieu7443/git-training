using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface IItem : IBaseItem
    {
        Link[] Links { get; set; }
        Presentation Presentation { get; set; }
    }
    public class Item : IItem
    {
        public Item() { }
        internal Item(Database.Item data)
        {
            if (data != null)
            {
                ID = data.ID;
                Name = data.Name;
                Created = data.Created;
                Updated = data.Updated;
                Links = data.Links?.Select(l => new Link(l)).ToArray();
                _Properties = data.Properties?.Select(p => new Property(p)).ToArray();
                Presentation = new Presentation(data.Presentations?.FirstOrDefault());
            }
        }
        private Property[] _Properties { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Link[] Links { get; set; }
        public Presentation Presentation { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}