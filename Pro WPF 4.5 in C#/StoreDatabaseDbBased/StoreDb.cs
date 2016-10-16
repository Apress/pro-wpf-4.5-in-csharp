using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace StoreDatabase
{
	public class StoreDb
	{
        private string connectionString = StoreDatabase.Properties.Settings.Default.Store;

        public Product GetProduct(int ID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetProductByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductID", ID);
            
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    // Create a Product object that wraps the 
                    // current record.
                    Product product = new Product((string)reader["ModelNumber"],
                         (string)reader["ModelName"], (decimal)reader["UnitCost"],
                         (string)reader["Description"], (int)reader["CategoryID"],
                         (string)reader["CategoryName"], (string)reader["ProductImage"]);
                    return product;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                con.Close();
            }
        }

		public ICollection<Product> GetProducts()
		{			
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand("GetProducts", con);
			cmd.CommandType = CommandType.StoredProcedure;

            ObservableCollection<Product> products = new ObservableCollection<Product>();
			try
			{
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					// Create a Product object that wraps the 
					// current record.
                    Product product = new Product((string)reader["ModelNumber"],
                        (string)reader["ModelName"], (decimal)reader["UnitCost"],
                        (string)reader["Description"], (int)reader["CategoryID"],
                        (string)reader["CategoryName"], (string)reader["ProductImage"]);
					// Add to collection
					products.Add(product);
				}
			}
			finally
			{
				con.Close();
			}

			return products;
		}

        public ICollection<Product> GetProductsSlow()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            return GetProducts();
        }

        public ICollection<Product> GetProductsFilteredWithLinq(decimal minimumCost)
        {            
            // Get the full list of products.
            ICollection<Product> products = GetProducts();

            // Create a second collection with matching products.
            IEnumerable<Product> matches = from product in products
                      where product.UnitCost >= minimumCost
                      select product;

            return new ObservableCollection<Product>(matches.ToList());
        }

        public ICollection<Category> GetCategoriesAndProducts()
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
                        
            ObservableCollection<Category> categories = new ObservableCollection<Category>();
            foreach (DataRow categoryRow in ds.Tables["Categories"].Rows)
            {
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                foreach (DataRow productRow in categoryRow.GetChildRows(relCategoryProduct))
                {
                    products.Add(new Product(productRow["ModelNumber"].ToString(),
                        productRow["ModelName"].ToString(), (decimal)productRow["UnitCost"],
                        productRow["Description"].ToString()));
                }
                categories.Add(new Category(categoryRow["CategoryName"].ToString(), products));
            }
            return categories;
        }

        public ICollection<Category> GetCategories()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("GetCategories", con);
            cmd.CommandType = CommandType.StoredProcedure;

            ObservableCollection<Category> categories = new ObservableCollection<Category>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Create a Category object that wraps the 
                    // current record.
                    Category category = new Category((string)reader["CategoryName"], (int)reader["CategoryID"]);
                    
                    // Add to collection
                    categories.Add(category);
                }
            }
            finally
            {
                con.Close();
            }

            return categories;
        }
	}

}
