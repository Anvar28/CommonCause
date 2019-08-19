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
    public class TeachersController : ApiController
    {
        private _dbModel db = new _dbModel();

        // GET: api/Teachers
        public IQueryable<Teachers> Getteachers()
        {
            return db.teachers;
        }

        // GET: api/Teachers/5
        [ResponseType(typeof(Teachers))]
        public async Task<IHttpActionResult> GetTeachers(int id)
        {
            Teachers teachers = await db.teachers.FindAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }

            return Ok(teachers);
        }

        // PUT: api/Teachers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeachers(int id, Teachers teachers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teachers.id_teacher)
            {
                return BadRequest();
            }

            db.Entry(teachers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeachersExists(id))
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

        // POST: api/Teachers
        [ResponseType(typeof(Teachers))]
        public async Task<IHttpActionResult> PostTeachers(Teachers teachers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.teachers.Add(teachers);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = teachers.id_teacher }, teachers);
        }

        // DELETE: api/Teachers/5
        [ResponseType(typeof(Teachers))]
        public async Task<IHttpActionResult> DeleteTeachers(int id)
        {
            Teachers teachers = await db.teachers.FindAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }

            db.teachers.Remove(teachers);
            await db.SaveChangesAsync();

            return Ok(teachers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeachersExists(int id)
        {
            return db.teachers.Count(e => e.id_teacher == id) > 0;
        }
    }
}