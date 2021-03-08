
using CMIClinicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Dtos
{
    public class GetSubRiskDto
    {
        public string RiskTitle { get; set; }
        public int RiskId { get; set; }
    }
}
