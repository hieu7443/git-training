using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface IPresentation : IBaseItem
    {
        Layout Layout { get; set; }
        ItemRendering[] Renderings { get; set; }
        IEnumerable<ItemRendering> GetRenderings(string placeholder);
    }
    public class Presentation : IPresentation
    {
        public Presentation() { }
        internal Presentation(Database.Presentation data)
        {
            if (data != null)
            {
                ID = data.ID;
                Created = data.Created;
                Updated = data.Updated;
                Layout = new Layout(data.Layout);
                Renderings = data.ItemRenderings?.Select(i => new ItemRendering(i)).ToArray();
            }
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Layout Layout { get; set; }
        public ItemRendering[] Renderings { get; set; }
        public IEnumerable<ItemRendering> GetRenderings(string placeholder)
        {
            List<string> placeholders = CustomContext.ProcessedPlaceholders.ToList();
            placeholders.Add(placeholder);
            return Renderings?.Where(r => r.Placeholder == String.Join("/", placeholders));
        }
    }
}