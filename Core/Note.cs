using System;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Message { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
