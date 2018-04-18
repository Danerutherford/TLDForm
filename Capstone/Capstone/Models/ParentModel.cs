using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class ParentModel
    {
        public OrderModel OrderModel { get; set; }
        public IEnumerable<OrderModel> IOrdermodel { get; set; }
    }
}