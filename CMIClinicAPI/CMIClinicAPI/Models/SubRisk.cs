
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Models
{
    public class SubRisk
    {
        public int Id { get; set; }
        public string RiskTitle { get; set; }
        public int RiskId { get; set; }
        public Risk Risk { get; set; }
    }
}
