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
    public class TopicsController : ApiController
    {
        private _dbModel db = new _dbModel();

        // GET: api/Topics
        public IQueryable<Topics> Gettopics()
        {
            return db.topics;
        }

        // GET: api/Topics/5
        [ResponseType(typeof(Topics))]
        public async Task<IHttpActionResult> GetTopics(int id)
        {
            Topics topics = await db.topics.FindAsync(id);
            if (topics == null)
            {
                return NotFound();
            }

            return Ok(topics);
        }

        // PUT: api/Topics/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTopics(int id, Topics topics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topics.id_topic)
            {
                return BadRequest();
            }

            db.Entry(topics).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!TopicsExists(id))
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

        // POST: api/Topics
        [ResponseType(typeof(Topics))]
        public async Task<IHttpActionResult> PostTopics(Topics topics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.topics.Add(topics);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = topics.id_topic }, topics);
        }

        // DELETE: api/Topics/5
        [ResponseType(typeof(Topics))]
        public async Task<IHttpActionResult> DeleteTopics(int id)
        {
            Topics topics = await db.topics.FindAsync(id);
            if (topics == null)
            {
                return NotFound();
            }

            db.topics.Remove(topics);
            await db.SaveChangesAsync();

            return Ok(topics);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopicsExists(int id)
        {
            return db.topics.Count(e => e.id_topic == id) > 0;
        }
    }
}