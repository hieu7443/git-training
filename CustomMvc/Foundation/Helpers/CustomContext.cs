using CustomMvc.Foundation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation
{
    public static class CustomContext
    {
        public static Item Current
        {
            get
            {
                return (Item)HttpContext.Current.Items[Constants.CurrentRenderingItem];
            }
            set
            {
                HttpContext.Current.Items[Constants.CurrentRenderingItem] = value;
            }
        }
        public static IPresentation Presentation
        {
            get
            {
                return (IPresentation)HttpContext.Current.Items[Constants.Presentation];
            }
            set
            {
                HttpContext.Current.Items[Constants.Presentation] = value;
            }
        }
        public static List<string> ProcessedPlaceholders
        {
            get
            {
                return (List<string>)HttpContext.Current.Items[Constants.ProcessedPlaceholders];
            }
            set
            {
                HttpContext.Current.Items[Constants.ProcessedPlaceholders] = value;
            }
        }
    }
}