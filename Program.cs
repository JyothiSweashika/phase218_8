using System;
using System.Data.SqlClient;

namespace assignment5
{
    /*    class Program
       {

           static string connectionString = "Server=LAPTOP-DLI2FL88;database=ProductInventoryDB;trusted_connection=true";
           static void Main(string[] args)
           { 
                  using (SqlConnection connection = new SqlConnection(connectionString))

                   connection.Open();

                   bool continueProgram = true;
                   while (continueProgram)
                   {
                       Console.WriteLine("\nSelect an option:");
                       Console.WriteLine("1. View Product Inventory");
                       Console.WriteLine("2. Add New Product");
                       Console.WriteLine("3. Update Product Quantity");
                       Console.WriteLine("4. Remove Product");
                       Console.WriteLine("5. Exit");

                       int choice = Convert.ToInt32(Console.ReadLine());

                       switch (choice)
                       {
                           case 1:
                               ViewProductInventory(connection);
                               break;
                           case 2:
                               AddNewProduct(connection);
                               break;
                           case 3:
                               UpdateProductQuantity(connection);
                               break;
                           case 4:
                               RemoveProduct(connection);
                               break;
                           case 5:
                               continueProgram = false;
                               break;
                           default:
                               Console.WriteLine("Invalid choice.");
                               break;
                       }
                   }

                   connection.Close();
               }
           }

           static void ViewProductInventory(SqlConnection connection)
   {
       Console.WriteLine("Product Inventory:");
       string query = "SELECT * FROM Products";

       using (SqlCommand command = new SqlCommand(query, connection))
       {
           using (SqlDataReader reader = command.ExecuteReader())
           {
               while (reader.Read())
               {
                   Console.WriteLine($"ID: {reader["Productid"]}, Name: {reader["ProductName"]}, Price: {reader["Price"]}, Quantity: {reader["Quantity"]}");
               }
           }
       }
   }

   static void AddNewProduct(SqlConnection connection)
   {
       Console.WriteLine("Enter new product details:");
       Console.Write("Name: ");
       string productName = Console.ReadLine();
       Console.Write("Price: ");
       decimal price = Convert.ToDecimal(Console.ReadLine());
       Console.Write("Quantity: ");
       int quantity = Convert.ToInt32(Console.ReadLine());

       string insertQuery = "INSERT INTO Products (ProductName, Price, Quantity) VALUES (@ProductName, @Price, @Quantity)";

       using (SqlCommand command = new SqlCommand(insertQuery, connection))
       {
           command.Parameters.AddWithValue("@ProductName", productName);
           command.Parameters.AddWithValue("@Price", price);
           command.Parameters.AddWithValue("@Quantity", quantity);

           int rowsAffected = command.ExecuteNonQuery();
           if (rowsAffected > 0)
           {
               Console.WriteLine("New product added successfully.");
           }
           else
           {
               Console.WriteLine("Failed to add new product.");
           }
       }

           static void UpdateProductQuantity(SqlConnection connection)
           {
               Console.Write("Enter Product ID to update quantity: ");
               int productId = Convert.ToInt32(Console.ReadLine());
               Console.Write("Enter new Quantity: ");
               int newQuantity = Convert.ToInt32(Console.ReadLine());

               string updateQuery = "UPDATE Products SET Quantity = @NewQuantity WHERE Productid = @ProductId";

               using (SqlCommand command = new SqlCommand(updateQuery, connection))
               {
                   command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                   command.Parameters.AddWithValue("@ProductId", productId);

                   int rowsAffected = command.ExecuteNonQuery();
                   if (rowsAffected > 0)
                   {
                       Console.WriteLine("Product quantity updated successfully.");
                   }
                   else
                   {
                       Console.WriteLine("Failed to update product quantity.");
                   }
               }
           }

           static void RemoveProduct(SqlConnection connection)
           {
               Console.Write("Enter Product ID to remove: ");
               int productId = Convert.ToInt32(Console.ReadLine());

               string deleteQuery = "DELETE FROM Products WHERE Productid = @ProductId";

               using (SqlCommand command = new SqlCommand(deleteQuery, connection))
               {
                   command.Parameters.AddWithValue("@ProductId", productId);

                   int rowsAffected = command.ExecuteNonQuery();
                   if (rowsAffected > 0)
                   {
                       Console.WriteLine("Product removed successfully.");
                   }
                   else
                   {
                       Console.WriteLine("Failed to remove product.");
                   }
               }
           }
       }
   }*/


    internal class Program
    {
        static SqlDataReader reader;
        static SqlCommand cmd;
        static SqlConnection con;
        static string conStr = "server=DESKTOP-0NM2EJT;database=ProductInventoryDB;trusted_connection=true;";
        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Products", con);
                Console.WriteLine("Find out\n1.Display All products\n2.To Insert\n3.To Update\n4.To Remove,\nEnter your choice 1,2,3,or 4");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            con.Open();
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                Console.WriteLine("ProductID : " + reader["ProductId"]);
                                Console.WriteLine("Product Name : " + reader["ProductName"]);
                                Console.WriteLine("Price : " + reader["Price"]);
                                Console.WriteLine("Quantity: " + reader["Quantity"]);
                                Console.WriteLine("MfDate: " + reader["MfDate"]);
                                Console.WriteLine("ExpDate: " + reader["ExpDate"]);

                                Console.WriteLine("--------------------------------------------------------");


                            }
                            con.Close();
                            break;

                        }
                    case 2:
                        {
                            con = new SqlConnection(conStr);
                            cmd = new SqlCommand()
                            {
                                CommandText = "insert into Products(ProductID,ProductName,Price,Quantity,MfDate,ExpDate)values(@id,@name,@price,@quantity,@mfdate,@expdate)",
                                Connection = con
                            };
                            Console.WriteLine("Enter Product Id");
                            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter Product Name");
                            cmd.Parameters.AddWithValue("@name", Console.ReadLine());
                            Console.WriteLine("Enter Price");
                            cmd.Parameters.AddWithValue("@price", Console.ReadLine());
                            Console.WriteLine("Enter Quantity");
                            cmd.Parameters.AddWithValue("@quantity", double.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter MfDate");
                            cmd.Parameters.AddWithValue("@mfdate", Console.ReadLine());
                            Console.WriteLine("Enter ExpDate");
                            cmd.Parameters.AddWithValue("@expdate", Console.ReadLine());
                            con.Open();
                            int nor = cmd.ExecuteNonQuery();
                            if (nor >= 1)
                            {
                                Console.WriteLine("Record Inserted!!!");
                            }
                            con.Close();
                            break;
                        }
                    case 3:
                        {

                            int id;
                            Console.WriteLine("Enter Product ID to update details ");
                            id = int.Parse(Console.ReadLine());
                            con = new SqlConnection(conStr);
                            cmd = new SqlCommand()
                            {
                                CommandText = "select * from Products where ProductId=@id ",
                                Connection = con
                            };
                            cmd.Parameters.AddWithValue("@id", id);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                con.Close();
                                con.Open();
                                cmd.CommandText = "update Products set Quantity=@qty where ProductId=@pid";
                                Console.WriteLine("Enter New Quantity ");
                                cmd.Parameters.AddWithValue("@qty", Console.ReadLine());
                                cmd.Parameters.AddWithValue("@pid", id);
                                cmd.ExecuteNonQuery(); Console.WriteLine("Record Updated");
                            }
                            else
                            {
                                Console.WriteLine($"No Such ProductId {id} exist in our database");
                            }
                            break;
                        }
                    case 4:
                        {
                            con = new SqlConnection(conStr);
                            cmd = new SqlCommand()
                            {
                                CommandText = "Delete from Products where  ProductId=@id",
                                Connection = con
                            };
                            Console.WriteLine("Enter Product Id to Delete");
                            cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                            con.Open();
                            int nor = cmd.ExecuteNonQuery();
                            if (nor >= 1)
                            {
                                Console.WriteLine("Record Deleted!!!");
                            }
                            else
                            {
                                Console.WriteLine("No such Id not exist");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid operation choice");
                            return;
                        }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
            finally
            {
                //con.Close();
                Console.ReadKey();
            }
        }
    }
}




