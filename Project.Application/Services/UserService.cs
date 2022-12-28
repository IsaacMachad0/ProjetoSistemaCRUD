using AutoMapper;
using Project.Application.DTOs;
using Project.Application.DTOs.Validations;
using Project.Application.Services.Interfaces;
using Project.Application.Services.Validations;
using Project.Domain.Entities;
using Project.Domain.Repositories;

namespace Project.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResultService<UserDTO>> CreateUserAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Error<UserDTO>("Objeto nulo.");

            var result = new UserDTOValidator().Validate(userDTO);
            if(!result.IsValid)
                return ResultService.RequestError<UserDTO>("Erro de validação de usuário.", result);

            var user = _mapper.Map<User>(userDTO);
            var data = await _repository.CreateUserAsync(user);

            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(data));
        }

        public async Task<ResultService> DeleteUserAsync(int id)
        {
            var user = await _repository.GetByIdUserAsync(id);
            if (user == null)
                return ResultService.Error("Id inválido");

            await _repository.DeleteUserAsync(user);

            return ResultService.Ok("Usuário deletado com sucesso.");
        }

        public async Task<ResultService> EditUserAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Error("Objeto nulo.");

            var result = new UserDTOValidator().Validate(userDTO);
            if (!result.IsValid)
                return ResultService.RequestError("Erro de validação de usuário.", result);

            var user = await _repository.GetByIdUserAsync(userDTO.Id);
            if (user == null)
                return ResultService.Error("Usuário não encontrado.");

            user = _mapper.Map<UserDTO, User>(userDTO, user);
            await _repository.EditUserAsync(user);

            return ResultService.Ok("Usuário editado com sucesso.");
        }

        public async Task<ResultService<UserDTO>> GetByIdUserAsync(int id)
        {
            var user = await _repository.GetByIdUserAsync(id);

            if (user == null)
                return ResultService.Error<UserDTO>("Id inválido.");

            return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(user));
        }

        public async Task<ResultService<ICollection<UserDTO>>> GetUsersAsync()
        {
            var users = await _repository.GetUsersAsync();

            return ResultService.Ok<ICollection<UserDTO>>(_mapper.Map<ICollection<UserDTO>>(users));
        }
    }
}
