using ShoppingCart.Models;

namespace ShoppingCart.Interfaces
{
    public interface IPaymentService
    {
        bool Charge(double total, ICard card);
    }
}
