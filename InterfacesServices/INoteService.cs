using System.Threading.Tasks;
using Core;

namespace InterfacesServices
{
    public interface INoteService
    {
        Task AddNoteAsync(Note note);
        Task<Note> TakeNoteAsync(int id);
    }
}
