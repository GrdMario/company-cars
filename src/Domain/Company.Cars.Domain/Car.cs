namespace Company.Cars.Domain
{
    using System;

    public class Car
    {
        public Car(
           Guid id,
           string name,
           int consumption,
           int numberOfCylinders,
           int horsePower,
           int weight,
           int acceleration,
           DateTimeOffset year,
           string origin)
        {
            Id = id;
            Name = name;
            Consumption = consumption;
            NumberOfCylinders = numberOfCylinders;
            HorsePower = horsePower;
            Weight = weight;
            Acceleration = acceleration;
            Year = year;
            Origin = origin;
        }

        public Guid Id { get; }

        public string Name { get; private set; }

        public int Consumption { get; private set; }

        public int NumberOfCylinders { get; private set; }

        public int HorsePower { get; private set; }

        public int Weight { get; private set; }

        public int Acceleration { get; private set; }

        public DateTimeOffset Year { get; private set; }

        public string Origin { get; private set; }

        public void Update(
            string name,
           int consumption,
           int numberOfCylinders,
           int horsePower,
           int weight,
           int acceleration,
           DateTimeOffset year,
           string origin)
        {
            this.Name = name;
            this.Consumption = consumption;
            this.NumberOfCylinders = numberOfCylinders;
            this.HorsePower = horsePower;
            this.Weight = weight;
            this.Acceleration = acceleration;
            this.Year = year;
            this.Origin = origin;
        }
    }
}
