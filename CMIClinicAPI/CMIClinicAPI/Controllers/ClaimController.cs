
using CMIClinicAPI.Dtos;
using CMIClinicAPI.Services.ClaimService;
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
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            _claimService = claimService;
        }
        [HttpGet("GetPerson")]
        public async Task<IActionResult> GetRisk(string PIN)
        {
            return Ok(await _claimService.SearchPerson(PIN));
        }
        [HttpPost]
        public async Task<IActionResult> CreateClaim(AddMedicalClaimDto medicalClaimDto)
        {
            return Ok(await _claimService.AddMedicalClaim(medicalClaimDto));
        }
    }
}
