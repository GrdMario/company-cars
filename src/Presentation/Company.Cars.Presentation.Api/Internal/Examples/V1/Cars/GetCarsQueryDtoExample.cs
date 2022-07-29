namespace Company.Cars.Presentation.Api.Internal.Examples.V1.Cars
{
    using Company.Cars.Presentation.Api.Controllers.V1.Models.Cars;
    using Swashbuckle.AspNetCore.Filters;

    internal sealed class GetCarsQueryDtoExample : IExamplesProvider<GetCarsQueryDto>
    {
        public GetCarsQueryDto GetExamples()
        {
            return new("Ford Mustang", 0, 1);
        }
    }
}
