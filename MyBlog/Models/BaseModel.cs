﻿namespace MyBlog.Models
{
    public class BaseModel
    {
        public Guid? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
