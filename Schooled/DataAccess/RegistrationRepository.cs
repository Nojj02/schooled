using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using Schooled.Model;
using Schooled.Model.Events;

namespace Schooled.DataAccess
{
    public class RegistrationRepository
    {
        private const string ConnectionString =
            "Host=localhost;Username=postgres;Password=thepassword;Database=postgres;Search Path=schooled";

        public async Task Save(Registration entity, DateTimeOffset timeStamp)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        foreach (var entityEvent in entity.Events)
                        {
                            var command = "INSERT INTO schooled.Registration (id, version, event_type, event, timestamp) VALUES (@id, @version, @event_type, @event, @timestamp)";
                            using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("id", NpgsqlDbType.Uuid, 
                                    entity.Id);
                                sqlCommand.Parameters.AddWithValue("version", NpgsqlDbType.Integer,
                                    entityEvent.Version);
                                sqlCommand.Parameters.AddWithValue("event_type", NpgsqlDbType.Varchar,
                                    entityEvent.GetType());
                                sqlCommand.Parameters.AddWithValue("event", NpgsqlDbType.Jsonb,
                                    JsonConvert.SerializeObject(entityEvent));
                                sqlCommand.Parameters.AddWithValue("timestamp", NpgsqlDbType.TimestampTZ, 
                                    timeStamp);
                                sqlCommand.ExecuteNonQuery();
                            }
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
                            throw new NotImplementedException();
                        }
                    }
                }
            }
            
            return entities;
        }

        public Registration Get(Guid id)
        {
            var registrationEvents = new List<IRegistrationEvent>();
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                var command = "SELECT * FROM schooled.Registration WHERE id = @id ORDER BY timestamp";
                using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("id", NpgsqlDbType.Uuid, id);
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var eventType = Convert.ToString(reader["event_type"]);
                            var theEvent = 
                                (IRegistrationEvent)JsonConvert.DeserializeObject(
                                    Convert.ToString(reader["event"]), 
                                    RegistrationEvents.EventTypeLookup.Single(x=> x.Value == eventType).Key);
                            
                            registrationEvents.Add(theEvent);
                        }
                    }
                }
            }
            
            return registrationEvents.Any() ? new Registration(id, registrationEvents) : null;
        }

        public async Task Update(Registration entity, DateTimeOffset timeStamp)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        foreach (var entityEvent in entity.NewEvents)
                        {
                            var command = "INSERT INTO schooled.Registration (id, version, event_type, event, timestamp) VALUES (@id, @version, @event_type, @event, @timestamp)";
                            using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("id", NpgsqlDbType.Uuid, 
                                    entity.Id);
                                sqlCommand.Parameters.AddWithValue("version", NpgsqlDbType.Integer,
                                    entityEvent.Version);
                                sqlCommand.Parameters.AddWithValue("event_type", NpgsqlDbType.Varchar,
                                    entityEvent.GetType());
                                sqlCommand.Parameters.AddWithValue("event", NpgsqlDbType.Jsonb,
                                    JsonConvert.SerializeObject(entityEvent));
                                sqlCommand.Parameters.AddWithValue("timestamp", NpgsqlDbType.TimestampTZ, 
                                    timeStamp);
                                sqlCommand.ExecuteNonQuery();
                            }
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
    }
}