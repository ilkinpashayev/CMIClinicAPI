using AutoMapper;
using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.ClaimService
{
    public class ClaimService : IClaimService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public ClaimService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetClaimSearchDto>> SearchPerson(string PIN)
        {
            ServiceResponse<GetClaimSearchDto> serviceReponse = new ServiceResponse<GetClaimSearchDto>();
            var query = 
                from p in _context.Policies
                join ps in _context.Persons
                on p.PersonId equals ps.Id
                where p.Status == StatusEnum.Issued
                select new ClaimPerson
                {
                    Id = ps.Id, 
                    Name = ps.Name, 
                    Surname=ps.Surname,
                    LastName= ps.LastName,
                    IdSeries = ps.IdSeries,
                    IdNumber = ps.IdNumber,
                    PIN = ps.PIN
                };

            //var list = await query.ToListAsync().ConfigureAwait(false); // <-- notice the `await` here. And always use `ConfigureAwait`.
            try
            {
                var person = await query.ToListAsync().ConfigureAwait(false);

                serviceReponse.Data = _mapper.Map<GetClaimSearchDto>(person[0]);
            }
            catch(Exception ex)
            {
                serviceReponse.Data = null;
                serviceReponse.Success = false;
                serviceReponse.Message = "Active Person not found";
            }
            return serviceReponse;
        }
    }
}
