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

        public async ValueTask CreateCar(Car car)
        {
            await _carDbContext.AddAsync(car);
            await _carDbContext.SaveChangesAsync();
        }

        public Task DeleteCar(int id)
        {
            var car = _carDbContext.MegaCars.FirstOrDefault(x=>x.Id == id);
            _carDbContext.MegaCars.Remove(car);
            return _carDbContext.SaveChangesAsync();
        }

        public async ValueTask<IEnumerable<Car>> GetAllCars()
        {
            return await _carDbContext.MegaCars.ToListAsync();
        }

        public async ValueTask<Car> GetCarById(int id)
        {
            return await _carDbContext.MegaCars.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateCar(Car car)
        {
            var lastcar = _carDbContext.MegaCars.FirstOrDefault(x=>x.Id == car.Id);
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
