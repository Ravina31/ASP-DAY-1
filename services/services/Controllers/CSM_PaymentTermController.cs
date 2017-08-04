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
using services.Models;

namespace services.Controllers
{
    public class CSM_PaymentTermController : ApiController
    {
        private DEV_SetupManagerEntities db = new DEV_SetupManagerEntities();

        // GET: api/CSM_PaymentTerm
        public IQueryable<CSM_PaymentTerm> GetCSM_PaymentTerm()
        {
            return db.CSM_PaymentTerm1;
        }

        // GET: api/CSM_PaymentTerm/5
        [ResponseType(typeof(CSM_PaymentTerm))]
        public async Task<IHttpActionResult> GetCSM_PaymentTerm(int id)
        {
            CSM_PaymentTerm cSM_PaymentTerm = await db.CSM_PaymentTerm1.FindAsync(id);
            if (cSM_PaymentTerm == null)
            {
                return NotFound();
            }

            return Ok(cSM_PaymentTerm);
        }

        //Update


        // PUT: api/CSM_PaymentTerm/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCSM_PaymentTerm(int id, CSM_PaymentTerm cSM_PaymentTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cSM_PaymentTerm.PaymentTermId)
            {
                return BadRequest();
            }

            db.Entry(cSM_PaymentTerm).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CSM_PaymentTermExists(id))
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

        // POST: api/CSM_PaymentTerm
        [ResponseType(typeof(CSM_PaymentTerm))]
        public async Task<IHttpActionResult> PostCSM_PaymentTerm(CSM_PaymentTerm cSM_PaymentTerm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CSM_PaymentTerm1.Add(cSM_PaymentTerm);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CSM_PaymentTermExists(cSM_PaymentTerm.PaymentTermId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cSM_PaymentTerm.PaymentTermId }, cSM_PaymentTerm);
        }

        // DELETE: api/CSM_PaymentTerm/5
        [ResponseType(typeof(CSM_PaymentTerm))]
        public async Task<IHttpActionResult> DeleteCSM_PaymentTerm(int id)
        {
            CSM_PaymentTerm cSM_PaymentTerm = await db.CSM_PaymentTerm1.FindAsync(id);
            if (cSM_PaymentTerm == null)
            {
                return NotFound();
            }

            db.CSM_PaymentTerm1.Remove(cSM_PaymentTerm);
            await db.SaveChangesAsync();

            return Ok(cSM_PaymentTerm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CSM_PaymentTermExists(int id)
        {
            return db.CSM_PaymentTerm1.Count(e => e.PaymentTermId == id) > 0;
        }
    }
}