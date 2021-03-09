using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Models
{
    public class MedicalClaim
    {
        public int Id { get; set; }
        public DateTime ClaimDate { get; set; }
        public string PolicyNumber { get; set; }
        public int LimitUsed { get; set; }

    }
}
