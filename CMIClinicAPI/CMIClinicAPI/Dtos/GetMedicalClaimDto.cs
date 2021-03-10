using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Dtos
{
    public class GetMedicalClaimDto
    {
        public int Id { get; set; }
        public DateTime ClaimDate { get; set; }
        public string PolicyNumber { get; set; }
        public string SubRiskId { get; set; }

        public int LimitUsed { get; set; }
    }
}
