using PetProject.Domain;
using PetProject.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Application
{
    public class NotesService
    {
        private readonly NotesRepository _notesRepository;

        public NotesService(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task AddNote(Note note)
        {
            await _notesRepository.AddNote(note);
        }

        public  async Task<List<Note>> GetAllNotes()
        {
            return await _notesRepository.GetAllNotes();
        }

        public async Task<Note> GetNoteById(Guid id)
        {
            return await _notesRepository.GetNoteById(id);
        }
    }
}
