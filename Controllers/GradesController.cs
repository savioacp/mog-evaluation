using System;
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
    public class GradesController : ControllerBase
    {
        public GradesController(MogContext _db)
        {
            this._db = _db;

        }
        private MogContext _db { get; set; }

        [HttpGet]
        public ActionResult<StudentClassesGrade[]> Get(int? ofStudent = null, int? ofClass = null)
        {
            var query = _db.Grades
                    .Include(g => g.Student)
                    .Include(g => g.Class)
                    .AsQueryable();

            if (ofStudent != null)
                query = query.Where(grade => grade.Student.Id == ofStudent);

            if (ofClass != null)
                query = query.Where(grade => grade.Class.Id == ofClass);

            return Ok(query.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Classes>> Get(int id)
        {
            var grade = await _db.Grades.FindAsync(id);
            if (grade == null)
                return NotFound();

            return Ok(grade);
        }

        [HttpPost]
        public async Task<ActionResult<StudentClassesGrade>> Post([FromBody] StudentClassesGrade grade)
        {
            _db.Grades.Add(grade);

            await _db.SaveChangesAsync();

            return Ok(grade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentClassesGrade grade)
        {
            if (id != grade.Id) return BadRequest();

            _db.Entry(grade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try { await _db.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (await _db.Grades.FindAsync(id) == null)
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var grade = await _db.Grades.FindAsync(id);

            if (grade == null)
                return NotFound();

            _db.Grades.Remove(grade);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}