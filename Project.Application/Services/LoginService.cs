using AutoMapper;
using Project.Application.DTOs;
using Project.Application.DTOs.Validations;
using Project.Application.Services.Interfaces;
using Project.Application.Services.Validations;
using Project.Domain.Entities;
using Project.Domain.Repositories;

namespace Project.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        private readonly IMapper _mapper;

        public LoginService(ILoginRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool LoginUser(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return false;
            }

            var result = new LoginDTOValidator().Validate(loginDTO);

            if (!result.IsValid)
            {
                return false;
            }

            var data = _repository.LoginUser(loginDTO.Email, loginDTO.Password);

            return data;
        }
    }
}
