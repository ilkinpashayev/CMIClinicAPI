using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Surname { get; set; } 
        public string LastName { get; set; } 
        public string IdSeries { get; set; } 
        public string IdNumber { get; set; } 
        public string PIN { get; set; } 
        public List<Policy> Policies { get; set; }

    }
}
