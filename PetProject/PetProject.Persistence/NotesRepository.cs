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
        public async Task<Note> AddNote(Note note)
        {
            string newTitle = "Default Title";
            if (note.Title != null) newTitle = note.Title;

            string newDescription = null;
            if (note.Description != null) newDescription = note.Description;
            
            var newEntity = new Note(note.Id, newTitle, newDescription, Status.ToDo);

            await _notesDbContext.Notes.AddAsync(newEntity);

            await _notesDbContext.SaveChangesAsync();

            var createdEntity = await _notesDbContext.Notes.FirstOrDefaultAsync(n => n.Id == note.Id);

            return createdEntity;
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
        public async Task<Note> UpdateNoteById(Note updatedNote)
        {
            var entity = await _notesDbContext.Notes.FirstOrDefaultAsync(n => n.Id == updatedNote.Id);

            if (entity == null) return null;

            if (updatedNote.Title is not null) entity.Title = updatedNote.Title;
            if (updatedNote.Description is not null) entity.Description = updatedNote.Description;
            if (updatedNote.Status != Status.WithoutUpdate) entity.Status = updatedNote.Status;

            await _notesDbContext.SaveChangesAsync();

            var savedEntity = await _notesDbContext.Notes.FirstOrDefaultAsync(n => n.Id == updatedNote.Id);

            return savedEntity;
        }

        //delete by id
    }
}
