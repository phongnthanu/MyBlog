namespace MyBlog.Models
{
    public class AuthenticatedUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PhotoFileName { get; set; }
        public string AuthToken { get; set; }
    }
}
