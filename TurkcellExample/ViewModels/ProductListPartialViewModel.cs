namespace TurkcellExample.ViewModels
{
    public class ProductListPartialViewModel
    {
        public List<ProductListModel> Products { get; set; }
    }

    public class ProductListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
