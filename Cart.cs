using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp_2.Core
{
    public class Cart
    {
        // Sepetteki ürünler listesi
        public List<Product> Items { get; set; } = new List<Product>();

        // Minimum sipariş tutarı özelliği
        public decimal MinOrderAmount = 100m;

        public void AddProduct(Product product)
        {
            // BUG: Stok kontrolü yok.
            // Stok 0 olsa bile ürünü sepete ekliyor.
            // Bu hata, testlerinde "Stoksuz ürün sepete eklenmemeli" testinin Fail vermesini sağlar.
            Items.Add(product);
        }

        public decimal GetTotal()
        {
            return Items.Sum(x => x.Price);
        }

        
        public bool CanCheckout()
        {
            // BUG: Sınır değer hatası (Boundary Value Error).
            // Min tutar 100 ise 100'e izin vermeli (>= 100), ama biz sadece > 100 dedik.
            
            return GetTotal() > MinOrderAmount;
        }
    }
}