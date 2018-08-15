using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface IField : IBaseItem
    {
        Template Template { get; set; }
    }
    public class Field : IField
    {
        public Field() { }
        internal Field(Database.Field data)
        {
            if (data != null)
            {
                ID = data.ID;
                Name = data.Name;
                Created = data.Created;
                Updated = data.Updated;
                Template = new Template(data.Template);
            }
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Template Template { get; set; }
    }
}