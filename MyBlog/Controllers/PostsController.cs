using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace MyBlog.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public PostsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public IActionResult Get(string keyword = null)
        {
            var posts = new List<Post>();

            string query = "select * from post {0};";
            string where = string.Empty;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                where = "where Title like @Keyword or Tags like @Keyword";
            }
            query = string.Format(query, where);

            //DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        var post = new Post
                        {
                            Id = myReader.GetGuid("Id"),
                            Title = myReader.GetString("Title"),
                            Banner = myReader.GetString("Banner"),
                            Summary = myReader.GetString("Summary"),
                            Content = myReader.GetString("Content"),
                            Tags = myReader.GetString("Tags"),
                            Status = myReader.GetInt32("Status"),
                            IsTop = myReader.IsDBNull("IsTop") ? null : myReader.GetBoolean("IsTop"),
                            SortOrder = myReader.IsDBNull("SortOrder") ? null : myReader.GetInt32("SortOrder"),
                            CreateDate = myReader.IsDBNull("CreateDate") ? null : myReader.GetDateTime("CreateDate"),
                            CreatedBy = myReader.IsDBNull("CreatedBy") ? null : myReader.GetString("CreatedBy"),
                            ModifiedDate = myReader.IsDBNull("ModifiedDate") ? null : myReader.GetDateTime("ModifiedDate"),
                            ModifiedBy = myReader.IsDBNull("ModifiedBy") ? null : myReader.GetString("ModifiedBy")
                        };

                        posts.Add(post);
                    }

                    myReader.Close();
                    myCon.Close();
                }
            }

            return Ok(posts);
        }

        [HttpGet("popular-posts/{limit}")]
        public IActionResult GetPopularPosts(int? limit = null)
        {
            var posts = new List<Post>();

            string query = "select * from post order by ModifiedDate desc {0};";
            string limitString = string.Empty;
            if (limit.HasValue)
            {
                limitString = $"limit {limit.Value}";
            }
            query = string.Format(query, limitString);

            //DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        var post = new Post
                        {
                            Id = myReader.GetGuid("Id"),
                            Title = myReader.GetString("Title"),
                            Banner = myReader.GetString("Banner"),
                            Summary = myReader.GetString("Summary"),
                            Content = myReader.GetString("Content"),
                            Tags = myReader.GetString("Tags"),
                            Status = myReader.GetInt32("Status"),
                            IsTop = myReader.IsDBNull("IsTop") ? null : myReader.GetBoolean("IsTop"),
                            SortOrder = myReader.IsDBNull("SortOrder") ? null : myReader.GetInt32("SortOrder"),
                            CreateDate = myReader.IsDBNull("CreateDate") ? null : myReader.GetDateTime("CreateDate"),
                            CreatedBy = myReader.IsDBNull("CreatedBy") ? null : myReader.GetString("CreatedBy"),
                            ModifiedDate = myReader.IsDBNull("ModifiedDate") ? null : myReader.GetDateTime("ModifiedDate"),
                            ModifiedBy = myReader.IsDBNull("ModifiedBy") ? null : myReader.GetString("ModifiedBy")
                        };

                        posts.Add(post);
                    }

                    myReader.Close();
                    myCon.Close();
                }
            }

            return Ok(posts);
        }

        [HttpGet("related-posts/{id}/{limit}")]
        public IActionResult GetRelatedPosts(Guid id, int? limit = null)
        {
            var posts = new List<Post>();

            string query = "select * from post where Id != @Id {0}";
            string limitString = string.Empty;
            if (limit.HasValue)
            {
                limitString = $"limit {limit.Value}";
            }
            query = string.Format(query, limitString);

            //DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        var post = new Post
                        {
                            Id = myReader.GetGuid("Id"),
                            Title = myReader.GetString("Title"),
                            Banner = myReader.GetString("Banner"),
                            Summary = myReader.GetString("Summary"),
                            Content = myReader.GetString("Content"),
                            Tags = myReader.GetString("Tags"),
                            Status = myReader.GetInt32("Status"),
                            IsTop = myReader.IsDBNull("IsTop") ? null : myReader.GetBoolean("IsTop"),
                            SortOrder = myReader.IsDBNull("SortOrder") ? null : myReader.GetInt32("SortOrder"),
                            CreateDate = myReader.IsDBNull("CreateDate") ? null : myReader.GetDateTime("CreateDate"),
                            CreatedBy = myReader.IsDBNull("CreatedBy") ? null : myReader.GetString("CreatedBy"),
                            ModifiedDate = myReader.IsDBNull("ModifiedDate") ? null : myReader.GetDateTime("ModifiedDate"),
                            ModifiedBy = myReader.IsDBNull("ModifiedBy") ? null : myReader.GetString("ModifiedBy")
                        };

                        posts.Add(post);
                    }

                    myReader.Close();
                    myCon.Close();
                }
            }

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Post post = null;

            string query = "select * from post where Id = @Id limit 1;";

            //DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        post = new Post
                        {
                            Id = myReader.GetGuid("Id"),
                            Title = myReader.GetString("Title"),
                            Banner = myReader.GetString("Banner"),
                            Summary = myReader.GetString("Summary"),
                            Content = myReader.GetString("Content"),
                            Tags = myReader.GetString("Tags"),
                            Status = myReader.GetInt32("Status"),
                            IsTop = myReader.IsDBNull("IsTop") ? null : myReader.GetBoolean("IsTop"),
                            SortOrder = myReader.IsDBNull("SortOrder") ? null : myReader.GetInt32("SortOrder"),
                            CreateDate = myReader.IsDBNull("CreateDate") ? null : myReader.GetDateTime("CreateDate"),
                            CreatedBy = myReader.IsDBNull("CreatedBy") ? null : myReader.GetString("CreatedBy"),
                            ModifiedDate = myReader.IsDBNull("ModifiedDate") ? null : myReader.GetDateTime("ModifiedDate"),
                            ModifiedBy = myReader.IsDBNull("ModifiedBy") ? null : myReader.GetString("ModifiedBy")
                        };
                    }

                    myReader.Close();
                    myCon.Close();
                }
            }

            //return new JsonResult(table);
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post(Post post)
        {
            int result;
            string query = "insert into post (Title, Banner, Summary, Content, Tags, Status, IsTop, SortOrder, CreateDate, CreatedBy, ModifiedDate) values (@Title, @Banner, @Summary, @Content, @Tags, @Status, @IsTop, @SortOrder, @CreateDate, @CreatedBy, @ModifiedDate);";

            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Title", post.Title);
                    myCommand.Parameters.AddWithValue("@Banner", post.Banner);
                    myCommand.Parameters.AddWithValue("@Summary", post.Summary);
                    myCommand.Parameters.AddWithValue("@Content", post.Content);
                    myCommand.Parameters.AddWithValue("@Tags", post.Tags);
                    myCommand.Parameters.AddWithValue("@Status", post.Status);
                    myCommand.Parameters.AddWithValue("@IsTop", post.IsTop);
                    myCommand.Parameters.AddWithValue("@SortOrder", post.SortOrder);
                    myCommand.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@CreatedBy", post.CreatedBy);
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
        public IActionResult Put(Post post)
        {
            int result = 0;
            string query = "update post set Title = @Title, Banner = @Banner, Summary = @Summary, Content = @Content, Tags = @Tags, Status = @Status, IsTop = @IsTop, SortOrder = @SortOrder, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy where Id = @Id;";

            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", post.Id);
                    myCommand.Parameters.AddWithValue("@Title", post.Title);
                    myCommand.Parameters.AddWithValue("@Banner", post.Banner);
                    myCommand.Parameters.AddWithValue("@Summary", post.Summary);
                    myCommand.Parameters.AddWithValue("@Content", post.Content);
                    myCommand.Parameters.AddWithValue("@Tags", post.Tags);
                    myCommand.Parameters.AddWithValue("@Status", post.Status);
                    myCommand.Parameters.AddWithValue("@IsTop", post.IsTop);
                    myCommand.Parameters.AddWithValue("@SortOrder", post.SortOrder);
                    myCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                    myCommand.Parameters.AddWithValue("@ModifiedBy", post.ModifiedBy);
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
        public IActionResult Delete(Guid id)
        {
            int result = 0;
            string query = "delete from post where Id = @Id;";

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

        [Route("images")]
        [HttpPost]
        public IActionResult SaveImages()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var extension = fileName.Split('.').LastOrDefault();
                var newFileName = $"{Guid.NewGuid()}.{extension}";
                var physicalPath = _env.ContentRootPath + "/Images/" + newFileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return Ok(newFileName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("images-full-url")]
        [HttpPost]
        public IActionResult SaveImagesFullUrl()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var extension = fileName.Split('.').LastOrDefault();
                var newFileName = $"{Guid.NewGuid()}.{extension}";
                var physicalPath = _env.ContentRootPath + "/Images/" + newFileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return Ok(new { Url = $"https://localhost:44381/images/{newFileName}" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("file")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length <= 0)
                {
                    return BadRequest("No file uploaded");
                }
                var extension = file.FileName.Split('.').LastOrDefault();
                var fileName = $"{Guid.NewGuid()}.{extension}";
                var physicalPath = Path.Combine(_env.ContentRootPath, "Uploads", fileName);
                if (!Directory.Exists(Path.GetDirectoryName(physicalPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(physicalPath));
                }
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok(fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
