namespace Company.Cars.Infrastructure.Database.Mssql.Internal
{
    using Company.Cars.Application.Contracts.Database;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MssqlDbContext context;

        public UnitOfWork(ICarRepository carRepository, MssqlDbContext context)
        {
            this.context = context;
            this.CarRepository = carRepository;
        }

        public ICarRepository CarRepository { get; }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}
