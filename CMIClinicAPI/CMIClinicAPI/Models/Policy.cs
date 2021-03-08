using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Models
{
    public class Policy
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PolicyNumber { get; set; }
        public int InsuranceAmount { get; set; }
        public int Premium { get; set; }
        public StatusEnum Status { get; set; }
        public int PersonId { get; set; }
        public int RiskId { get; set; }


    }
 }

