using CMIClinicAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.PolicyService
{
    public interface IPolicyService
    {
        Task<ServiceResponse<GetPolicyDto>> GetPolicy(string PolicyNumber);
        Task<ServiceResponse<List<GetPolicyDto>>> AddPolicy(AddPolicyDto risk);
    }
}
