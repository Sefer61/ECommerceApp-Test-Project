using System;
using ECommerceApp_2.Core;

namespace ECommerceApp_2
{
    class Program
    {
        static void Main()
        {
            Cart sepet = new Cart();
            OrderService servis = new OrderService();

            Console.WriteLine("=== E-TICARET SIMULASYONUNA HOSGELDINIZ ===");

            // 1. Ürün Seçme
            Product urun1 = new Product { Id = 1, Name = "Laptop", Price = 15000, Stock = 5 };
            Product urun2 = new Product { Id = 2, Name = "Mouse (Stoksuz)", Price = 500, Stock = 0 };

            Console.WriteLine($"\n1. ADIM: Urunler Hazirlandi: {urun1.Name} ve {urun2.Name}");

            // 2. Sepete Ekleme
            Console.WriteLine("\n2. ADIM: Urunler sepete ekleniyor...");
            sepet.AddProduct(urun1);
            sepet.AddProduct(urun2); // BUG: Stok 0 olduğu halde ekleniyor!

            // 3. Sipariş Özeti ve Min Tutar Kontrolü
            Console.WriteLine($"\n3. ADIM: Sepet Ozeti");
            Console.WriteLine($"Sepetteki Urun Sayisi: {sepet.Items.Count}");
            Console.WriteLine($"Toplam Tutar: {sepet.GetTotal()} TL");

            // Yeni özellik: Minimum Tutar Kontrolü
            bool canCheckout = sepet.CanCheckout();
            Console.WriteLine($"Siparis Onay Durumu: {(canCheckout ? "ONAYLANDI" : "REDDEDILDI (Min Tutar Hatasi)")}");

            // 4. İndirim ve Ödeme
            decimal indirimliFiyat = servis.ApplyDiscount(sepet.GetTotal(), 1000);
            Console.WriteLine($"\n4. ADIM: Indirim Uygulaniyor (1000 TL)...");
            Console.WriteLine($"Odenecek Tutar: {indirimliFiyat} TL (Dikkat: Bug var, fiyat artabilir!)");

            bool odemeDurumu = servis.ProcessPayment("1234-5678");
            Console.WriteLine(odemeDurumu ? "ODEME BASARILI!" : "ODEME REDDEDILDI!");

            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine("Sistem calismasi bitti. Testleri gormek icin Test Explorer'i acin.");
            Console.ReadLine();
        }
    }
}