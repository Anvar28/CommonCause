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
    public class EstablishmentsController : ApiController
    {
        private _dbModel db = new _dbModel();

        // GET: api/Establishments
        public IQueryable<Establishments> Getestablishments()
        {
            return db.establishments;
        }

        // GET: api/Establishments/5
        [ResponseType(typeof(Establishments))]
        public async Task<IHttpActionResult> GetEstablishments(int id)
        {
            Establishments establishments = await db.establishments.FindAsync(id);
            if (establishments == null)
            {
                return NotFound();
            }

            return Ok(establishments);
        }

        // PUT: api/Establishments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstablishments(int id, Establishments establishments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != establishments.id_establishment)
            {
                return BadRequest();
            }

            db.Entry(establishments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstablishmentsExists(id))
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

        // POST: api/Establishments
        [ResponseType(typeof(Establishments))]
        public async Task<IHttpActionResult> PostEstablishments(Establishments establishments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.establishments.Add(establishments);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = establishments.id_establishment }, establishments);
        }

        // DELETE: api/Establishments/5
        [ResponseType(typeof(Establishments))]
        public async Task<IHttpActionResult> DeleteEstablishments(int id)
        {
            Establishments establishments = await db.establishments.FindAsync(id);
            if (establishments == null)
            {
                return NotFound();
            }

            db.establishments.Remove(establishments);
            await db.SaveChangesAsync();

            return Ok(establishments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstablishmentsExists(int id)
        {
            return db.establishments.Count(e => e.id_establishment == id) > 0;
        }
    }
}