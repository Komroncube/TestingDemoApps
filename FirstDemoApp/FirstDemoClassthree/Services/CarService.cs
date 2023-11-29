using CarSystemApplication.Repositories;
using CarSystemDomain;

namespace CarSystemInfrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async ValueTask CreateCarAsync(Car car)
        {
            await _carRepository.CreateCar(car);
        }

        public async ValueTask<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllCars();
        }
    }
}
