using CarSystemApplication.Data;
using CarSystemDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystemApplication.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _carDbContext;

        public CarRepository(CarDbContext carDbContext)
        {
            _carDbContext = carDbContext;
        }

        public Task CreateCar(Car car)
        {
            _carDbContext.AddAsync(car);
            return _carDbContext.SaveChangesAsync();
        }

        public Task DeleteCar(int id)
        {
            var car = _carDbContext.Cars.FirstOrDefault(x=>x.Id == id);
            _carDbContext.Cars.Remove(car);
            return _carDbContext.SaveChangesAsync();
        }

        public Task GetAllCars()
        {
            return _carDbContext.Cars.ToListAsync();
        }

        public Task GetCarById(int id)
        {
            return _carDbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateCar(Car car)
        {
            var lastcar = _carDbContext.Cars.FirstOrDefault(x=>x.Id == car.Id);
            if(lastcar is null)
            {
                return Task.CompletedTask;
            }
            lastcar.Name = car.Name;
            lastcar.Year = car.Year;
            lastcar.Price = car.Price;

            return _carDbContext.SaveChangesAsync();
        }
    }
}
