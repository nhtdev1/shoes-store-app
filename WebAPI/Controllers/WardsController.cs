using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class WardsController : ApiController
    {
        private DbCountryEntities db = new DbCountryEntities();

        // GET: api/Wards
        public IQueryable<Ward> GetWards()
        {
            return db.Wards;
        }

        // GET: api/Wards/5
        [ResponseType(typeof(Ward))]
        public IHttpActionResult GetWard(int id)
        {
            Ward ward = db.Wards.Find(id);
            if (ward == null)
            {
                return NotFound();
            }

            return Ok(ward);
        }

        // PUT: api/Wards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWard(int id, Ward ward)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ward.Id)
            {
                return BadRequest();
            }

            db.Entry(ward).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardExists(id))
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

        // POST: api/Wards
        [ResponseType(typeof(Ward))]
        public IHttpActionResult PostWard(Ward ward)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Wards.Add(ward);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WardExists(ward.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ward.Id }, ward);
        }

        // DELETE: api/Wards/5
        [ResponseType(typeof(Ward))]
        public IHttpActionResult DeleteWard(int id)
        {
            Ward ward = db.Wards.Find(id);
            if (ward == null)
            {
                return NotFound();
            }

            db.Wards.Remove(ward);
            db.SaveChanges();

            return Ok(ward);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WardExists(int id)
        {
            return db.Wards.Count(e => e.Id == id) > 0;
        }
    }
}