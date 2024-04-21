using Microsoft.AspNetCore.Mvc;
using PetProject.API;
using PetProject.Application;
using PetProject.Domain;

namespace PetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        //
        private readonly NotesService _notesService;
        public NotesController(NotesService notesService)
        {
            _notesService = notesService;
        }

        // ../api/Notes/getall
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllNotes()
        {
            var allNotes = await _notesService.GetAllNotes();

            return Ok(allNotes);
        }

        // ../api/Notes/getnote/{id}
        [HttpGet("getNote/{id:guid}")]
        public async Task<IActionResult> GetNoteById([FromRoute] Guid id)
        {
            var note = await _notesService.GetNoteById(id);
            return Ok(note);
        }

        [HttpPost("createNote")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNotePostModel request)
        {
            var id = Guid.NewGuid();

            var note = new Note(id, request.Title, request.Description, Status.ToDo);
            await _notesService.AddNote(note);

            return Ok($"Your new note has CREATED with {id} + {request.Title} +  {request.Description} + {note.Status}");
        }

        [HttpPut("updateNote/{id:guid}")]
        public async Task<IActionResult> UpdateNote()
        {
            return Ok("Your note is UPDATED");
        }

        [HttpDelete("deleteNote/{id:guid}")]
        public async Task<IActionResult> DeleteNote()
        {
            return Ok("Your note is deleted");
        }
    }
}
