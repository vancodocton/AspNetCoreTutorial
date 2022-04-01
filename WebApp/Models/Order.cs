namespace WebApp.Models
{
    public class Order
    {
        public int Id { get; set; }

        public double TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
