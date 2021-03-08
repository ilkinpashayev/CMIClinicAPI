using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Models
{
    public class Risk
    {
        public int Id { get; set; }
        public string RiskTitle { get; set; }
        public int Limit { get; set; }
        public Algorithm AlgorithType { get; set; }
        public List<SubRisk> SubRisks { get; set; }
        public List<Policy> Policies { get; set; }


    }
}
