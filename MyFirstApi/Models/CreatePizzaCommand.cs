using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MyFirstApi.Models
{
    public class CreatePizzaCommand
    {
        public string Size { get; set; }
    }
}
