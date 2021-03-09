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

        public async Task<ServiceResponse<List<GetMedicalClaimDto>>> AddMedicalClaim(AddMedicalClaimDto medicalClaim)
        {
            ServiceResponse<List<GetMedicalClaimDto>> serviceResponse = new ServiceResponse<List<GetMedicalClaimDto>>();
            ServiceResponse<GetRiskDto> riskServiceResponse = new ServiceResponse<GetRiskDto>();


            var limit = GetRisk(medicalClaim.PolicyNumber);
            
            if (medicalClaim.LimitUsed <= limit.Limit)
            {
                MedicalClaim medical = _mapper.Map<MedicalClaim>(medicalClaim);
                await _context.MedicalClaims.AddAsync(medical);
                await _context.SaveChangesAsync();

                try
                {
                    Risk Risk = await _context.Risks.FirstOrDefaultAsync(c => c.Id == limit.RiskId);
                    Risk.AlgorithType = Risk.AlgorithType;
                    Risk.Limit = limit.Limit - medicalClaim.LimitUsed;
                    Risk.RiskTitle = Risk.RiskTitle;
                    Risk.SubRisks = Risk.SubRisks;
                    _context.Risks.Update(Risk);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
                return serviceResponse;

                serviceResponse.Data = (_context.MedicalClaims.Select(c => _mapper.Map<GetMedicalClaimDto>(c))).ToList();
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.Success = false;
                serviceResponse.Message = "No sufficiant limit ";
            }
            return serviceResponse;
        }

        private RiskDataDto GetRisk(string PolicyNumber)
        {
            RiskDataDto limit = null;

            var query =
                from p in _context.Policies
                join r in _context.Risks
                on p.RiskId equals r.Id
                join sr in _context.SubRisks
                on r.Id equals sr.RiskId
                where p.Status == StatusEnum.Issued
                && p.PolicyNumber == PolicyNumber 
                select new RiskDataDto
                {
                    Limit= r.Limit,
                    RiskId = r.Id
                };

            try
            {
                var risklimit = query.ToList();
                limit = risklimit[0];
            }
            catch (Exception ex)
            {

            }

            return limit;
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
