using CarSystemDomain;
using System.Collections.Generic;

namespace CarSystemApplication.Repositories;

public interface ICarRepository
{
    ValueTask<IEnumerable<Car>> GetAllCars();
    ValueTask<Car> GetCarById(int id);
    Task UpdateCar(Car car);
    Task DeleteCar(int id);
    ValueTask CreateCar(Car car);
}
