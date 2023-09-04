using Microsoft.AspNetCore.Mvc;
using layoutProject.Models;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System;
using System.Configuration;
using System.Configuration.Provider;


namespace layoutProject.Controllers
{

    public class OrderController : Controller
    {
        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-360NCCM\MSSQLSERVER01; Integrated Security=true;Initial Catalog= DeliveryDB; ");
        SqlCommand cmd = new SqlCommand();
        public IActionResult Index()
        {

            // Define the connection string and the query
            
            string query = "SELECT * FROM Orders";

            // Create a connection and a command objects
            using (con)
            {
                SqlCommand command = new SqlCommand(query, con);

                // Open the connection and execute the query
                con.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Pass the reader to the view using ViewBag
                ViewBag.Reader = reader;
            }

            // Return the view
            return View();
        }
        public IActionResult OrderRequest()
        {
            return View();
        }
        public IActionResult InsertOrder(Order CurrentOrder)
        {
            try
            {
                //1- Open the Connetion to DB server
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Insert Into Orders (OrderId, OrderKey, Phone, Email, Payment, Quantity, Price, Packaging, Tracking, Location, Address)" +
                                    " Values (@OrderId, @OrderKey, @Phone, @Email, @Payment, @Quantity, @Price, @Packaging, @Tracking, @Location, @Address)";

                cmd.Parameters.AddWithValue("@OrderId", CurrentOrder.OrderId);
                cmd.Parameters.AddWithValue("@OrderKey", CurrentOrder.OrderKey);
                cmd.Parameters.AddWithValue("@Phone", CurrentOrder.Phone);
                cmd.Parameters.AddWithValue("@Email", CurrentOrder.Email);
                cmd.Parameters.AddWithValue("@Payment", CurrentOrder.Payment);
                cmd.Parameters.AddWithValue("@Quantity", CurrentOrder.Quantity);
                cmd.Parameters.AddWithValue("@Price", CurrentOrder.Price);
                cmd.Parameters.AddWithValue("@Packaging", CurrentOrder.Packaging);
                cmd.Parameters.AddWithValue("@Tracking", CurrentOrder.Tracking);
                cmd.Parameters.AddWithValue("@Location", CurrentOrder.Location);
                cmd.Parameters.AddWithValue("@Address", CurrentOrder.Address);



                //RowAffected
                int RowAffected = cmd.ExecuteNonQuery();
                if (RowAffected > 0)
                {
                    ViewBag.Message = "Record Inserted";
                }
                else
                {
                    ViewBag.Message = "Error, Record not Inserted";
                }

                
               

            }
            catch(ArgumentNullException ex)
            {
                ViewBag.Message = ex.Message;
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("Error",new ErrorViewModel());
            }
            finally
            {
                // 5-close the con
                con.Close();
            }
            return View("Index");
        }
    }
}
