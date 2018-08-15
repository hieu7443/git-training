using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation
{
    public static class Constants
    {
        public static string CurrentRenderingItem { get { return "_CurrentRenderingItem"; } }
        public static string Presentation { get { return "_Presentation"; } }
        public static string ProcessedPlaceholders { get { return "_ProcessedPlaceholders"; } }
    }
}