using AutoMapper;
using DataRepository.Models;
using Services.Domain.Models;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Models.Product, DataRepository.Models.Product>();                        
            CreateMap<DataRepository.Models.Product, Domain.Models.Product>();
            
        }
    }
}
