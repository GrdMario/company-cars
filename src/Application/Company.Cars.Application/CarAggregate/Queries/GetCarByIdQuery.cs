namespace Company.Cars.Application.CarAggregate.Queries
{
    using AutoMapper;
    using Company.Cars.Application.CarAggregate.Responses;
    using Company.Cars.Application.Contracts.Database;
    using Company.Cars.Domain;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public record GetCarByIdQuery(Guid Id) : IRequest<CarResponse>;

    public class GetCarByIdRequestHandler : IRequestHandler<GetCarByIdQuery, CarResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCarByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CarResponse> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            Car car = await this.unitOfWork.CarRepository.GetByIdAsync(request.Id, cancellationToken);

            return this.mapper.Map<CarResponse>(car);
        }
    }
}
