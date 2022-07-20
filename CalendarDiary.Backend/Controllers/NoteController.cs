using System.Threading.Tasks;
using Core;
using InterfacesServices;
using Microsoft.AspNetCore.Mvc;

namespace CalendarDiary.Backend.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            return await _noteService.TakeNoteAsync(id);
        }
        [HttpPost]
        public async Task PostNote(Note note)
        {
            await _noteService.AddNoteAsync(note);
        }

    }
}
