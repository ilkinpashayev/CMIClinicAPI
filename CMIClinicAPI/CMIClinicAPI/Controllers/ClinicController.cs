using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using CMIClinicAPI.Services.PersonService;
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
    public class ClinicController : ControllerBase
    {
        private static List<Person> persons = new List<Person>
        {
            new Person()
        };
        private readonly IPersonService _personService;

        public ClinicController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet("GetPerson")]
        public async Task<IActionResult> GetPerson(string PIN)
        {
            return Ok(await _personService.GetPerson(PIN));
        }
        [HttpPost]
        public async Task<IActionResult> AddPerson(AddPersonDto person)
        {
            return Ok(await _personService.AddPerson(person));
        }

    }
}
