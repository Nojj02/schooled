using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using Schooled.Models;

namespace Schooled.DataAccess
{
    public class CourseRepository
    {
        private const string ConnectionString =
            "Host=localhost;Username=postgres;Password=thepassword;Database=postgres;Search Path=schooled";

        public async Task Save(Course entity)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        var command =
                            "INSERT INTO schooled.course (id, content, timestamp) VALUES (@id, @content, @timestamp)";
                        using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("id", NpgsqlDbType.Uuid, Guid.NewGuid());
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

        public IEnumerable<Course> GetAll()
        {
            var entities = new List<Course>();
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var command =
                    "SELECT * FROM schooled.course";
                using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                {
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var entity = JsonConvert.DeserializeObject<Course>(Convert.ToString(reader["content"]));
                            entities.Add(entity);
                        }
                    }
                }
            }
            return entities;
        }

        public string Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}