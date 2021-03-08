using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.PersonService
{
    public interface IPersonService
    {
        Task<ServiceResponse<GetPersonDto>> GetPerson(string PIN);
        Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDto person);

    }
}
