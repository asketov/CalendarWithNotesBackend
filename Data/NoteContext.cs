using Core;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class NoteContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
    }
}
