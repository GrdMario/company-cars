namespace Company.Cars.Presentation.Api.Internal.Mappings
{
    using Company.Cars.Application.CarAggregate.Commands;
    using Company.Cars.Application.CarAggregate.Queries;
    using Company.Cars.Blocks.Common.Mapping.Core;
    using Company.Cars.Presentation.Api.Controllers.V1.Models.Cars;

    internal sealed class PresentationMappingProfile : MappingProfileBase
    {
        public PresentationMappingProfile()
        {
            CreateMap<GetCarsQueryDto, GetCarsQuery>();
            CreateMap<CreateCarDto, CreateCarCommand>();
            CreateMap<UpdateCarDto, UpdateCarCommand>();
        }
    }
}
