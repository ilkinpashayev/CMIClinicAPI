using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Models
{
    public class Person
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Ilkin";
        public string Surname { get; set; } = "Pashayev";
        public string LastName { get; set; } = "Farhad";
        public string IdSeries { get; set; } = "AA";
        public string IdNumber { get; set; } = "140232";
        public string PIN { get; set; } = "13RDPT2";
    }
}
