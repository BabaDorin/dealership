using DealershipManager.Data;
using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SqlCarRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Car car)
        {
            dbContext.Cars.Add(car);
            dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var carToDelete = dbContext.Cars.FirstOrDefault(c => c.Id == id);

            if (carToDelete is not null)
            {
                var result = dbContext.Cars.Remove(carToDelete);
                dbContext.SaveChanges();
            }
        }

        public Car? Get(Guid id)
        {
            return dbContext.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll()
        {
            return dbContext.Cars.ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate = dbContext.Cars.FirstOrDefault(c => c.Id == car.Id);

            if (carToUpdate is not null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.Category = car.Category;
                carToUpdate.Price = car.Price;
                carToUpdate.Year = car.Year;

                var result = dbContext.Update(carToUpdate);

                dbContext.SaveChanges();
            }
        }
    }
}
