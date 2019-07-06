using AutoMapper;
namespace Divinus.Domain.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Reset();
            Mapper.Initialize(x =>
            {
                x.AddProfile(new RequestToEntitiesMappingProfile());
                x.AddProfile(new EntitiesToRequestMappingProfile());
            });
        }
    }
}
