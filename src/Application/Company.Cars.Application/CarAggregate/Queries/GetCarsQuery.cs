namespace Company.Cars.Application.CarAggregate.Queries
{
    using AutoMapper;
    using Company.Cars.Application.CarAggregate.Responses;
    using Company.Cars.Application.Contracts.Database;
    using Company.Cars.Domain;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public record GetCarsQuery(string? Name, int Skip = 0, int Take = 20) : IRequest<List<CarResponse>>;

    internal sealed class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<CarResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetCarsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<CarResponse>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await this.unitOfWork.CarRepository.GetAsync(request.Name, request.Skip, request.Take, cancellationToken);

            return this.mapper.Map<List<CarResponse>>(cars);
        }
    }
}
