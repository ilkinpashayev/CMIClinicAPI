using AutoMapper;
using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private static List<Person> persons = new List<Person>
        {
            new Person()
        };
        private readonly IMapper _mapper;

        private readonly DataContext _context;
        public PersonService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDto newperson)
        {
            ServiceResponse<List<GetPersonDto>> serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            Person person = _mapper.Map<Person>(newperson);
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            //serviceReponse.Data = persons;
            serviceResponse.Data = (_context.Persons.Select(c => _mapper.Map<GetPersonDto>(c))).ToList(); 
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> GetPerson(string PIN)
        {
            ServiceResponse<GetPersonDto> serviceReponse = new ServiceResponse<GetPersonDto>();
            Person person = await _context.Persons.FirstOrDefaultAsync(c => c.PIN == PIN);
            serviceReponse.Data = _mapper.Map<GetPersonDto>(person);
            return serviceReponse;
        }
    }
}
