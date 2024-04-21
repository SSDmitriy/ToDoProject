using Microsoft.EntityFrameworkCore;
using PetProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PetProject.Persistence
{
    public class NotesRepository
    {
        private readonly NotesDbContext _notesDbContext;
        
        public NotesRepository(NotesDbContext notesDbContext)
        {
            _notesDbContext = notesDbContext;
        }

        //add Note
        public async Task AddNote(Note note)
        {
            //var noteEntity = new Note
            //{
            //    Id = note.Id,
            //    Title = note.Title,
            //    Description = note.Description,
            //    Status = note.Status
            //};

            await _notesDbContext.Notes.AddAsync(note);

            await _notesDbContext.SaveChangesAsync();
        }

        //get all notes
        public async Task<List<Note>> GetAllNotes()
        {
            var notes = await _notesDbContext.Notes.ToListAsync();
            return notes;
        }

        //get by id
        public async Task<Note> GetNoteById(Guid id)
        {
            var note = await _notesDbContext.Notes.FirstOrDefaultAsync(n => n.Id == id);
            return note;
        }


        //update by id


        //delete by id
    }
}
