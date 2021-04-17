using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Interfaces
{
    public interface IShipmentService
    {
        void Ship(IAddressInfo info, IEnumerable<CartItem> items);
    }
}
