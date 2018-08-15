using CustomMvc.Foundation.Database;
using CustomMvc.Foundation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public static class Repository
    {
        public static Item GetItem(string url)
        {
            Item result = null;
            if (String.IsNullOrEmpty(url))
                url = "/";
            url = "/" + url.TrimStart('/');
            using (CustomDbContext context = new CustomDbContext())
            {
                result = new Item((from i in context.Items
                          from l in i.Links
                          where l.Url == url
                          select i).FirstOrDefault());
            }
            return result;
        }
    }
}