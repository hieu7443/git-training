using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface IProperty : IBaseItem
    {
        Field Field { get; set; }
        string Value { get; set; }
        string Language { get; set; }
    }
    public class Property : IProperty
    {
        public Property() { }
        internal Property(Database.Property data)
        {
            if (data != null)
            {
                ID = data.ID;
                Created = data.Created;
                Updated = data.Updated;
                Field = new Field(data.Field);
                Value = data.Value;
                Language = data.Language;
            }
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Field Field { get; set; }
        public string Value { get; set; }
        public string Language { get; set; }
    }
}