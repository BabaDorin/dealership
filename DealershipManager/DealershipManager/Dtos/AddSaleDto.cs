namespace DealershipManager.Dtos
{
    public class AddSaleDto
    {
        public Guid CarId { get; set; }

        public Guid ClientId { get; set; }

        public double FinalPrice { get; set; }
    }
}
