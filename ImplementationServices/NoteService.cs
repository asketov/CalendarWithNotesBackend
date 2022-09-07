using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Data;
using InterfacesDomain;
using InterfacesServices;
using InterfacesServices.ApiModels;

namespace ImplementationServices
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IDateRepository _dateRepository;

        public NoteService(ApplicationDbContext db)
        {
            _noteRepository = new NoteRepository(db);
            _dateRepository = new DateRepository(db);
        }
        public async Task<int> AddNoteAsync(PostNoteModel noteModel)
        {
            Note note = PostNoteModel.DtoToNote(noteModel);
            var date = await _dateRepository.GetDateAsync(note.Date.DateNumber);
            if (date != null)
            {
                note.DateId = date.DateId;
                note.Date = null;
            }
            await _noteRepository.CreateNoteAsync(note);
            await _noteRepository.SaveAsync();
            return note.NoteId;
        }
        public async Task<Note> TakeNoteAsync(int id)
        {
            return await _noteRepository.GetNoteAsync(id);
        }
        public async Task<List<Note>> TakeNotesAsync(int dateNumber)
        {
            return await _noteRepository.GetNotesAsync(dateNumber);
        }

        public async Task<bool> DeleteNoteAsync(int id)
        {
            var success = await _noteRepository.DeleteNoteAsync(id);
            await _noteRepository.SaveAsync();
            return success;
        }

    }
}
