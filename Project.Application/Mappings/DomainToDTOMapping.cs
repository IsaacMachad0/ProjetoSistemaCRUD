using AutoMapper;
using Project.Application.DTOs;
using Project.Domain.Entities;

namespace Project.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<User, LoginDTO>();
        }
    }
}
