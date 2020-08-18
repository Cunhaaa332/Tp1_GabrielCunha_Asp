using AmigosDominio;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AmigosDados
{
    public class AmigoRepository
    {
        private string ConnectionString { get; set; }

        public AmigoRepository(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("AmigoConnection");
        }

        public List<AmigoModelo> Listar()
        {

            List<AmigoModelo> result = new List<AmigoModelo>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var sql = @"SELECT Id, Nome, Sobrenome, DataNasc, Email FROM AMIGO";

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    AmigoModelo amigo = new AmigoModelo()
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        Nome = reader["Nome"].ToString(),
                        Sobrenome = reader["Sobrenome"].ToString(),
                        DataNasc = Convert.ToDateTime(reader["DataNasc"]),
                        Email = reader["Email"].ToString()
                    };
                    result.Add(amigo);
                }
                connection.Close();
            }
            return result;
        }

    }
}
