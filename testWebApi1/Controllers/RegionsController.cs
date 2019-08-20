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
    public class RegionsController : ApiController
    {
        private _dbModel db = new _dbModel();

        // GET: api/Regions
        public IQueryable<Regions> Getregions()
        {
            return db.regions;
        }

        // GET: api/Regions/5
        [ResponseType(typeof(Regions))]
        public async Task<IHttpActionResult> GetRegions(int id)
        {
            Regions regions = await db.regions.FindAsync(id);
            if (regions == null)
            {
                return NotFound();
            }

            return Ok(regions);
        }

        // PUT: api/Regions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegions(int id, Regions regions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != regions.id_region)
            {
                return BadRequest();
            }

            db.Entry(regions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!RegionsExists(id))
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

        // POST: api/Regions
        [ResponseType(typeof(Regions))]
        public async Task<IHttpActionResult> PostRegions(Regions regions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.regions.Add(regions);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = regions.id_region }, regions);
        }

        // DELETE: api/Regions/5
        [ResponseType(typeof(Regions))]
        public async Task<IHttpActionResult> DeleteRegions(int id)
        {
            Regions regions = await db.regions.FindAsync(id);
            if (regions == null)
            {
                return NotFound();
            }

            db.regions.Remove(regions);
            await db.SaveChangesAsync();

            return Ok(regions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegionsExists(int id)
        {
            return db.regions.Count(e => e.id_region == id) > 0;
        }
    }
}