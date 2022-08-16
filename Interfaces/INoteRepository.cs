using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace InterfacesDomain
{
    public interface INoteRepository 
    {
        Task<Note> GetNoteAsync(int id);
        Task<List<Note>> GetNotesAsync(int dateNumber);
        Task CreateNoteAsync(Note item);
        Task<bool> DeleteNoteAsync(int id);
        Task SaveAsync();
    }
}
