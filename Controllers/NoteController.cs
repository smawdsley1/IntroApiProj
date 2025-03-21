using Microsoft.AspNetCore.Mvc;
using moontest1.Data;
using moontest1.Models;

namespace moontest1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController :ControllerBase
    {

        
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Ok("Hello World");
        }

        [HttpPost("PostNote")]
        public IActionResult PostNote(Note note)
        {
            using(NoteContext nc = new NoteContext())
            {
                nc.Note.Add(note);
                nc.SaveChanges();
                return Ok(note.NoteTitle);
            }
            
        }

        [HttpGet("GetNotes")]
        public IActionResult GetNotes()
        {
            using (NoteContext cc = new NoteContext())
            {
                return Ok(cc.Note.ToList());
            }
        }

        [HttpPut("PutNote")]
        public IActionResult PutNote(Note note)
        {
            using(NoteContext nc = new NoteContext())
            {
                nc.Update(note);
                nc.SaveChanges();
                return Ok(note);
            }
        }

        [HttpDelete("DeleteNote/{id}")]
        public IActionResult DeleteNote(int id)
        {
            using (NoteContext nc = new NoteContext())
            {
                try
                {
                    Note note = nc.Note.ElementAt(id);
                    nc.Remove(note);
                    nc.SaveChanges();
                    return Ok(note.NoteTitle + " removed");
                }
                catch
                {
                    return NotFound(id + " not found"); 
                }

            }
        }


        [HttpDelete("TestDelete/{id}")]
        public IActionResult TestDelete(int id)
        {
            using (NoteContext nc = new NoteContext())
            {
                Note note = nc.Note.ElementAt(id);
                nc.Remove(note);
                nc.SaveChanges();
                return Ok(note);
            }
        }

        [HttpPut("TestPut")]
        public IActionResult TestPut(Note note)
        {
            using (NoteContext nc = new NoteContext())
            {
                nc.Update(note);
                nc.SaveChanges();
                return Ok(note);
            }
        }


    }
}
