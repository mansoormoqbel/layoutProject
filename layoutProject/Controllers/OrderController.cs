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
        public IActionResult Index(Order CurrentOrder)
        {
            //1- Open the Connetion to DB server
            con.Open();


            cmd.Connection = con;
            cmd.CommandText = "Insert Into Order() Values() ";
            int RowAffected = cmd.ExecuteNonQuery();
            if (RowAffected>0)
            {
                ViewBag.Message = "Record Inserted";
            }
            else
            {
                ViewBag.Message = "Error, Record not Inserted";
            }

            // 5-close the con
            con.Close();

            ViewBag.Header = "Order Details";
            ViewBag.MyOrder = CurrentOrder;
            return View(CurrentOrder);
        }
        public IActionResult OrderRequest()
        {
            return View();
        }
    }
}
