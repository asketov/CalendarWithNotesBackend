using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Interfaces
{
    public interface INoteRepository 
    {
        Task<IEnumerable<Note>> GetNotesListAsync();
        Task<Note> GetNoteAsync(int id);
        void CreateNoteAsync(Note item);
        void UpdateNote(Note item);
        void DeleteNoteAsync(int id);
        void SaveAsync();
    }
}
