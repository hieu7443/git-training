using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Rendering
{
    public class RenderSession : IDisposable
    {
        public RenderSession(Item item)
        {
            _PreviousItem = CustomContext.Current;
            CustomContext.Current = item;
        }
        private Item _PreviousItem { get; set; }
        public void Dispose()
        {
            CustomContext.Current = _PreviousItem;
        }
    }
}