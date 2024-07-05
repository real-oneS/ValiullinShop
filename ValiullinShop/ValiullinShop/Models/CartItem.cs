namespace ValiullinShop.Models
{
    public class CartItem
    {
        public ProductModel product { get; set; }
        public int Count { get; set; } 
        public int? Sum { get; set; }
        public CartItem() { }
        public CartItem(ProductModel product)
        {
            this.product = product;
            this.Count += 1;
            this.Sum =product.Price * this.Count;
        }

    }
}
