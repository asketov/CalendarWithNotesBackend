using Core;

namespace InterfacesServices.ApiModels
{
    public class PostNoteModel
    {
        public string Time { get; set; }
        public string Event { get; set; }
        public int NumberDate { get; set; }

        public static Note DtoToNote(PostNoteModel noteModel) =>
            new Note()
            {
                Time = noteModel.Time,
                Event = noteModel.Event,
                Date = new Date()
                {
                    DateNumber = noteModel.NumberDate
                }
            };
    }
}
