namespace CarDealershipAPI.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Price { get; set; }

        // Propiedades de navegación (no se deben enviar en las solicitudes CRUD)
        public Car? Car { get; set; }
        public Customer? Customer { get; set; }
    }

}
