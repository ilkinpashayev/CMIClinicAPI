using CMIClinicAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.ClaimService
{
    public interface IClaimService
    {
        Task<ServiceResponse<GetClaimSearchDto>> SearchPerson(string PIN);

    }
}
