using DotNetFlix.Dto.User;
using DotNetFlix.Models;

namespace DotNetFlix.Services.User
{
    public interface IUserService
    {
        public Task<ResponseModel<List<ShowUserDto>>> GetUsersAsync();
        public Task<ResponseModel<ShowUserDto>> GetUserById(int UserId);
        public Task<ResponseModel<List<ShowUserDto>>> UpdateUser(ShowUserDto userDto);
        public Task<ResponseModel<List<ShowUserDto>>> DeleteUser(int UserId);
        public Task<ResponseModel<List<ShowUserDto>>> CreateUser(ShowUserDto user);



    }
}
