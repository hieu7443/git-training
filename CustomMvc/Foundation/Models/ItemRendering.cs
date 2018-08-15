using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface IItemRendering : IBaseItem
    {
        Guid RenderingID { get; set; }
        Rendering Rendering { get; set; }
        Guid? SourceID { get; set; }
        Item Source { get; set; }
        string Placeholder { get; set; }
        int Index { get; set; }
    }
    public class ItemRendering : IItemRendering
    {
        public ItemRendering() { }
        internal ItemRendering(Database.ItemRendering data)
        {
            if (data != null)
            {
                ID = data.ID;
                RenderingID = data.RenderingID;
                Rendering = new Rendering(data.Rendering);
                SourceID = data.SourceID;
                Source = new Item(data.Source);
                Name = data.Name;
                Placeholder = data.Placeholder;
                Index = data.Index;
                Created = data.Created;
                Updated = data.Updated;
            }
        }
        public Guid ID { get; set; }
        public Guid RenderingID { get; set; }
        public Rendering Rendering { get; set; }
        public Guid? SourceID { get; set; }
        public Item Source { get; set; }
        public string Placeholder { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}