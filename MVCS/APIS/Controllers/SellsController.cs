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
using APIS.Models;

namespace APIS.Controllers
{
    public class SellsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Sells
        public IQueryable<Sell> GetSells()
        {
            return db.Sells;
        }

        // GET: api/Sells/5
        [ResponseType(typeof(Sell))]
        public IHttpActionResult GetSell(int id)
        {
            Sell sell = db.Sells.Find(id);
            if (sell == null)
            {
                return NotFound();
            }

            return Ok(sell);
        }

        // PUT: api/Sells/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSell(int id, Sell sell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sell.SellId)
            {
                return BadRequest();
            }

            db.Entry(sell).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellExists(id))
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

        // POST: api/Sells
        [ResponseType(typeof(Sell))]
        public IHttpActionResult PostSell(Sell sell)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sells.Add(sell);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sell.SellId }, sell);
        }

        // DELETE: api/Sells/5
        [ResponseType(typeof(Sell))]
        public IHttpActionResult DeleteSell(int id)
        {
            Sell sell = db.Sells.Find(id);
            if (sell == null)
            {
                return NotFound();
            }

            db.Sells.Remove(sell);
            db.SaveChanges();

            return Ok(sell);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SellExists(int id)
        {
            return db.Sells.Count(e => e.SellId == id) > 0;
        }
    }
}