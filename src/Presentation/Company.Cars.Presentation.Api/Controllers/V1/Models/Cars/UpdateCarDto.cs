namespace Company.Cars.Presentation.Api.Controllers.V1.Models.Cars
{
    using System;

    public record UpdateCarDto(
        Guid Id,
        string Name,
        int Consumption,
        int NumberOfCylinders,
        int HorsePower,
        int WeightInKilograms,
        int AccelerationInKilometersPerHour,
        DateTimeOffset Year,
        string Origin) : IApiDto;
}
