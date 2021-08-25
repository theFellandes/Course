using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace AdoNetDemo
{
    public class ProductDal
    {
        private const string ConnectionString = "User ID=postgres;Password=ProjectMandrake;Server=localhost;Port=5432;Database=ETrade;Integrated Security=true;Pooling=true;";

        private readonly NpgsqlConnection _npgsqlConnection = new NpgsqlConnection(ConnectionString);
        
        private void ConnectionControl()
        {
            if (_npgsqlConnection.State == ConnectionState.Closed)
            {
                _npgsqlConnection.Open();
            }
        }
        //DataTable pahalı bir nesne olduğundan normalde çok kullanılmaz.
        // public DataTable GetAll()
        // {
        //     NpgsqlConnection npgsqlConnection = new NpgsqlConnection(ConnectionString);
        //     if (npgsqlConnection.State == ConnectionState.Closed)
        //     {
        //         npgsqlConnection.Open();
        //     }
        //
        //     NpgsqlCommand npgsqlCommand = new NpgsqlCommand("SELECT * FROM \"Products\"", npgsqlConnection);
        //     NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
        //     DataTable dataTable = new DataTable();
        //     dataTable.Load(reader);
        //     reader.Close();
        //     npgsqlConnection.Close();
        //     return dataTable;
        // }
        public List<Product> GetAll()
        {
            ConnectionControl();
        
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand("SELECT * FROM \"Products\" ORDER BY \"Name\" ASC", _npgsqlConnection);
            NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                var product = new Product
                {
                    Id = new Guid(reader["Id"].ToString() ?? string.Empty),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);
            }

            reader.Close();
            _npgsqlConnection.Close();
            return products;
        }

        public void Add(Product product)
        {
            ConnectionControl();
            string sqlQuery = 
                "INSERT INTO \"Products\" (\"Id\", \"Name\", \"UnitPrice\", \"StockAmount\") VALUES (@Id, @name, @unitPrice, @stockAmount)";
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlQuery, _npgsqlConnection);
            npgsqlCommand.Parameters.AddWithValue("@Id", Guid.NewGuid());
            npgsqlCommand.Parameters.AddWithValue("@name", product.Name);
            npgsqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            npgsqlCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            npgsqlCommand.ExecuteNonQuery();
            
            _npgsqlConnection.Close();
        }
        
        public void Update(Product product)
        {
            ConnectionControl();
            string sqlQuery = 
                "UPDATE \"Products\" SET \"Name\" = @name, \"UnitPrice\" = @unitPrice, \"StockAmount\" = @stockAmount WHERE \"Id\" = @Id";
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlQuery, _npgsqlConnection);
            npgsqlCommand.Parameters.AddWithValue("@Id", product.Id);
            npgsqlCommand.Parameters.AddWithValue("@name", product.Name);
            npgsqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            npgsqlCommand.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            npgsqlCommand.ExecuteNonQuery();
            
            _npgsqlConnection.Close();
        }

        public void Delete(Guid id)
        {
            ConnectionControl();
            string sqlQuery = "DELETE FROM \"Products\" WHERE \"Id\" = @Id";
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sqlQuery, _npgsqlConnection);
            npgsqlCommand.Parameters.AddWithValue("@Id", id);
            npgsqlCommand.ExecuteNonQuery();
            _npgsqlConnection.Close();
        }
    }
}