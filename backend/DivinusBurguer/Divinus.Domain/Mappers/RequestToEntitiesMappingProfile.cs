using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Divinus.Domain.Mappers
{
    public class RequestToEntitiesMappingProfile : Profile
    {
        public RequestToEntitiesMappingProfile()
        {
            CreateMap<Divinus.Domain.Arguments.Order.Address, Divinus.Domain.Entities.Address>();
            CreateMap<Divinus.Domain.Arguments.Order.Food, Divinus.Domain.Entities.Food>();
        }
    }
}
