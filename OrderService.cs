namespace ECommerceApp_2.Core
{
    public class OrderService
    {
       
        public bool ProcessPayment(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber)) return false;
            return true; // BUG: Boş değilse hep onaylıyor
        }

        public decimal ApplyDiscount(decimal total, decimal discountAmount)
        {
            return total + discountAmount; // BUG: Çıkarmak yerine topluyor
        }
    }
}