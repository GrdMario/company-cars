namespace Company.Cars.Presentation.Api.Internal.Examples.V1.Cars
{
    using Company.Cars.Presentation.Api.Controllers.V1.Models.Cars;
    using Swashbuckle.AspNetCore.Filters;
    using System;

    internal sealed class UpdateCarDtoExample : IExamplesProvider<UpdateCarDto>
    {
        public UpdateCarDto GetExamples()
        {
            return new(Guid.NewGuid(), "Ford Mustang", 13, 4, 300, 1400, 5, DateTime.UtcNow, "USA");
        }
    }
}
