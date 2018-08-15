using CustomMvc.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Rendering
{
    public class RenderSession : IDisposable
    {
        public RenderSession(ItemRendering rendering)
        {
            _PreviousItem = CustomContext.Current;
            _ProcessedPlaceholders = CustomContext.ProcessedPlaceholders.ToList();
            CustomContext.Current = rendering.Source;
            CustomContext.ProcessedPlaceholders.Add(rendering.Placeholder);
            CustomContext.ProcessedPlaceholders = CustomContext.ProcessedPlaceholders;
        }
        private Item _PreviousItem { get; set; }
        private List<string> _ProcessedPlaceholders { get; set; }
        public void Dispose()
        {
            CustomContext.Current = _PreviousItem;
            CustomContext.ProcessedPlaceholders = _ProcessedPlaceholders;
        }
    }
}