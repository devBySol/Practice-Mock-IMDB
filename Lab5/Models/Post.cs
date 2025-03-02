namespace Lab5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  

    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(50, ErrorMessage = "User name must be less than 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title must be less than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(1000, ErrorMessage = "Content must be less than 1000 characters.")]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DatePosted { get; set; } = DateTime.Now; 

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
