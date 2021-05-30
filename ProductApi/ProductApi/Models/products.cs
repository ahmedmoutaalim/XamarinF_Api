using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class products
    {
        public int id  { get; set; }
        public  string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string ImageUrl { get; set; }

    }
}
