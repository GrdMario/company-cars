namespace Company.Cars.Application.Internal.Mappings
{
    using Company.Cars.Application.CarAggregate.Responses;
    using Company.Cars.Blocks.Common.Mapping.Core;
    using Company.Cars.Domain;

    internal sealed class ApplicationMappingProfile : MappingProfileBase
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Car, CarResponse>();
        }
    }
}
