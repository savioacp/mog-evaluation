using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mog.Models;
using mog.Services;

namespace mog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public StudentController(MogContext _db)
        {
            this._db = _db;

        }
        private MogContext _db { get; set; }



        [HttpGet]
        public ActionResult<Student[]> Get()
        {
            return Ok(_db.Students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Update(int id, Student student)
        {
            if (id != student.Id) return BadRequest();

            _db.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try { await _db.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (await _db.Students.FindAsync(id) == null)
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            _db.Students.Add(student);

            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var student = await _db.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            _db.Students.Remove(student);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}