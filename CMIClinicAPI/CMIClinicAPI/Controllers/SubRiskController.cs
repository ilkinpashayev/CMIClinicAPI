using CMIClinicAPI.Dtos;
using CMIClinicAPI.Services.SubRiskService;
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

    public class SubRiskController:ControllerBase
    {
       private readonly ISubRiskService _riskService;

        public SubRiskController(ISubRiskService riskService)
        {
            _riskService = riskService;
        }
        [HttpGet("GetSubRisk")]
        public async Task<IActionResult> GetSubRisk(int id)
        {
            return Ok(await _riskService.GetRisk(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddRisk(AddSubRiskDto risk)
        {
            return Ok(await _riskService.AddRisk(risk));
        }
    }
}
