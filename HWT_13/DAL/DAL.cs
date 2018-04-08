namespace DAL
{
    using System.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Components;
    using System.Data;
    
    public class DAL
    {
        private readonly DbProviderFactory providerFactory;
        private readonly string connectionString;

        static void Main()
        {
        }

        public DAL() 
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["Northwind Connection"];
            connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            providerFactory = DbProviderFactories.GetFactory(providerName);
        }

        public List<Order> GetOrders(int firstRecordNumber, int lastRecordNumber)
        {
            int countRecords = lastRecordNumber - firstRecordNumber + 1;
            if (countRecords <= 0)
            {
                return new List<Order>();
            }

            var orders = new List<Order>(countRecords);
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();

                command.CommandText = "SELECT ord.num, ord.OrderID, " +
                    "ord.CustomerID, ord.ShippedDate, ord.OrderDate " +
                    "FROM (SELECT ROW_NUMBER() OVER (ORDER BY OrderID) AS num, " +
                    "OrderID, CustomerID, ShippedDate, OrderDate " +
                    "FROM Northwind.Orders) AS ord " +
                    "WHERE ord.num BETWEEN @first AND @last";
                command.CommandType = CommandType.Text;
                command.AddParameterWithValue("last", lastRecordNumber);
                command.AddParameterWithValue("first", firstRecordNumber);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            CustomerID = !Convert.IsDBNull(reader["CustomerID"]) ? (string)reader["CustomerID"] : null,
                            ShippedDate = !Convert.IsDBNull(reader["ShippedDate"]) ? (DateTime?)reader["ShippedDate"] : null,
                            OrderDate = !Convert.IsDBNull(reader["OrderDate"]) ? (DateTime?)reader["OrderDate"] : null,
                            OrderID = (int)reader["OrderID"],
                        });
                    }
                }
            }

            return orders;
        }

        public int GetTotalCountOrders()
        {
            int ordersCount;

            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Northwind.Orders";
                command.CommandType = CommandType.Text;
                connection.Open();

                ordersCount = (int)command.ExecuteScalar();
            }

            return ordersCount;
        }

        public Order GetInfoOrder(int orderID)
        {
            Order order = new Order();
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CustomerID, ShippedDate, " +
                    "OrderDate, RequiredDate, Freight, ShipName, " +
                    "ShipAddress, ShipCity, ShipRegion, ShipPostalCode, " +
                    "ShipCountry FROM Northwind.Orders WHERE OrderID = @OrderID";
                command.CommandType = CommandType.Text;
                command.AddParameterWithValue("OrderID", orderID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order = new Order
                        {
                            OrderID = orderID,
                            CustomerID = !Convert.IsDBNull(reader["CustomerID"]) ? (string)reader["CustomerID"] : null,
                            RequiredDate = !Convert.IsDBNull(reader["RequiredDate"]) ? (DateTime?)reader["RequiredDate"] : null,
                            ShippedDate = !Convert.IsDBNull(reader["ShippedDate"]) ? (DateTime?)reader["ShippedDate"] : null,
                            OrderDate = !Convert.IsDBNull(reader["OrderDate"]) ? (DateTime?)reader["OrderDate"] : null,
                            Freight = !Convert.IsDBNull(reader["Freight"]) ? (decimal?)reader["Freight"] : null,
                            ShipName = !Convert.IsDBNull(reader["ShipName"]) ? (string)reader["ShipName"] : null,
                            ShipAddress = !Convert.IsDBNull(reader["ShipCity"]) ? (string)reader["ShipCity"] : null,
                            ShipCity = !Convert.IsDBNull(reader["ShipAddress"]) ? (string)reader["ShipAddress"] : null,
                            ShipPostalCode = !Convert.IsDBNull(reader["ShipPostalCode"]) ? (string)reader["ShipPostalCode"] : null,
                            ShipCountry = !Convert.IsDBNull(reader["ShipCountry"]) ? (string)reader["ShipCountry"] : null,
                        };
                    }
                }
            }

            order.Products = GetOrderDetails(order.OrderID);
            return order;
        }

        public int AddOrder(
            DateTime? orderDate,
            DateTime? requiredDate,
            DateTime? shippedDate,
            decimal? freight,
            string shipName,
            string shipAddress,
            string shipCity,
            string shipRegion,
            string shipPostalCode,
            string shipCountry,
            int? employeeID = null)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [Northwind].[Orders] ([OrderDate], [RequiredDate], " +
                    "[ShippedDate], [Freight], [ShipName], " +
                    "[ShipAddress], [ShipCity], [ShipRegion], [ShipPostalCode], " +
                    "[ShipCountry]) VALUES " +
                    "(@orderDate, @requiredDate, @shippedDate, " +
                    "@freight, @shipName, @shipAddress, @shipCity, " +
                    "@shipRegion, @shipPostalCode, @shipCountry)";
                command.CommandType = CommandType.Text;

                command.AddParameterWithValue("@orderDate", orderDate);
                command.AddParameterWithValue("@requiredDate", requiredDate);
                command.AddParameterWithValue("@shippedDate", shippedDate);
                command.AddParameterWithValue("@freight", freight);
                command.AddParameterWithValue("@shipName", shipName);
                command.AddParameterWithValue("@shipAddress", shipAddress);
                command.AddParameterWithValue("@shipRegion", shipRegion);
                command.AddParameterWithValue("@shipCity", shipCity);
                command.AddParameterWithValue("@shipPostalCode", shipPostalCode);
                command.AddParameterWithValue("@shipCountry", shipCountry);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int AddProduct(
            int OrderID,
            string ProductName,
            decimal? UnitPrice,
            int? Discount,
            Int16? Quantity)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Northwind.Products " +
                "(ProductName, UnitPrice) VALUES(@ProductName, @UnitPrice) " +
                "INSERT INTO Northwind.[Order Details] " +
                "(UnitPrice, Discount, Quantity, ProductID, OrderID) " +
                "VALUES(@UnitPrice, CONVERT(real, @Discount) / 100, @Quantity, SCOPE_IDENTITY(), @OrderID)";
                command.CommandType = CommandType.Text;

                command.AddParameterWithValue("@OrderID", OrderID);
                command.AddParameterWithValue("@UnitPrice", UnitPrice);
                command.AddParameterWithValue("@Discount", Discount);
                command.AddParameterWithValue("@Quantity", Quantity);
                command.AddParameterWithValue("@ProductName", ProductName);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int SetOrderDate(DateTime? orderDate, int orderID)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders " +
                "SET orderDate =  @orderDate WHERE orderID = @orderID";
                command.CommandType = CommandType.Text;

                command.AddParameterWithValue("@orderDate", orderDate);
                command.AddParameterWithValue("@orderID", orderID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public int SetShippedDate(DateTime? shippedDate, int orderID)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Northwind.Orders" +
                "SET shippedDate =  @shippedDate WHERE orderID = @orderID";
                command.CommandType = CommandType.Text;

                command.AddParameterWithValue("@shippedDate", shippedDate);
                command.AddParameterWithValue("@orderID", orderID);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public List<Product> GetOrderHistory(string customerID)
        {
            var products = new List<Product>();
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrderHist";
                command.CommandType = CommandType.StoredProcedure;
                command.AddParameterWithValue("@CustomerID", customerID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductName = !Convert.IsDBNull(reader["ProductName"]) ? (string)reader["ProductName"] : null,
                            Total = !Convert.IsDBNull(reader["Total"]) ? (int?)reader["Total"] : null,
                        });
                    }
                }
            }

            return products;
        }

        public List<Product> GetOrderDetails(int orderID)
        {
            var products = new List<Product>();
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT p.ProductID, ProductName, " +
                    "UnitPrice = ROUND(Od.UnitPrice, 2), Quantity, " +
                    "Discount = CONVERT(int, Discount * 100), " +
                    "ExtendedPrice = " +
                    "ROUND(CONVERT(money, Quantity * (1 - Discount) * " +
                    "Od.UnitPrice), 2) " +
                    "FROM[Northwind].Products P, [Northwind].[Order Details] Od " +
                    "WHERE Od.ProductID = P.ProductID and Od.OrderID = @orderID";
                command.CommandType = CommandType.Text;
                command.AddParameterWithValue("orderID", orderID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductID = (int)reader["ProductID"],
                            ProductName = !Convert.IsDBNull(reader["ProductName"]) ? (string)reader["ProductName"] : null,
                            UnitPrice = !Convert.IsDBNull(reader["UnitPrice"]) ? (decimal?)reader["UnitPrice"] : null,
                            Quantity = !Convert.IsDBNull(reader["Quantity"]) ? (Int16?)reader["Quantity"] : null,
                            Discount = !Convert.IsDBNull(reader["Discount"]) ? (int?)reader["Discount"] : null,
                            ExtendedPrice = !Convert.IsDBNull(reader["ExtendedPrice"]) ? (decimal?)reader["ExtendedPrice"] : null,
                        });
                    }
                }
            }

            return products;
        }

        public decimal? GetExtendedPrice(int orderID)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                var command = connection.CreateCommand();
                command.CommandText = "SELECT ExtendedPrice = " +
                    "SUM(ROUND(CONVERT(money," +
                    "Quantity * + (1 - Discount) * Od.UnitPrice), 2)) " +
                    "FROM [Northwind].Products P, [Northwind].[Order Details] Od " +
                    "WHERE Od.ProductID = P.ProductID and Od.OrderID = @orderID";
                command.CommandType = CommandType.Text;

                command.AddParameterWithValue("@orderID", orderID);

                connection.Open();
                return (decimal?)command.ExecuteScalar();
            }
        }
    }
}
