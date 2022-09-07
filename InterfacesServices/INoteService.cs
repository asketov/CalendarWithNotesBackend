using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using InterfacesServices.ApiModels;

namespace InterfacesServices
{
    public interface INoteService
    {
        Task<int> AddNoteAsync(PostNoteModel noteModel);
        Task<Note> TakeNoteAsync(int id);
        Task<List<Note>> TakeNotesAsync(int dateNumber);
        Task<bool> DeleteNoteAsync(int id);
    }
}
