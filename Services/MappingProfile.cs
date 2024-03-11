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

            CreateMap<Domain.Models.ShoppingCart, DataRepository.Models.ShoppingCart>();
            CreateMap<DataRepository.Models.ShoppingCart, Domain.Models.ShoppingCart>();

            CreateMap<Domain.Models.Item, DataRepository.Models.Item>();
            CreateMap<DataRepository.Models.Item, Domain.Models.Item>();

        }
    }
}
