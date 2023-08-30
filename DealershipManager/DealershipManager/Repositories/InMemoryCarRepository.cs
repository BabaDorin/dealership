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

        public List<Car> GetAll()
        {
            return _cars;
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
                carToUpdate.Year = car.Year;
            }
        }
    }
}
