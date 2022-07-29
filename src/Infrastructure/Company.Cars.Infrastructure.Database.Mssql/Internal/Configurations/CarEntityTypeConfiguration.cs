namespace Company.Cars.Infrastructure.Database.Mssql.Internal.Configurations
{
    using Company.Cars.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal sealed class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(key => key.Id);

            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.Consumption).IsRequired();

            builder.Property(p => p.NumberOfCylinders).IsRequired();

            builder.Property(p => p.HorsePower).IsRequired();

            builder.Property(p => p.Weight).IsRequired();

            builder.Property(p => p.Acceleration).IsRequired();

            builder.Property(p => p.Year).IsRequired();

            builder.Property(p => p.Origin).IsRequired();
        }
    }
}
