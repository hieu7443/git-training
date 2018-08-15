using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface ITemplate : IBaseItem
    {
    }
    public class Template : ITemplate
    {
        public Template() { }
        internal Template(Database.Template data)
        {
            if (data != null)
            {
                ID = data.ID;
                Name = data.Name;
                Created = data.Created;
                Updated = data.Updated;
            }
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}