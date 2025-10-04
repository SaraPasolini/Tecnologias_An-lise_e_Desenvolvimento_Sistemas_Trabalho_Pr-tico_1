using AutoMapper;
using VendaVeiculosApi.Models;
using VendaVeiculosApi.DTOs;
using VeiculosAPI.DTOs;

namespace VendaVeiculosApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTOs>().ReverseMap();
            CreateMap<Veiculo, VeiculoDTOs>().ReverseMap();
            CreateMap<Aluguel, AluguelDTOs>().ReverseMap();
            CreateMap<Fabricante, FabricanteDTOs>().ReverseMap();
        }
    }
}
