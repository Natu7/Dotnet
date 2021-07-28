using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PrjAdo.NetEg
{
    class DataAccessLayer
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
             "Data Source = RAJ; Initial Catalog = Northwind; Integrated Security = true");
            con.Open();
            return con;
        }

        //Procedure without parameter
        internal void CallTenMostExpensiveProduct()
        {
            try
            {
                con = GetConnection();
                //Procedure name in sqlserver
                cmd = new SqlCommand("Ten Most Expensive Products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1]);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }

        internal void CallCustOrders(string cid)
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("CustOrdersOrders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", cid);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["OrderID"] + " " + dr["OrderDate"] + " " + dr["ShippedDate"]);
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
    }

    class StoredProcedureEg
    {
        static void Main()
        {
            /* DataAccessLayer spobject = new DataAccessLayer();
             spobject.CallTenMostExpensiveProduct();

             Console.WriteLine("Enter the Customerid");
             string cid = Console.ReadLine();
             spobject.CallCustOrders(cid);*/
            Console.WriteLine("**");
            Console.WriteLine("1. Ten most expensive products");
            Console.WriteLine("2. Display customer order details");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DataAccessLayer sp1 = new DataAccessLayer();
                    sp1.CallTenMostExpensiveProduct();
                    break;

                case 2:
                    Console.WriteLine("Enter Customer ID");
                    string CustID = Console.ReadLine();
                    DataAccessLayer sp2 = new DataAccessLayer();
                    sp2.CallCustOrders(CustID);
                    break;

            }
        }
    }
}
