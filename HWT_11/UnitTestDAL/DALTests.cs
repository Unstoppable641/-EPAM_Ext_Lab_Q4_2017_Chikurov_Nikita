namespace UnitTestDAL
{
    using System;
    using System.Collections.Generic;
    using DAL;
    using DAL.Components;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DALTests
    {
        private static DAL dal;

        [ClassInitialize]
        public static void InitializeClassTest(TestContext testContext)
        {
            dal = new DAL();
        }

        [TestMethod]
        public void GetOrdersTest()
        {
            // arrange
            int countOrders = 1;
            DAL dal = new DAL();
            var orders = new List<Order>();
            int expectedOrderID = 22;
            string expectedCustomerID = "Alex";
            DateTime expectedShippedDate = new DateTime(1996, 7, 16);
            DateTime expectedOrderDate = new DateTime(1996, 4, 7);
            OrderStatus expectedStateOrder = OrderStatus.Executed;

            // act
            orders = dal.GetOrders(countOrders);

            // assert
            Assert.AreEqual(expectedOrderID, orders[0].OrderID);
            Assert.AreEqual(expectedCustomerID, orders[0].CustomerID);
            Assert.AreEqual(expectedShippedDate, orders[0].ShippedDate);
            Assert.AreEqual(expectedOrderDate, orders[0].OrderDate);
            Assert.AreEqual(expectedStateOrder, orders[0].GetStateOrder());
        }

        [TestMethod]
        public void GetInfoOrderTest()
        {
            // arrange
            List<Order> order = new List<Order>();
            int orderID = 1;
            int expectedOrderID = orderID;
            int expectedProductID = 1;
            string expectedProductName = "CASE WITH SHIT";
            DateTime expectedShippedDate = new DateTime(1996, 7, 16);
            DateTime expectedOrderDate = new DateTime(1996, 4, 7);

            // act
            order = dal.GetInfoOrder(orderID);

            // assert
            Assert.AreEqual(expectedOrderID, order[0].OrderID);
            Assert.AreEqual(expectedProductID, order[0].ProductID);
            Assert.AreEqual(expectedProductName, order[0].ProductName);
            Assert.AreEqual(expectedShippedDate, order[0].ShippedDate);
            Assert.AreEqual(expectedOrderDate, order[0].OrderDate);
        }

        [TestMethod]
        public void AddOrderTest()
        {
            int expected = 1;
            int actual = dal.AddOrder(
                20000,
                "Alex",
                5,
                new DateTime(1996, 7, 16),
                new DateTime(1996, 8, 16),
                new DateTime(1996, 9, 16),
                3,
                200,
                "ship",
                "York",
                "London",
                "Okinawa",
                "code",
                "GB");

            // assert
            Assert.AreEqual(expected, actual);//todo pn некорректный тест (а если в базе уже есть такая запись? тест упадет)
		}

        [TestMethod]
        public void SetOrderDateTest()
        {
            DateTime orderDate = new DateTime(1996, 4, 7);

            int orderID = 10248;

            int expected = 1;

            int actual = dal.SetOrderDate(orderDate, orderID);

            Assert.AreEqual(expected, actual);//todo pn некорректный тест
        }

        [TestMethod]
        public void SetShippedDateTest()
        {
            DateTime orderDate = new DateTime(1976, 1, 1);

            int orderID = 222;

            int expected = 1;

            int actual = dal.SetOrderDate(orderDate, orderID);

            Assert.AreEqual(expected, actual);//todo pn некорректный тест
		}

        [TestMethod]
        public void GetOrderHistoryTest()
        {
            // arrange
            string customerID = "Alex";

            List<Product> products = new List<Product>();
            string expectedProductName = "Posh Spice";
            int expectedTotal = 18;

            // act
            products = dal.GetOrderHistory(customerID);

            // assert
            Assert.AreEqual(expectedProductName, products[0].ProductName);
            Assert.AreEqual(expectedTotal, products[0].Total);
        }

        [TestMethod]
        public void GetOrderDetailsTest()
        {
            // arrange
            int orderID = 10248;
            List<Product> products = new List<Product>();
            string expectedProductName = "Queso Cabrales";
            decimal expectedUnitPrice = 14;
            short expectedQuantity = 12;
            int expectedDiscount = 0;
            decimal expectedExtendedPrice = 168;

            // act
            products = dal.GetOrderDetails(orderID);

            // assert
            Assert.AreEqual(expectedProductName, products[0].ProductName);
            Assert.AreEqual(expectedUnitPrice, products[0].UnitPrice);
            Assert.AreEqual(expectedQuantity, products[0].Quantity);
            Assert.AreEqual(expectedDiscount, products[0].Discount);
            Assert.AreEqual(expectedExtendedPrice, products[0].ExtendedPrice);
        }
    }
}
