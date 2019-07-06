using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Order
{
    public class Food
    {
        public string Name { get;  set; }

        public string Description { get;  set; }

        public decimal Price { get;  set; }

        public string ImageName { get;  set; }

        public string Category { get;  set; }

        public int Quantity { get;  set; }
    }
}
