using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MyFirstApi.Models
{
    public class Pizza
    {
        //this is all a model needs - they are just representing data; they do not need any behavior defined
        public int Id { get; set; }
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
    }
}
