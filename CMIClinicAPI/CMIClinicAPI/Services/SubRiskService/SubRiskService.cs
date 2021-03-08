using AutoMapper;
using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.SubRiskService
{
    public class SubRiskService : ISubRiskService
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public SubRiskService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetSubRiskDto>>> AddRisk(AddSubRiskDto newrisk)
        {
            ServiceResponse<List<GetSubRiskDto>> serviceResponse = new ServiceResponse<List<GetSubRiskDto>>();
            SubRisk risk = _mapper.Map<SubRisk>(newrisk);
            await _context.SubRisks.AddAsync(risk);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.SubRisks.Select(c => _mapper.Map<GetSubRiskDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSubRiskDto>> GetRisk(int id)
        {
            ServiceResponse<GetSubRiskDto> serviceReponse = new ServiceResponse<GetSubRiskDto>();
            SubRisk risk = await _context.SubRisks.FirstOrDefaultAsync(c => c.Id == id);
            serviceReponse.Data = _mapper.Map<GetSubRiskDto>(risk);
            return serviceReponse;
        }


    }
}
