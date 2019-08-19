using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using testWebApi1.EF;

namespace testWebApi1.Controllers
{
    public class LessonsController : ApiController
    {
        private _dbModel db = new _dbModel();

        // GET: api/Lessons
        public IQueryable<Lessons> Getlessons()
        {
            return db.lessons;
        }

        // GET: api/Lessons/5
        [ResponseType(typeof(Lessons))]
        public async Task<IHttpActionResult> GetLessons(int id)
        {
            Lessons lessons = await db.lessons.FindAsync(id);
            if (lessons == null)
            {
                return NotFound();
            }

            return Ok(lessons);
        }

        // PUT: api/Lessons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLessons(int id, Lessons lessons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lessons.id_lesson)
            {
                return BadRequest();
            }

            db.Entry(lessons).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Lessons
        [ResponseType(typeof(Lessons))]
        public async Task<IHttpActionResult> PostLessons(Lessons lessons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.lessons.Add(lessons);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LessonsExists(lessons.id_lesson))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lessons.id_lesson }, lessons);
        }

        // DELETE: api/Lessons/5
        [ResponseType(typeof(Lessons))]
        public async Task<IHttpActionResult> DeleteLessons(int id)
        {
            Lessons lessons = await db.lessons.FindAsync(id);
            if (lessons == null)
            {
                return NotFound();
            }

            db.lessons.Remove(lessons);
            await db.SaveChangesAsync();

            return Ok(lessons);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LessonsExists(int id)
        {
            return db.lessons.Count(e => e.id_lesson == id) > 0;
        }
    }
}