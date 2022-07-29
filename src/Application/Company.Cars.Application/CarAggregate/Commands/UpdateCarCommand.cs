namespace Company.Cars.Application.CarAggregate.Commands
{
    using Company.Cars.Application.Contracts.Database;
    using Company.Cars.Domain;
    using FluentValidation;
    using MediatR;
    using System;
    using System.Threading.Tasks;

    public record UpdateCarCommand(
        string Name,
        int Consumption,
        int NumberOfCylinders,
        int HorsePower,
        int WeightInKilograms,
        int AccelerationInKilometersPerHour,
        DateTimeOffset Year,
        string Origin) : IRequest
    {
        public Guid Id { get; set; }
    }

    internal sealed class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
        {
            RuleFor(car => car.Id).NotEmpty();

            RuleFor(car => car.Name).NotEmpty();

            RuleFor(car => car.Consumption).GreaterThan(0);

            RuleFor(car => car.NumberOfCylinders).GreaterThan(0);

            RuleFor(car => car.HorsePower).GreaterThan(0);

            RuleFor(car => car.WeightInKilograms).GreaterThan(0);

            RuleFor(car => car.AccelerationInKilometersPerHour).GreaterThan(0);

            RuleFor(car => car.Origin).NotEmpty();
        }
    }

    internal sealed class UpdateCarCommandHandler : AsyncRequestHandler<UpdateCarCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = await this.unitOfWork.CarRepository.GetByIdAsync(request.Id, cancellationToken);

            car.Update(
                request.Name,
               request.Consumption,
               request.NumberOfCylinders,
               request.HorsePower,
               request.WeightInKilograms,
               request.AccelerationInKilometersPerHour,
               request.Year,
               request.Origin);

            this.unitOfWork.CarRepository.Update(car);

            await this.unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
