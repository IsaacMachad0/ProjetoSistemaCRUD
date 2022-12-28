 using AutoMapper;
using Project.Application.DTOs;
using Project.Application.DTOs.Validations;
using Project.Application.Services.Interfaces;
using Project.Application.Services.Validations;
using Project.Domain.Entities;
using Project.Domain.Repositories;

namespace Project.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResultService<ClientDTO>> CreateClientAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null)
                return ResultService.Error<ClientDTO>("Objeto nulo.");

            var result = new ClientDTOValidator().Validate(clientDTO);

            if (!result.IsValid)
                return ResultService.RequestError<ClientDTO>("Erro de validação do cliente", result);

            var client = _mapper.Map<Client>(clientDTO);
            var data = await _repository.CreateClientAsync(client);

            return ResultService.Ok<ClientDTO>(_mapper.Map<ClientDTO>(data));
        }

        public async Task<ResultService> DeleteClientAsync(int id)
        {
            var client = await _repository.GetByIdClientAsync(id);
            if (client == null)
                return ResultService.Error("Id inválido");

            await _repository.DeleteClientAsync(client);

            return ResultService.Ok("Cliente apagado com sucesso.");
        }

        public async Task<ResultService> EditClientAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null)
                return ResultService.Error("objeto nulo.");

            var result = new ClientDTOValidator().Validate(clientDTO);
            if(!result.IsValid)
                return ResultService.RequestError("Erro de validação do cliente.", result);

            var client = await _repository.GetByIdClientAsync(clientDTO.Id);
            if (client == null)
                return ResultService.Error("Cliente não encontrado");

            client = _mapper.Map<ClientDTO, Client>(clientDTO, client);
            await _repository.EditClientAsync(client);

            return ResultService.Ok("Cliente editado com sucesso.");
        }

        public async Task<ResultService<ClientDTO>> GetByIdClientAsync(int id)
        {
            var client = await _repository.GetByIdClientAsync(id);

            if (client == null)
                return ResultService.Error<ClientDTO>("Id inválido.");

            return ResultService.Ok<ClientDTO>(_mapper.Map<ClientDTO>(client));
        }

        public async Task<ResultService<ICollection<ClientDTO>>> GetClientsAsync()
        {
            var clients = await _repository.GetClientsAsync();

            return ResultService.Ok<ICollection<ClientDTO>>(_mapper.Map<ICollection<ClientDTO>>(clients));
        }
    }
}
