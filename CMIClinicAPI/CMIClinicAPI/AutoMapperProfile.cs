using AutoMapper;
using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, GetPersonDto>();
            CreateMap<AddPersonDto, Person>();
            CreateMap<User, GetUserDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<Risk, GetRiskDto>();
            CreateMap<AddRiskDto, Risk>();

            CreateMap<SubRisk, GetSubRiskDto>();
            CreateMap<AddSubRiskDto, SubRisk>();

            CreateMap<Policy, GetPolicyDto>();
            CreateMap<AddPolicyDto, Policy>();

            CreateMap<ClaimPerson, GetClaimSearchDto>();
        }
    }
}
