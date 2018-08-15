using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface IRendering : IBaseItem
    {
        string Assembly { get; set; }
        string Controller { get; set; }
        string Action { get; set; }
    }
    public class Rendering : IRendering
    {
        public Rendering() { }
        internal Rendering(Database.Rendering data)
        {
            if (data != null)
            {
                ID = data.ID;
                Name = data.Name;
                Assembly = data.Assembly;
                Controller = data.Controller;
                Action = data.Action;
                Created = data.Created;
                Updated = data.Updated;
            }
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Assembly { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}