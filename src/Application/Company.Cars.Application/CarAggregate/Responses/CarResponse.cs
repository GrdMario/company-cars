namespace Company.Cars.Application.CarAggregate.Responses
{
    using System;

    public record CarResponse(
        Guid Id,
        string Name,
        int Consumption,
        int NumberOfCylinders,
        int HorsePower,
        int Weight,
        int Acceleration,
        DateTimeOffset Year,
        string Origin);
}
