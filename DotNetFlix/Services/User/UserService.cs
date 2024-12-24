using DotNetFlix.Data;
using DotNetFlix.Dto.User;
using DotNetFlix.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DotNetFlix.Services.User
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) 
        {
            _context = context;
        }

        public Task<ResponseModel<List<ShowUserDto>>> CreateUser(ShowUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ShowUserDto>>> DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ShowUserDto>> GetUserById(int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ShowUserDto>>> GetUsersAsync()
        {
            ResponseModel<List<ShowUserDto>> response = new ResponseModel<List<ShowUserDto>>();

            var user = await _context.Users.ToListAsync();
            if (user == null) 
            {
                response.Mensagem = "Ocorreu um erro!";
                response.Status = false;
                return response;
            }


         var UserDto = user.Select(user => new ShowUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();

            response.Dados = UserDto ;
            response.Mensagem = "Sucesso!";
            response.Status = true;
            return response;
        }

        public Task<ResponseModel<List<ShowUserDto>>> UpdateUser(ShowUserDto userDto)
        {
            throw new NotImplementedException();

        }
    }
}
