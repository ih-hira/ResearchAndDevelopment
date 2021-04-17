using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Interfaces
{
    public interface ICartService
    {
        double Total();
        IEnumerable<CartItem> Items();
    }
}
