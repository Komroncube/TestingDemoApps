using CarSystemDomain;

namespace CarSystemApplication.Repositories;

public interface ICarRepository
{
    Task GetAllCars();
    Task GetCarById(int id);
    Task UpdateCar(Car car);
    Task DeleteCar(int id);
    Task CreateCar(Car car);
}
