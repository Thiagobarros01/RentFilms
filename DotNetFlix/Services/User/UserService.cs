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

        public async Task<ResponseModel<ShowUserDto>> GetUserById(int userId)
        {
            ResponseModel<ShowUserDto> response = new ResponseModel<ShowUserDto>();

            // Verificar se o ID é válido antes da consulta
            if (userId <= 0)
            {
                response.Mensagem = "ID inválido.";
                response.Status = false;
                return response;
            }

            try
            {
                // Buscar usuário e mapear diretamente para o DTO
                var user = await _context.Users
                    .Where(u => u.Id == userId)
                    .Select(u => new ShowUserDto
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Name = u.Name,
                        Number = u.Number
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    response.Mensagem = "Nenhum usuário encontrado para o ID fornecido.";
                    response.Status = false;
                    return response;
                }

                response.Dados = user;
                response.Mensagem = "Usuário encontrado com sucesso!";
                response.Status = true;
            }
            catch (Exception ex)
            {

                response.Mensagem = "Ocorreu um erro ao buscar o usuário.";
                response.Status = false;

            }

            return response;
        }

        public async Task<ResponseModel<List<ShowUserDto>>> GetUsersAsync()
        {
            ResponseModel<List<ShowUserDto>> response = new ResponseModel<List<ShowUserDto>>();

            try
            {
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

                response.Dados = UserDto;
                response.Mensagem = "Sucesso!";
                response.Status = true;
                return response;

            }
            catch (Exception e)
            {
                response.Mensagem = e.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<List<ShowUserDto>>> UpdateUser(ShowUserDto userDto)
        {
            throw new NotImplementedException();

        }
    }
}
