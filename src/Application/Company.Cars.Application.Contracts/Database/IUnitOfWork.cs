namespace Company.Cars.Application.Contracts.Database
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }

        public Task CommitAsync(CancellationToken cancellationToken);
    }
}
