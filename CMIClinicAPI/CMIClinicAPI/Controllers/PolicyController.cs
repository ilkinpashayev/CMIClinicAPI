using CMIClinicAPI.Dtos;
using CMIClinicAPI.Services.PolicyService;
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
    public class PolicyController: ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        [HttpGet("GetPolicy")]
        public async Task<IActionResult> GetPolicy(string PolicyNumber)
        {
            return Ok(await _policyService.GetPolicy(PolicyNumber));
        }
        [HttpPost]
        //[Route("policy")]
        public async Task<IActionResult> Post(AddPolicyDto policy) 
        {
            return Ok(await _policyService.AddPolicy(policy));
        }
    }
}
