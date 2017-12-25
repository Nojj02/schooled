using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;

namespace Schooled.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private const string ConnectionString = "Host=localhost;Username=postgres;Password=thepassword;Database=postgres;Search Path=schooled";

        // GET api/values
        [HttpGet]
        public IEnumerable<CourseModel> Get()
        {
            return new List<CourseModel>
            {
                new CourseModel
                {
                    Code = "MATH 11"
                }
            };
        }

//        // GET api/values/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

        // POST api/values
        [HttpPost]
        public async Task Post(CoursePostModel model)
        {
            using (var sqlConnection = new NpgsqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var entity = new Course(name: model.Name, code: model.Code);

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        var command = "INSERT INTO schooled.course (id, content, timestamp) VALUES (@id, @content, @timestamp)";
                        using (var sqlCommand = new Npgsql.NpgsqlCommand(command, sqlConnection))
                        {                
                            sqlCommand.Parameters.AddWithValue("id", NpgsqlDbType.Uuid, Guid.NewGuid());
                            sqlCommand.Parameters.AddWithValue("content", NpgsqlDbType.Jsonb, JsonConvert.SerializeObject(entity));
                            sqlCommand.Parameters.AddWithValue("timestamp", NpgsqlDbType.TimestampTZ, DateTime.UtcNow);
                            sqlCommand.ExecuteNonQuery();
                        }
                        await transaction.CommitAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        await transaction.RollbackAsync();
                    }
                }
            }
        }
//
//        // PUT api/values/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }
//
//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
    }

    public class CourseModel
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class CoursePostModel
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}