using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using _2_POS_System_Product; // Assuming Product class is in this namespace

namespace POS_SQLServer
{
    internal class DataConection
    {
        public static SqlConnection DataCon { get; set; }

        // Window Authentication
        public static void ConnectionString(string server, string dbName)
        {
            DataCon = new SqlConnection($"Server={server};Database={dbName};Trusted_Connection=True;TrustServerCertificate=True;");
            DataCon.Open();
        }

        // SQL Authentication
        public static void ConnectionString(string server, string dbName, string user, string pass)
        {
            DataCon = new SqlConnection($"Server={server};Database={dbName};User Id={user};Password={pass};TrustServerCertificate=True;");
            DataCon.Open();
        }

        public static long GetNextProductID()
        {
            string sql = "SELECT IDENT_CURRENT('tblProduct') + IDENT_INCR('tblProduct')";

            using (SqlCommand cmd = new SqlCommand(sql, DataCon))
            {
                object result = cmd.ExecuteScalar();
                return Convert.ToInt64(result);
            }
        }
        public static List<Product> GetProducts() 
        { 
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM tblProduct";
            SqlCommand cmd = new SqlCommand(query, DataCon);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                long id = reader.GetInt64(0);
                string pName = reader.GetString(1);
                double price = reader.GetSqlMoney(2).ToDouble();
                int qtyInStock = reader.GetInt32(3);
                byte[] photo = (byte[])reader[4]; // Handle null photo
                long categoryId = reader.GetInt64(5);
                Product product = new Product(id, pName, price, qtyInStock, photo, categoryId);
                products.Add(product);
            }
            reader.Close();

            return products; 
        }

    }
}
