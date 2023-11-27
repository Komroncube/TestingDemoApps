using CarSystemDomain;
using Microsoft.EntityFrameworkCore;

namespace CarSystemApplication.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

        public virtual DbSet<Car> Cars { get; set; }
    }
}
