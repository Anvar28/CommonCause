using NLog;
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
    public class CitiesController : ApiController
    {
        private _dbModel db = new _dbModel();

        // GET: api/Cities
        public IQueryable<Cities> Getcities()
        {
            return db.cities;
        }

        // GET: api/Cities/5
        [ResponseType(typeof(Cities))]
        public async Task<IHttpActionResult> GetCities(int id)
        {
            Cities cities = await db.cities.FindAsync(id);
            if (cities == null)
            {
                return NotFound();
            }

            return Ok(cities);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCities(int id, Cities cities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cities.id_city)
            {
                return BadRequest();
            }

            db.Entry(cities).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!CitiesExists(id))
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

        // POST: api/Cities
        [ResponseType(typeof(Cities))]
        public async Task<IHttpActionResult> PostCities(Cities cities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cities.Add(cities);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cities.id_city }, cities);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(Cities))]
        public async Task<IHttpActionResult> DeleteCities(int id)
        {
            Cities cities = await db.cities.FindAsync(id);
            if (cities == null)
            {
                return NotFound();
            }

            db.cities.Remove(cities);
            await db.SaveChangesAsync();

            return Ok(cities);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitiesExists(int id)
        {
            return db.cities.Count(e => e.id_city == id) > 0;
        }
    }
}