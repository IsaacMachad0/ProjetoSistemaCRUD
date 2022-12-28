using AutoMapper;
using Project.Application.DTOs;
using Project.Domain.Entities;

namespace Project.Application.Mappings
{
    public class DTOToDomainMapping : Profile
    {
        public DTOToDomainMapping()
        {
            CreateMap<ClientDTO, Client>();
            CreateMap<UserDTO, User>();
            CreateMap<LoginDTO, User>();
        }
    }
}
