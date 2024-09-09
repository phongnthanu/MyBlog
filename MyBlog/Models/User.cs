namespace MyBlog.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string PhotoFileName { get; set; }
    }
}
