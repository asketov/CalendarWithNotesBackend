using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public string Time { get; set; }
        public string Event { get; set; }
        public int DateId { get; set; }
        [ForeignKey("DateId")]
        public Date? Date { get; set; }
        public int UserId { get; set; }
     }
}
