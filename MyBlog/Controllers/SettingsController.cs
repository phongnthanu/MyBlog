using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MyBlog.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public SettingsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            Setting setting = null;

            string query = "select * from setting where Name = @Name limit 1;";

            //DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Name", name);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        setting = new Setting
                        {
                            Id = myReader.GetGuid("Id"),
                            Name = myReader.GetString("Name"),
                            Value = myReader.GetString("Value"),
                            Description = myReader.GetString("Description"),
                            CreateDate = myReader.IsDBNull("CreateDate") ? null : myReader.GetDateTime("CreateDate"),
                            CreatedBy = myReader.IsDBNull("CreatedBy") ? null : myReader.GetGuid("CreatedBy").ToString(),
                            ModifiedDate = myReader.IsDBNull("ModifiedDate") ? null : myReader.GetDateTime("ModifiedDate"),
                            ModifiedBy = myReader.IsDBNull("ModifiedBy") ? null : myReader.GetGuid("ModifiedBy").ToString()
                        };
                    }

                    myReader.Close();
                    myCon.Close();
                }
            }

            return Ok(setting);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(Setting setting)
        {
            int result;
            string query = "insert into setting (Name, Value, Description, CreateDate, CreatedBy, ModifiedDate) values (@Name, @Value, @Description, @CreateDate, @CreatedBy, @ModifiedDate);";

            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Name", setting.Name);
                    myCommand.Parameters.AddWithValue("@Value", setting.Value);
                    myCommand.Parameters.AddWithValue("@Description", setting.Description);
                    myCommand.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@CreatedBy", setting.CreatedBy);
                    myCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                    result = myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }

            if (result > 0)
            {
                return Ok("Added successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Put(Setting setting)
        {
            int result = 0;
            string query = "update setting set Name = @Name, Value = @Value, Description = @Description, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy where Id = @Id;";

            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", setting.Id);
                    myCommand.Parameters.AddWithValue("@Name", setting.Name);
                    myCommand.Parameters.AddWithValue("@Value", setting.Value);
                    myCommand.Parameters.AddWithValue("@Description", setting.Description);
                    myCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@ModifiedBy", setting.ModifiedBy);
                    result = myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }

            if (result > 0)
            {
                return Ok("Updated successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            int result = 0;
            string query = "delete from setting where Id = @Id;";

            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);
                    result = myCommand.ExecuteNonQuery();
                    myCon.Close();
                }
            }

            if (result > 0)
            {
                return Ok("Deleted successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
