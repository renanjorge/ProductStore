namespace Store.Application.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public string Perishable { get; set; }
        public int CategoryProductId { get; set; }
        public string CategoryProductName { get; set; }
    }
}
