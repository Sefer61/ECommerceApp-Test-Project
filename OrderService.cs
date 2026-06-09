namespace ECommerceApp_2.Core
{
    public class OrderService
    {
        // "Statik olabilir" uyarısını gidermek için boş kurucu metod eklendi
        public OrderService() { }

        public bool ProcessPayment(string cardNumber)
        {
            // BUG: Kart numarası boş değilse sistem her zaman onay veriyor.
            
            
            if (string.IsNullOrWhiteSpace(cardNumber)) return false;
            return true;
        }

        public decimal ApplyDiscount(decimal total, decimal discountAmount)
        {
            // BUG: İndirim uygulaması hatalı. 
            
            return total + discountAmount;
        }
    }
}