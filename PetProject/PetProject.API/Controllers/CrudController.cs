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

        // ../api/Notes/createNote + body {tittle + description}
        [HttpPost("createNote")]
        public async Task<IActionResult> CreateNote([FromBody] CreateNotePostModel request)
        {
            var id = Guid.NewGuid();

            var note = new Note(id, request.Title, request.Description, Status.ToDo);
            var result = await _notesService.AddNote(note);

            return Ok(result);
        }

        // ../api/Notes/{id} + body
        [HttpPut("updateNote/{id:guid}")]
        public async Task<IActionResult> UpdateNote(Guid id, [FromBody] UpdateNotePutModel request)
        {
            if (request.UpdIntStatus is null) request.UpdIntStatus = -1;
            var updatedNote = new Note(id, request.UpdTitle, request.UpdDescription, (Status)request.UpdIntStatus);
            var entity = await _notesService.UpdateNoteById(updatedNote);

            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return new ContentResult
                {
                    StatusCode = 404,
                    Content = $"Note with id = {id} is not found."
                };
            }
        }

        // ../api/Notes/{id}
        [HttpDelete("deleteNote/{id:guid}")]
        public async Task<IActionResult> DeleteNote([FromRoute] Guid id)
        {
            var success = await _notesService.DeleteNoteById(id);
            if (success)
            {
                return Ok($"Your note {id} is deleted.");
            }
            else
            {
                return NotFound($"Note with {id} is not found.");
            }
        }
    }
}
