using NUnit.Framework;
using ECommerceApp_2.Core;
using System.Linq;

namespace ECommerceApp_2.Tests.UnitTests
{
    [TestFixture]
    public class ECommerceTests
    {
        private Cart _cart = null!;
        private OrderService _orderService = null!;

        [SetUp]
        public void Setup()
        {
            _cart = new Cart();
            _orderService = new OrderService();
        }

        // --- BLACK BOX TESTS ---
        [Test]
        public void Test01_BlackBox_Discount_ShouldSubtract()
        {
            decimal result = _orderService.ApplyDiscount(100, 20);
            Assert.That(result, Is.EqualTo(80), "HATA: Indirim miktari dusulmedi!");
        }

        [Test]
        public void Test02_BlackBox_TotalCalculation()
        {
            _cart.AddProduct(new Product { Price = 100 });
            _cart.AddProduct(new Product { Price = 200 });
            Assert.That(_cart.GetTotal(), Is.EqualTo(300));
        }

        [Test]
        public void Test03_BlackBox_EmptyCart_TotalZero()
        {
            Assert.That(_cart.GetTotal(), Is.EqualTo(0));
        }

        // --- WHITE BOX TESTS ---
        [Test]
        public void Test04_WhiteBox_Payment_EmptyCard_Fail()
        {
            bool result = _orderService.ProcessPayment("");
            Assert.That(result, Is.False, "HATA: Bos kart onaylanmamali!");
        }

        [Test]
        public void Test05_WhiteBox_Payment_ValidCard_Pass()
        {
            bool result = _orderService.ProcessPayment("1234-5678-9012");
            Assert.That(result, Is.True);
        }

        // --- GRAY BOX TESTS ---
        [Test]
        public void Test06_GrayBox_StockControl()
        {
            var p = new Product { Name = "Stoksuz", Stock = 0, Price = 100 };
            _cart.AddProduct(p);
            Assert.That(_cart.Items.Count, Is.EqualTo(0), "HATA: Stokta olmayan urun sepete eklendi!");
        }

        [Test]
        public void Test07_GrayBox_NegativePriceCheck()
        {
            var p = new Product { Name = "Gecersiz", Price = -50 };
            _cart.AddProduct(p);
            Assert.That(_cart.GetTotal(), Is.GreaterThanOrEqualTo(0));
        }

        // --- INTEGRATION TESTS ---
        [Test]
        public void Test08_Integration_FullFlow()
        {
            _cart.AddProduct(new Product { Name = "Urun", Price = 1000, Stock = 5 });
            decimal final = _orderService.ApplyDiscount(_cart.GetTotal(), 100);
            bool pay = _orderService.ProcessPayment("1234");
            Assert.That(final, Is.EqualTo(900));
        }

        // --- UNIT TESTS (BASIC) ---
        [Test]
        public void Test09_Unit_ProductCreation()
        {
            var p = new Product { Name = "Test" };
            Assert.That(p.Name, Is.EqualTo("Test"));
        }

        [Test]
        public void Test10_Unit_CartItemCount()
        {
            _cart.AddProduct(new Product { Price = 10 });
            Assert.That(_cart.Items.Count, Is.EqualTo(1));
        }
    }
}