namespace Company.Cars.Application.Contracts.Database
{
    using Company.Cars.Domain;
    using System;
    using System.Threading.Tasks;

    public interface ICarRepository
    {
        void Add(Car car);
        
        void Delete(Car car);
        
        Task<Car> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Car>> GetAsync(string? name, int skip, int take, CancellationToken cancellationToken);
        
        void Update(Car car);
    }
}