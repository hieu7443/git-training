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
        public static IRendering[] RenderingList
        {
            get
            {
                return (IRendering[])HttpContext.Current.Items[Constants.RenderingList];
            }
            set
            {
                HttpContext.Current.Items[Constants.CurrentRenderingItem] = value;
            }
        }
        public static ILayout Layout
        {
            get
            {
                return (ILayout)HttpContext.Current.Items[Constants.Layout];
            }
            set
            {
                HttpContext.Current.Items[Constants.Layout] = value;
            }
        }
    }
}