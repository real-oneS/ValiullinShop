using ValiullinShop.Models.Repository;

namespace ValiullinShop.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public int? Sum { get; set; }
        public int AllItemsCount { get; set; }
        public Cart() { }
        public Cart(CartItem item)
        {
            Items.Add(item);
            Items.Sum(item => item.Sum);
            foreach (var item1 in Items)
            {
                AllItemsCount += item1.Count;
            }
        }
        public void Add(int id)
        {
            ProductsRepository repository = new ProductsRepository();
            var item = repository.FindById(id);
            if (Items.FirstOrDefault(s => s.product.Id == id) == null)
            {
                var cartItem = new CartItem(item);
                Items.Add(cartItem);
            }
            else
            {
                Items.First(s => s.product.Id == id).Count++;
                Items.First(s => s.product.Id == id).Sum = Items.First(s => s.product.Id == id).product.Price * Items.First(s => s.product.Id == id).Count;
            }

            Sum = Items.Sum(s => s.Sum);
            AllItemsCount++;
        }
        public void Remove(int id)
        {
            if (Items.FirstOrDefault(s => s.product.Id == id) != null)
            {
                var cartItem = Items.FirstOrDefault(i => i.product.Id == id);
                Items.Remove(cartItem);
                Sum = Items.Sum(s => s.Sum);
                AllItemsCount = 0;
                foreach (var itemm in Items)
                {
                    AllItemsCount += itemm.Count;
                }
            }
        }

        public void Update(int id, int num)
        {
            Items.First(s => s.product.Id == id).Count = num;
            Items.First(s => s.product.Id == id).Sum = Items.First(s => s.product.Id == id).product.Price * Items.First(s => s.product.Id == id).Count;
            Sum = Items.Sum(s => s.Sum);
            AllItemsCount = 0;
            foreach (var itemm in Items)
            {
                AllItemsCount += itemm.Count;
            }

            if (Items.First(s => s.product.Id == id).Count <= 0)
            {
                Remove(id);
                Sum = Items.Sum(s => s.Sum);
            }
        }

        public void UpdatePlus(int id)
        {
            Items.First(s => s.product.Id == id).Count++;
            Items.First(s => s.product.Id == id).Sum = Items.First(s => s.product.Id == id).product.Price * Items.First(s => s.product.Id == id).Count;
            Sum = Items.Sum(s => s.Sum);
            AllItemsCount++;

            if (Items.First(s => s.product.Id == id).Count <= 0)
            {
                Remove(id);
                Sum = Items.Sum(s => s.Sum);
            }
        }

        public void UpdateMinus(int id)
        {
            Items.First(s => s.product.Id == id).Count--;
            Items.First(s => s.product.Id == id).Sum = Items.First(s => s.product.Id == id).product.Price * Items.First(s => s.product.Id == id).Count;
            Sum = Items.Sum(s => s.Sum);
            AllItemsCount--;

            if (Items.First(s => s.product.Id == id).Count <= 0)
            {
                Remove(id);
                Sum = Items.Sum(s => s.Sum);
            }
        }

        public int GetAllCartItems()
        {
            AllItemsCount = 0;
            foreach (var itemm in Items)
            {
                AllItemsCount += itemm.Count;
            }
            return (int)AllItemsCount;
        }
    }
}
