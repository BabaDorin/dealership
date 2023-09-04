using DealershipManager.Models;

namespace DealershipManager.Repositories
{
    public class InMemoryCarRepository : ICarRepository
    {
        private static readonly List<Car> _cars = new List<Car>();

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Guid id)
        {
            var carToDelete = _cars.FirstOrDefault(c => c.Id == id);

            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public Car? Get(Guid id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll(bool isSold)
        {
            return _cars.Where(c => c.IsSold == isSold).ToList();
        }

        public List<Car> GetByFilter(string model, string brand, int productionYear)
        {
            var filter = _cars.AsQueryable();

            if (model is not null)
            {
                filter = filter.Where(c => c.Model == model);
            }

            if (brand is not null)
            {
                filter = filter.Where(c => c.Brand == brand);
            }

            if (productionYear != 0)
            {
                filter = filter.Where(c => c.ProductionYear == productionYear);
            }

            var cars = filter.ToList();

            return cars;
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);

            if (carToUpdate != null)
            {
                carToUpdate.Brand = car.Brand;
                carToUpdate.Model = car.Model;
                carToUpdate.Category = car.Category;
                carToUpdate.Price = car.Price;
                carToUpdate.ProductionYear = car.ProductionYear;
            }
        }
    }
}
