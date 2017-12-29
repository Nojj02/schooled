using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using Schooled.Model;

namespace Schooled.DataAccess
{
    public class RegistrationRepository
    {
        private const string ConnectionString =
            "Host=localhost;Username=postgres;Password=thepassword;Database=postgres;Search Path=schooled";

        public async Task Save(Registration entity)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        var command = "INSERT INTO schooled.Registration (id, content, timestamp) VALUES (@id, @content, @timestamp)";
                        using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("id", NpgsqlDbType.Uuid, entity.Id);
                            sqlCommand.Parameters.AddWithValue("content", NpgsqlDbType.Jsonb,
                                JsonConvert.SerializeObject(entity));
                            sqlCommand.Parameters.AddWithValue("timestamp", NpgsqlDbType.TimestampTZ, DateTime.UtcNow);
                            sqlCommand.ExecuteNonQuery();
                        }
                        await transaction.CommitAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
        }

        public IEnumerable<Registration> GetAll()
        {
            var entities = new List<Registration>();
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var command = "SELECT * FROM schooled.Registration";
                using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                {
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entity = JsonConvert.DeserializeObject<Registration>(Convert.ToString(reader["content"]));
                            entities.Add(entity);
                        }
                    }
                }
            }
            
            return entities;
        }

        public Registration Get(string id)
        {
            var entities = new List<Registration>();
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var command = "SELECT TOP 1 * FROM schooled.Registration";
                using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                {
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var entity = JsonConvert.DeserializeObject<Registration>(Convert.ToString(reader["content"]));
                            return entity;
                        }
                    }
                }
            }
            
            return null;
        }
    }
}