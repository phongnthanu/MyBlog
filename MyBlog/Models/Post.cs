namespace MyBlog.Models
{
    public class Post : BaseModel
    {
        public string Title { get; set; }
        public string Banner { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public int Status { get; set; }
        public bool? IsTop { get; set; }
        public int? SortOrder { get; set; }
    }
}
