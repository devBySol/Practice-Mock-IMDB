namespace Lab5.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(20, ErrorMessage = "User name must be less than 20 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(500, ErrorMessage = "Content must be less than 500 characters.")]
        public string Content { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;
    }

}
