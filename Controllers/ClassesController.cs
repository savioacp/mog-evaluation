using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mog.Models;
using mog.Services;

namespace mog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {

        public ClassesController(MogContext _db)
        {
            this._db = _db;

        }
        private MogContext _db { get; set; }

        [HttpGet]
        public ActionResult<Classes[]> Get() =>
            Ok(_db.Classes);

        [HttpGet("{id}")]
        public async Task<ActionResult<Classes>> Get(int id)
        {
            var _class = await _db.Classes.FindAsync(id);
            if (_class == null)
                return NotFound();

            return Ok(_class);
        }

        [HttpPost]
        public async Task<ActionResult<Classes>> Post([FromBody] Classes value)
        {
            _db.Add(value);

            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Classes>> Put(int id, [FromBody] Classes _class)
        {
            if (id != _class.Id) return BadRequest();

            _db.Entry(_class).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try { await _db.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException)
            {
                if (await _db.Classes.FindAsync(id) == null)
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Classes>> Delete(int id)
        {
            var _class = await _db.Classes.FindAsync(id);

            if (_class == null)
                return NotFound();

            _db.Classes.Remove(_class);

            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}