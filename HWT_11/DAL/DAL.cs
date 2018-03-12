namespace DAL
{
    // СТОИТ НЕ В АЛФАВИТНОМ ПОРЯДКЕ, СЕРЬЕЗНО ????
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using Components;

    public class DAL
    {
        private readonly DbProviderFactory providerFactory;
        private readonly string connectionString;

        public DAL()
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["NorthwindConnection"];//todo pn АТАТА!
            this.connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            this.providerFactory = DbProviderFactories.GetFactory(providerName);
        }

        public List<Order> GetOrders(int countOrders)
        {
            var orders = new List<Order>(countOrders);

            using (var connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT TOP 1 OrderID, CustomerID, ShippedDate, " +
                    "OrderDate FROM Northwind.Orders";
                command.CommandType = CommandType.Text;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            CustomerID = (string)reader["CustomerID"],
                            ShippedDate = (DateTime)reader["ShippedDate"],
                            OrderDate = (DateTime)reader["OrderDate"],
                        });

                        OrderStatus stateOrder = orders[orders.Count - 1].GetStateOrder();
                    }
                }
            }

            return orders;
        }

        public List<Order> GetInfoOrder(int orderID)
        {
            var orders = new List<Order>();
            using (var connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ord.OrderID, ord.ShippedDate, ord.OrderDate, " +
                    "orddet.ProductID, prod.ProductName FROM Northwind.Orders " +
                    "AS ord INNER JOIN Northwind.[Order Details] AS ordDet " +
                    "ON ord.OrderID = ordDet.OrderID AND ord.OrderID = @orderID " +
                    "INNER JOIN Northwind.Products " +
                    "AS prod ON ordDet.ProductID = prod.ProductID";
                command.CommandType = CommandType.Text;
                command.CreateParameterWithValue("OrderID", orderID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            OrderID = (int)reader["OrderID"],
                            ProductID = (int)reader["ProductID"],
                            ProductName = (string)reader["ProductName"],
                            ShippedDate = (DateTime)reader["ShippedDate"],
                            OrderDate = (DateTime)reader["OrderDate"]
                        });
                    }
                }
            }

            return orders;
        }

        public int AddOrder(
            int orderID,
            string customerID,
            int? employeeID,
            DateTime orderDate,
            DateTime requiredDate,
            DateTime shippedDate,
            int? shipVia,
            double? freight,
            string shipName,
            string shipAddress,
            string shipCity,
            string shipRegion,
            string shipPostalCode,
            string shipCountry)
        {
            using (var connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [Northwind].[Orders]([CustomerID], [EmployeeID], [OrderDate], [RequiredDate], " +
                    "[ShippedDate], [ShipVia], [Freight], [ShipName], " +
                    "[ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], " +
                    "[ShipCountry]) VALUES (@customerID, @employeeID, " +
                    "@orderDate, @requiredDate, @shippedDate, @shipVia, " +
                    "@freight, @shipName, @shipAddress, @shipCity, " +
                    "@shipRegion, @shipPostalCode, @shipCountry)";
                command.CommandType = CommandType.Text;

                command.CreateParameterWithValue("@customerID", customerID);
                command.CreateParameterWithValue("@employeeID", employeeID);
                command.CreateParameterWithValue("@orderDate", orderDate);
                command.CreateParameterWithValue("@requiredDate", requiredDate);
                command.CreateParameterWithValue("@shippedDate", shippedDate);
                command.CreateParameterWithValue("@shipVia", shipVia);
                command.CreateParameterWithValue("@freight", freight);
                command.CreateParameterWithValue("@shipName", shipName);
                command.CreateParameterWithValue("@shipAddress", shipAddress);
                command.CreateParameterWithValue("@shipRegion", shipRegion);
                command.CreateParameterWithValue("@shipCity", shipCity);
                command.CreateParameterWithValue("@shipPostalCode", shipPostalCode);
                command.CreateParameterWithValue("@shipCountry", shipCountry);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int SetOrderDate(DateTime orderDate, int orderID)
        {
            using (var connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders " +
                "SET orderDate =  @orderDate WHERE orderID = @orderID";
                command.CommandType = CommandType.Text;

                command.CreateParameterWithValue("@orderDate", orderDate);
                command.CreateParameterWithValue("@orderID", orderID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int SetShippedDate(DateTime shippedDate, int orderID)
        {
            using (var connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders" +
                "SET shippedDate =  @shippedDate WHERE orderID = @orderID";
                command.CommandType = CommandType.Text;

                command.CreateParameterWithValue("@shippedDate", shippedDate);
                command.CreateParameterWithValue("@orderID", orderID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public List<Product> GetOrderHistory(string customerID)
        {
            var products = new List<Product>();
            using (var connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrderHist";
                command.CommandType = CommandType.StoredProcedure;
                command.CreateParameterWithValue("@CustomerID", customerID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductName = (string)reader["ProductName"],
                            Total = (int)reader["Total"]
                        });
                    }
                }
            }

            return products;
        }

        public List<Product> GetOrderDetails(int orderID)
        {
            var products = new List<Product>();
            using (var connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrdersDetail";
                command.CommandType = CommandType.StoredProcedure;
                command.CreateParameterWithValue("@orderID", orderID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductName = (string)reader["ProductName"],
                            UnitPrice = (decimal)reader["UnitPrice"],
                            Quantity = (short)reader["Quantity"],
                            Discount = (int)reader["Discount"],
                            ExtendedPrice = (decimal)reader["ExtendedPrice"],
                        });
                    }
                }
            }

            return products;
        }
    }
}
