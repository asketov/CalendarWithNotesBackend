using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace InterfacesServices
{
    public interface INoteService
    {
        Task<int> AddNoteAsync(Note note);
        Task<Note> TakeNoteAsync(int id);
        Task<List<Note>> TakeNotesAsync(int dateNumber);
        Task<bool> DeleteNoteAsync(int id);
    }
}
