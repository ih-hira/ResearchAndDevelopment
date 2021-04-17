using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ShoppingCart.Controllers;
using ShoppingCart.Interfaces;
using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Test
{
    public class CartControllerTest
    {
        private CartController controller;
        private Mock<IPaymentService> paymentServiceMock;
        private Mock<ICartService> cartServiceMock;

        private Mock<IShipmentService> shipmentServiceMock;
        private Mock<ICard> cardMock;
        private Mock<IAddressInfo> addressInfoMock;
        private List<CartItem> items;

        [SetUp]
        public void Setup()
        {
            cartServiceMock = new Mock<ICartService>();
            paymentServiceMock = new Mock<IPaymentService>();
            shipmentServiceMock = new Mock<IShipmentService>();

            // arrange
            cardMock = new Mock<ICard>();
            addressInfoMock = new Mock<IAddressInfo>();

            var cartItemMock = new Mock<CartItem>();
            cartItemMock.Setup(item => item.Price).Returns(10);
            cartItemMock.Setup(item => item.ProductId).Returns("10001");
            cartItemMock.Setup(item => item.Quantity).Returns(13);

            items = new List<CartItem>()
            {
                cartItemMock.Object
            };

            cartServiceMock.Setup(c => c.Items()).Returns(items);
            controller = new CartController(cartServiceMock.Object, paymentServiceMock.Object, shipmentServiceMock.Object);
        }

        [Test]
        public void ShouldReturnCharged()
        {
            paymentServiceMock.Setup(p => p.Charge(It.IsAny<double>(), cardMock.Object)).Returns(true);

            //Act
            var result = controller.CheckOut(cardMock.Object, addressInfoMock.Object) as ObjectResult;

            //Assert
            shipmentServiceMock.Verify(s => s.Ship(addressInfoMock.Object, items), Times.Once);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);

        }
    }
}
