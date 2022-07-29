namespace Company.Cars.Infrastructure.Database.Mssql.Internal.Repositories
{
    using Company.Cars.Application.Contracts.Database;
    using Company.Cars.Blocks.Common.Exceptions;
    using Company.Cars.Blocks.Common.Extensions;
    using Company.Cars.Domain;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class CarRepository : ICarRepository
    {
        private readonly DbSet<Car> cars;

        public CarRepository(MssqlDbContext context)
        {
            this.cars = context.Set<Car>();
        }

        public void Add(Car car)
        {
            this.cars.Add(car);
        }

        public void Delete(Car car)
        {
            this.cars.Remove(car);
        }

        public async Task<List<Car>> GetAsync(string? name, int skip, int take, CancellationToken cancellationToken)
        {
            return await this.cars
                .WhereIf(name is not null, p => p.Name.StartsWith(name!))
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
        }

        public async Task<Car> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await this.cars.FindAsync(new object[] { id }, cancellationToken) ?? throw new NotFoundException("Unable to find car.");
        }

        public void Update(Car car)
        {
            this.cars.Update(car);
        }
    }
}
