using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalendarDiary.Backend.Attributes;
using Core;
using InterfacesServices;
using InterfacesServices.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace CalendarDiary.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("GetNote/{id}")]
        public async Task<ActionResult<GetNoteModel>> GetNote(int id)
        {
            var note = await _noteService.TakeNoteAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return GetNoteModel.NoteToDto(note);
        }
        [HttpGet("GetNotes/{dateNumber}")]
        public async Task<ActionResult<IEnumerable<GetNoteModel>>> GetNotes(int dateNumber)
        {
            var user = (User)HttpContext.Items["User"];
            var notes = await _noteService.TakeNotesAsync(dateNumber, user.Id);
            return notes.Select(note => GetNoteModel.NoteToDto(note)).ToList();
        }
        [HttpPost("PostNote")]
        public async Task<ActionResult<int>> PostNote(PostNoteModel noteModel)
        {
            if (noteModel == null)
            {
                return BadRequest();
            }
            var user = (User)HttpContext.Items["User"];
            int id = await _noteService.AddNoteAsync(noteModel, user.Id);
            return CreatedAtAction(nameof(GetNote), new {id = id}, id);
        }
        [HttpDelete("DeleteNote/{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var success = await _noteService.DeleteNoteAsync(id);
            return success ? Ok() : NotFound();
        }
        
    }
}
