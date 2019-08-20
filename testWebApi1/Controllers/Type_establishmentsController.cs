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
    public class Type_establishmentsController : ApiController
    {
        private _dbModel db = new _dbModel();

        // GET: api/Type_establishments
        public IQueryable<Type_establishments> Gettype_establishments()
        {
            return db.type_establishments;
        }

        // GET: api/Type_establishments/5
        [ResponseType(typeof(Type_establishments))]
        public async Task<IHttpActionResult> GetType_establishments(int id)
        {
			Type_establishments type_establishments = await db.type_establishments.FindAsync(id);
            if (type_establishments == null)
            {
                return NotFound();
            }

            return Ok(type_establishments);
        }

        // PUT: api/Type_establishments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutType_establishments(int id, Type_establishments type_establishments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != type_establishments.id_type_establishment)
            {
                return BadRequest();
            }

            db.Entry(type_establishments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!Type_establishmentsExists(id))
                {
                    return NotFound();
                }
                else
                {
					WebApiApplication.logger.Warn(e.ToString());
				}
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Type_establishments
        [ResponseType(typeof(Type_establishments))]
        public async Task<IHttpActionResult> PostType_establishments(Type_establishments type_establishments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.type_establishments.Add(type_establishments);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = type_establishments.id_type_establishment }, type_establishments);
        }

        // DELETE: api/Type_establishments/5
        [ResponseType(typeof(Type_establishments))]
        public async Task<IHttpActionResult> DeleteType_establishments(int id)
        {
            Type_establishments type_establishments = await db.type_establishments.FindAsync(id);
            if (type_establishments == null)
            {
                return NotFound();
            }

            db.type_establishments.Remove(type_establishments);
            await db.SaveChangesAsync();

            return Ok(type_establishments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Type_establishmentsExists(int id)
        {
            return db.type_establishments.Count(e => e.id_type_establishment == id) > 0;
        }
    }
}