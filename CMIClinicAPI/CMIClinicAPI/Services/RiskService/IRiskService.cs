using CMIClinicAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.RiskService
{
    public interface IRiskService
    {
        Task<ServiceResponse<GetRiskDto>> GetRisk(int id);
        Task<ServiceResponse<List<GetRiskDto>>> AddRisk(AddRiskDto risk);
    }
}
