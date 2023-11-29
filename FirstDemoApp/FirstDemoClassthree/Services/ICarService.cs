using CarSystemDomain;

namespace CarSystemInfrastructure.Services
{
    public interface ICarService
    {
        ValueTask<IEnumerable<Car>> GetAllCarsAsync();
        ValueTask CreateCarAsync(Car car);
    }
}
