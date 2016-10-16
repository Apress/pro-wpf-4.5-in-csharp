using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace StoreDatabase
{
    public class StoreDbDataSet
    {
        private string connectionString = StoreDatabase.Properties.Settings.Default.Store;

        public DataTable GetProducts()
        {            
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
            return ds.Tables[0];
        }

        public DataSet GetCategoriesAndProducts()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
            cmd.CommandText = "GetCategories";
            adapter.Fill(ds, "Categories");

            // Set up a relation between these tables (optional).
            DataRelation relCategoryProduct = new DataRelation("CategoryProduct",
              ds.Tables["Categories"].Columns["CategoryID"],
              ds.Tables["Products"].Columns["CategoryID"]);
            ds.Relations.Add(relCategoryProduct);

            return ds;
        }


    }
}
