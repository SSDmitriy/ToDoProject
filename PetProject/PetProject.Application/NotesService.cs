using PetProject.Domain;
using PetProject.Persistence;

namespace PetProject.Application
{
    public class NotesService
    {
        private readonly NotesRepository _notesRepository;

        public NotesService(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task<Note> AddNote(Note note)
        {
            return await _notesRepository.AddNote(note);
        }

        public async Task<List<Note>> GetAllNotes()
        {
            return await _notesRepository.GetAllNotes();
        }

        public async Task<Note> GetNoteById(Guid id)
        {
            return await _notesRepository.GetNoteById(id);
        }

        public async Task<Note> UpdateNoteById(Note updatedNote)
        {
            return await _notesRepository.UpdateNoteById(updatedNote);
        }

        public async Task<bool> DeleteNoteById(Guid id)
        {
            return await _notesRepository.DeleteNoteById(id);
        }
    }
}
