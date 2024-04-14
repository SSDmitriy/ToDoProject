using Microsoft.AspNetCore.Mvc;

namespace PetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        // ../api/Notes/getall
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllNotes()
        {
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            return Ok($"This all notes: \r\n {id1} \r\n {id2}");
        }

        // ../api/Notes/getnote/{id}
        [HttpGet("getNote/{id:guid}")]
        public async Task<IActionResult> GetNoteById()
        {
            var id = Guid.NewGuid();
            return Ok($"This is your note {id}");
        }

        [HttpPost("createNote")]
        public async Task<IActionResult> CreateNote()
        {
            var id = Guid.NewGuid();
            return Ok($"Your note is created with id = {id}");
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
