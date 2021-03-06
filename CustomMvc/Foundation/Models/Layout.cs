﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface ILayout : IBaseItem
    {
        string Source { get; set; }
    }
    public class Layout : ILayout
    {
        public Layout() { }
        internal Layout(Database.Layout data)
        {
            if (data != null)
            {
                ID = data.ID;
                Name = data.Name;
                Source = data.Source;
                Created = data.Created;
                Updated = data.Updated;
            }
        }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}