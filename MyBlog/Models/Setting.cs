namespace MyBlog.Models
{
    public class Setting: BaseModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
