namespace MyBlog.Models
{
    public class CommentByUser : BaseModel
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public Guid? ParentId { get; set; }
        public string UserName { get; set; }
        public string PhotoFileName { get; set; }
    }
}
