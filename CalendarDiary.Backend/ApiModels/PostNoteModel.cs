using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarDiary.Backend.ApiModels
{
    public class PostNoteModel
    {
        public string Time { get; set; }
        public string Event { get; set; }
        public int NumberDate { get; set; }
    }
}
