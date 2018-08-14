using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface IRendering : IBaseItem
    {
        Guid RenderingID { get; set; }
        Guid SourceID { get; set; }
        string Placeholder { get; set; }
        int Index { get; set; }
    }
    public class Rendering : IRendering
    {
        public Guid ID { get; set; }
        public Guid RenderingID { get; set; }
        public Guid SourceID { get; set; }
        public string Placeholder { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}