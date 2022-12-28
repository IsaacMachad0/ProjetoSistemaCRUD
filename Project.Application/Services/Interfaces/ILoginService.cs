using Project.Application.DTOs;
using Project.Application.Services.Validations;

namespace Project.Application.Services.Interfaces
{
    public interface ILoginService
    {
        bool LoginUser(LoginDTO loginDTO);
    }
}
