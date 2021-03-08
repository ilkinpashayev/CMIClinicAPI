using CMIClinicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Dtos
{
    public class GetRiskDto
    {
        public int Id { get; set; }
        public string RiskTitle { get; set; }
        public int Limit { get; set; }
        public Algorithm AlgorithType { get; set; }
    }
}
