using CMIClinicAPI.Dtos;
using CMIClinicAPI.Models;
using CMIClinicAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMIClinicAPI.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(UserRegisterDto user, string password);
        Task<ServiceResponse<GetUserDto>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
