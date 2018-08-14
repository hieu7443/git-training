using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Database
{
    public static class Repository
    {
        public static Item Get(string url)
        {
            Item result = null;
            using (CustomDbContext context = new CustomDbContext())
            {
                result = (from i in context.Items
                          join l in context.Links on i.ID equals l.ItemID
                          where l.Url == url
                          select new Item() {
                              ID = i.ID,
                              Name = i.Name,
                              ParentID = i.ParentID,
                              TemplateID = i.TemplateID,
                              Created = i.Created,
                              Updated = i.Updated
                          }).FirstOrDefault();
            }
            return result;
        }
    }
}