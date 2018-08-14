using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMvc.Foundation.Models
{
    public interface IBaseItem
    {
        Guid ID { get; set; }
        string Name { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}