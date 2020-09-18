using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string Breed { get; set; }
        public int Notes { get; set; }

        public string ImageUrl { get; set; }
    }
}
