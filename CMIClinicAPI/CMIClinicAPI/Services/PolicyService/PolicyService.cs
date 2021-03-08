using AutoMapper;
using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.PolicyService
{
    public class PolicyService:IPolicyService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public PolicyService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetPolicyDto>>> AddPolicy(AddPolicyDto newpolicy)
        {
            ServiceResponse<List<GetPolicyDto>> serviceResponse = new ServiceResponse<List<GetPolicyDto>>();
            Policy policy = _mapper.Map<Policy>(newpolicy);
            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Policies.Select(c => _mapper.Map<GetPolicyDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPolicyDto>> GetPolicy(string PolicyNumber)
        {
            ServiceResponse<GetPolicyDto> serviceReponse = new ServiceResponse<GetPolicyDto>();
            Policy policy = await _context.Policies.FirstOrDefaultAsync(c => c.PolicyNumber == PolicyNumber);
            serviceReponse.Data = _mapper.Map<GetPolicyDto>(policy);
            return serviceReponse;
        }
    }
}
