using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp_2.Core
{
    public class Cart
    {
       
        public List<Product> Items { get; set; } = [];

        public void AddProduct(Product product)
        {
            // BUG: Stok kontrolü yok
            Items.Add(product);
        }

        public decimal GetTotal()
        {
            return Items.Sum(x => x.Price);
        }
    }
}