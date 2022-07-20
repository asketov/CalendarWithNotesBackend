using System.Threading.Tasks;
using Core;
using Data;
using InterfacesServices;

namespace ImplementationServices
{
    public class NoteService : INoteService
    {
        private readonly NoteRepository _noteRepository;

        public NoteService(ApplicationDbContext db)
        {
            _noteRepository = new NoteRepository(db);
        }
        public async Task AddNoteAsync(Note note)
        {
            await _noteRepository.CreateNoteAsync(note);
        }
        public async Task<Note> TakeNoteAsync(int id)
        {
            return await _noteRepository.GetNoteAsync(id);
        }

    }
}
