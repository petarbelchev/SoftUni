using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models
            => (IReadOnlyCollection<ICar>)cars;

        public void Add(ICar car)
        {
            if (car == null)
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);

            cars.Add(car);
        }

        public ICar FindBy(string vin)
            => cars.FirstOrDefault(c => c.VIN == vin);

        public bool Remove(ICar car)
            => cars.Remove(car);
    }
}
