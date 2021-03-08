using AutoMapper;
using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.RiskService
{
    public class RiskService : IRiskService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public RiskService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetRiskDto>>> AddRisk(AddRiskDto newrisk)
        {
            ServiceResponse<List<GetRiskDto>> serviceResponse = new ServiceResponse<List<GetRiskDto>>();
            Risk risk = _mapper.Map<Risk>(newrisk);
            await _context.Risks.AddAsync(risk);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Risks.Select(c => _mapper.Map<GetRiskDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRiskDto>> GetRisk(int id)
        {
            ServiceResponse<GetRiskDto> serviceReponse = new ServiceResponse<GetRiskDto>();
            Risk risk = await _context.Risks.FirstOrDefaultAsync(c => c.Id == id);
            serviceReponse.Data = _mapper.Map<GetRiskDto>(risk);
            return serviceReponse;
        }
    }
}
