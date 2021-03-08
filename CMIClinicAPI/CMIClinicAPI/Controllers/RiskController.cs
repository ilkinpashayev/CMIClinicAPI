using CMIClinicAPI.Dtos;
using CMIClinicAPI.Services.RiskService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RiskController:ControllerBase
    {
        private readonly IRiskService _riskService;

        public RiskController(IRiskService riskService)
        {
            _riskService = riskService;
        }
        [HttpGet("GetRisk")]
        public async Task<IActionResult> GetRisk(int id)
        {
            return Ok(await _riskService.GetRisk(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddRisk(AddRiskDto risk)
        {
            return Ok(await _riskService.AddRisk(risk));
        }
    }
}
