namespace MyBlog.Models
{
    public class Comment: BaseModel
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public Guid? ParentId { get; set; }
    }
}
