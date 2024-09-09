using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Services;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace MyBlog.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, AuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginInfo loginInfo)
        {
            if (string.IsNullOrWhiteSpace(loginInfo.UserName)
                || string.IsNullOrWhiteSpace(loginInfo.Password)
            )
            {
                return BadRequest("Invalid parameters");
            }

            var connectionString = _configuration.GetConnectionString("MyBlog");

            var users = new List<User>();
            using (var cnn = new MySqlConnection(connectionString))
            {
                cnn.Open();
                var sql = "select * from user where UserName = @UserName limit 1;";
                using (var cmd = new MySqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@UserName", loginInfo.UserName);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            Id = reader.GetGuid("Id"),
                            UserName = reader.GetString("UserName"),
                            Password = reader.GetString("Password"),
                            Salt = reader.GetString("Salt"),
                            PhotoFileName = reader.IsDBNull("PhotoFileName") ? null : reader.GetString("PhotoFileName"),
                        };
                        users.Add(user);
                    }
                }
            }

            if (users != null && users.Count > 0 && users[0] != null)
            {
                var hashedPassword = HashPasswordWithSalt(loginInfo.Password, users[0].Salt);
                if (hashedPassword == users[0].Password)
                {
                    var token = _authService.GenerateToken(users[0]);
                    return Ok(new AuthenticatedUser
                    {
                        Id = users[0].Id ?? Guid.Empty,
                        UserName = users[0].UserName,
                        PhotoFileName = users[0].PhotoFileName,
                        AuthToken = token
                    });
                }
                else
                {
                    return BadRequest("Invalid login!");
                }
            }
            else
            {
                return BadRequest("Invalid login!");
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterInfo registerInfo)
        {
            try
            {
                int result;
                if (string.IsNullOrWhiteSpace(registerInfo.UserName)
                || string.IsNullOrWhiteSpace(registerInfo.Password)
                || string.IsNullOrWhiteSpace(registerInfo.RePassword)
                || registerInfo.Password != registerInfo.RePassword
                )
                {
                    return BadRequest("Invalid parameters");
                }

                string salt = GenerateSalt();
                var hashedPassword = HashPasswordWithSalt(registerInfo.Password, salt);
                var connectionString = _configuration.GetConnectionString("MyBlog");
                using (var cnn = new MySqlConnection(connectionString))
                {
                    cnn.Open();
                    var sql = "insert into user(UserName, Password, Salt) values (@UserName, @Password, @Salt);";
                    using (var cmd = new MySqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", registerInfo.UserName);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Salt", salt);

                        result = cmd.ExecuteNonQuery();

                        cnn.Close();
                    }
                }
                if (result > 0)
                {
                    return Ok("Register successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        private string GenerateSalt()
        {
            // Tạo một salt ngẫu nhiên
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            var salt = Convert.ToBase64String(saltBytes);
            return salt;
        }

        private string HashPasswordWithSalt(string password, string salt)
        {
            // Kết hợp salt với mật khẩu
            string saltedPassword = salt + password;

            // Băm mật khẩu đã được thêm salt
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
