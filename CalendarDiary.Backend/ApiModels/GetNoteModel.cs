using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace CalendarDiary.Backend.ApiModels
{
    public class GetNoteModel
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Event { get; set; }

        public static GetNoteModel NoteToDTO(Note note) =>
            new GetNoteModel()
            {
                Id = note.NoteId,
                Time = note.Time,
                Event = note.Event,
            };
    }

}
