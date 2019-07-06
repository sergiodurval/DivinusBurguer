using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Divinus.Domain.Mappers
{
    public class EntitiesToRequestMappingProfile : Profile
    {
        public EntitiesToRequestMappingProfile()
        {
            CreateMap<Divinus.Domain.Entities.Address, Divinus.Domain.Arguments.Order.Address>();
            CreateMap<Divinus.Domain.Entities.Food, Divinus.Domain.Arguments.Order.Food>();
        }
    }
}
