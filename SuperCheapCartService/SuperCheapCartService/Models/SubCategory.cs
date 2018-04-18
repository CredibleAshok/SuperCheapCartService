using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperCheapCartService.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public int Name { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}