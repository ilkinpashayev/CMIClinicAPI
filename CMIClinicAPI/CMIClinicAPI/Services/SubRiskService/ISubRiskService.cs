using CMIClinicAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.SubRiskService
{
    public interface ISubRiskService
    {
        Task<ServiceResponse<GetSubRiskDto>> GetRisk(int id);
        Task<ServiceResponse<List<GetSubRiskDto>>> AddRisk(AddSubRiskDto risk);
    }
}
