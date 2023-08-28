using DealershipManager.Models;

namespace DealershipManager.Dtos
{
    public class UpdateCarDto
    {
        public string Model { get; set; }

        public string Brand { get; set; }

        public int ProductionYear { get; set; }

        public Category Category { get; set; }

        public double Price { get; set; }
    }
}
