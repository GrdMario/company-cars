namespace Company.Cars.Application.CarAggregate.Commands
{
    using Company.Cars.Application.Contracts.Database;
    using Company.Cars.Blocks.Application.Contracts;
    using Company.Cars.Domain;
    using FluentValidation;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public record CreateCarCommand(
        string Name,
        int Consumption,
        int NumberOfCylinders,
        int HorsePower,
        int WeightInKilograms,
        int AccelerationInKilometersPerHour,
        DateTimeOffset Year,
        string Origin) : IRequest;

    internal sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(car => car.Consumption).GreaterThan(0);

            RuleFor(car => car.NumberOfCylinders).GreaterThan(0);

            RuleFor(car => car.HorsePower).GreaterThan(0);

            RuleFor(car => car.WeightInKilograms).GreaterThan(0);

            RuleFor(car => car.AccelerationInKilometersPerHour).GreaterThan(0);

            RuleFor(car => car.Origin).NotEmpty();
        }
    }

    internal sealed class CreateCarCommandHandler : AsyncRequestHandler<CreateCarCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = new(
               SystemGuid.NewGuid,
               request.Name,
               request.Consumption,
               request.NumberOfCylinders,
               request.HorsePower,
               request.WeightInKilograms,
               request.AccelerationInKilometersPerHour,
               request.Year,
               request.Origin);

            this.unitOfWork.CarRepository.Add(car);

            await this.unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
