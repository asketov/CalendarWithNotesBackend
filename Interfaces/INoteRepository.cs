using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Interfaces
{
    public interface INoteRepository 
    {
        Task<Note> GetNoteAsync(int id);
        Task CreateNoteAsync(Note item);
        void SaveAsync();
    }
}
