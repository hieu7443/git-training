using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface ILink : IBaseItem
    {
        string Url { get; set; }
    }
    public class Link : ILink
    {
        public Link() { }
        internal Link(Database.Link data)
        {
            if (data != null)
            {
                ID = data.ID;
                Url = data.Url;
                Created = data.Created;
                Updated = data.Updated;
            }
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}