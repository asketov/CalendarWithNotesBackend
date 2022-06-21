using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class NoteRepository : INoteRepository
    {
        private NoteContext _db;

        public NoteRepository()
        {
            _db = new NoteContext();
        }

        public async Task<IEnumerable<Note>> GetNotesListAsync()
        {
            return await _db.Notes.ToListAsync();
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _db.Notes.FindAsync(id);
        }

        public async void CreateNoteAsync(Note note)
        {
           await _db.Notes.AddAsync(note);
        }

        public void UpdateNote(Note note)
        {
            _db.Notes.Update(note);
        }

        public async void DeleteNoteAsync(int id)
        {
            Note note = await _db.Notes.FindAsync(id);
            if (note != null)
                _db.Notes.Remove(note);
        }

        public async void SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
