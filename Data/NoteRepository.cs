using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using InterfacesDomain;
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
           return await _db.Notes.FirstOrDefaultAsync(u => u.NoteId == id);
        }

        public async Task<List<Note>> GetNotesAsync(int dateNumber, int userId)
        {
            return await _db.Notes.Where(note => note.Date.DateNumber == dateNumber && note.UserId == userId).ToListAsync();
        }

        public async Task CreateNoteAsync(Note note)
        {
            await _db.Notes.AddAsync(note);
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var note = await _db.Notes.FirstOrDefaultAsync(note => note.NoteId == id);
            if (note != null)
            {
                _db.Notes.Remove(note);
                return true;
            }
            return false;
        }

        public async Task SaveAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
