using Core;

namespace InterfacesServices.ApiModels
{
    public class GetNoteModel
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Event { get; set; }

        public static GetNoteModel NoteToDto(Note note) =>
            new GetNoteModel()
            {
                Id = note.NoteId,
                Time = note.Time,
                Event = note.Event,
            };
    }

}
