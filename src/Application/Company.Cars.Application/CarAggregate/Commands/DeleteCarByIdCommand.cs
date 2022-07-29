namespace Company.Cars.Application.CarAggregate.Commands
{
    using Company.Cars.Application.Contracts.Database;
    using Company.Cars.Domain;
    using FluentValidation;
    using MediatR;
    using System;
    using System.Threading.Tasks;

    public record DeleteCarByIdCommand(Guid Id) : IRequest;

    internal sealed class DeleteCarByIdCommandValidator : AbstractValidator<DeleteCarByIdCommand>
    {
        public DeleteCarByIdCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }

    internal sealed class DeleteCarByIdCommandHandler : AsyncRequestHandler<DeleteCarByIdCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCarByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteCarByIdCommand request, CancellationToken cancellationToken)
        {
            Car car = await this.unitOfWork.CarRepository.GetByIdAsync(request.Id, cancellationToken);

            this.unitOfWork.CarRepository.Delete(car);

            await this.unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
