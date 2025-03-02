namespace Lab5.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;  

    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Post ID is required.")]
        public int PostId { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(50, ErrorMessage = "User name must be less than 50 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(500, ErrorMessage = "Content must be less than 500 characters.")]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DatePosted { get; set; } = DateTime.Now;  
    }
}
