namespace Company.Cars.Presentation.Api.Internal.Examples.V1.Cars
{
    using Company.Cars.Presentation.Api.Controllers.V1.Models.Cars;
    using Swashbuckle.AspNetCore.Filters;
    using System;

    internal class CreateCarDtoExample : IExamplesProvider<CreateCarDto>
    {
        public CreateCarDto GetExamples()
        {
            return new("Ford Mustang", 13, 4, 300, 1400, 5, DateTime.UtcNow, "USA");
        }
    }
}
