using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MyBlog.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MyBlog.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public CommentsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet("comment-by-post/{postId}")]
        public IActionResult GetCommentByPostId(Guid postId)
        {
            var commentByUsers = new List<CommentByUser>();

            string query = "select c.Id, c.PostId, c.Content, c.ParentId, c.CreateDate, c.CreatedBy, c.ModifiedDate, c.ModifiedBy, u.UserName, u.PhotoFileName from comment c inner join user u on c.CreatedBy = u.Id where PostId = @PostId;";

            //DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyBlog");
            MySqlDataReader myReader;
            using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PostId", postId);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        var commentByUser = new CommentByUser
                        {
                            Id = myReader.GetGuid("Id"),
                            PostId = myReader.GetGuid("PostId"),
                            Content = myReader.GetString("Content"),
                            ParentId = myReader.IsDBNull("ParentId") ? null : myReader.GetGuid("ParentId"),
                            UserName = myReader.GetString("UserName"),
                            PhotoFileName = myReader.GetString("PhotoFileName"),
                            CreateDate = myReader.IsDBNull("CreateDate") ? null : myReader.GetDateTime("CreateDate"),
                            CreatedBy = myReader.IsDBNull("CreatedBy") ? null : myReader.GetGuid("CreatedBy").ToString(),
                            ModifiedDate = myReader.IsDBNull("ModifiedDate") ? null : myReader.GetDateTime("ModifiedDate"),
                            ModifiedBy = myReader.IsDBNull("ModifiedBy") ? null : myReader.GetGuid("ModifiedBy").ToString()
                        };

                        commentByUsers.Add(commentByUser);
                    }

                    myReader.Close();
                    myCon.Close();
                }
            }

            return Ok(commentByUsers);
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
                    //table.Load(myReader);

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
        [Authorize]
        public IActionResult Post(Comment comment)
        {
            try
            {
                var commentByUsers = new List<CommentByUser>();

                comment.Id = Guid.NewGuid();

                string query = "insert into comment (Id, PostId, Content, ParentId, CreateDate, CreatedBy, ModifiedDate) values (@Id, @PostId, @Content, @ParentId, @CreateDate, @CreatedBy, @ModifiedDate);";

                string sqlDataSource = _configuration.GetConnectionString("MyBlog");
                using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    int insertResult = 0;
                    using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@Id", comment.Id);
                        myCommand.Parameters.AddWithValue("@PostId", comment.PostId);
                        myCommand.Parameters.AddWithValue("@Content", comment.Content);
                        myCommand.Parameters.AddWithValue("@ParentId", comment.ParentId);
                        myCommand.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                        myCommand.Parameters.AddWithValue("@CreatedBy", comment.CreatedBy);
                        myCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                        insertResult = myCommand.ExecuteNonQuery();
                    }
                    if (insertResult > 0)
                    {
                        string querySelect = "select c.Id, c.PostId, c.Content, c.ParentId, c.CreateDate, c.CreatedBy, c.ModifiedDate, c.ModifiedBy, u.UserName, u.PhotoFileName from comment c inner join user u on c.CreatedBy = u.Id where c.Id = @Id;";
                        using (MySqlCommand myCommand = new MySqlCommand(querySelect, myCon))
                        {
                            myCommand.Parameters.AddWithValue("@Id", comment.Id);
                            var myReader = myCommand.ExecuteReader();

                            while (myReader.Read())
                            {
                                var commentByUser = new CommentByUser
                                {
                                    Id = myReader.GetGuid("Id"),
                                    PostId = myReader.GetGuid("PostId"),
                                    Content = myReader.GetString("Content"),
                                    ParentId = myReader.IsDBNull("ParentId") ? null : myReader.GetGuid("ParentId"),
                                    UserName = myReader.GetString("UserName"),
                                    PhotoFileName = myReader.GetString("PhotoFileName"),
                                    CreateDate = myReader.IsDBNull("CreateDate") ? null : myReader.GetDateTime("CreateDate"),
                                    CreatedBy = myReader.IsDBNull("CreatedBy") ? null : myReader.GetGuid("CreatedBy").ToString(),
                                    ModifiedDate = myReader.IsDBNull("ModifiedDate") ? null : myReader.GetDateTime("ModifiedDate"),
                                    ModifiedBy = myReader.IsDBNull("ModifiedBy") ? null : myReader.GetGuid("ModifiedBy").ToString()
                                };

                                commentByUsers.Add(commentByUser);
                            }

                            myReader.Close();
                            myCon.Close();
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }

                return Ok(commentByUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
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
    }
}
