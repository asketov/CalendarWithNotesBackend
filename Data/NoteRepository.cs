using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _db;

        public NoteRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Note> GetNoteAsync(int id)
        {
           return await _db.Notes.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateNoteAsync(Note note)
        {
            await _db.Notes.AddAsync(note);
        }

        public async void SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
