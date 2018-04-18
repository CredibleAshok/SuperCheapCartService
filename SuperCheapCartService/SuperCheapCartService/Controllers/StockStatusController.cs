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
using SuperCheapCartService.Data_Model;

namespace SuperCheapCartService.Controllers
{
    public class StockStatusController : ApiController
    {
        private SuperCheapCartEntities db = new SuperCheapCartEntities();

        // GET: api/StockStatus
        [HttpGet]
        [Route("api/getStockStatus")]
        public IQueryable<StockStatu> GetStockStatus()
        {
            return db.StockStatus;
        }

        // GET: api/StockStatus/5
        [ResponseType(typeof(StockStatu))]
        public IHttpActionResult GetStockStatu(int id)
        {
            StockStatu stockStatu = db.StockStatus.Find(id);
            if (stockStatu == null)
            {
                return NotFound();
            }

            return Ok(stockStatu);
        }

        // PUT: api/StockStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStockStatu(int id, StockStatu stockStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockStatu.StockStatusId)
            {
                return BadRequest();
            }

            db.Entry(stockStatu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockStatuExists(id))
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

        // POST: api/StockStatus
        [ResponseType(typeof(StockStatu))]
        public IHttpActionResult PostStockStatu(StockStatu stockStatu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StockStatus.Add(stockStatu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stockStatu.StockStatusId }, stockStatu);
        }

        // DELETE: api/StockStatus/5
        [ResponseType(typeof(StockStatu))]
        public IHttpActionResult DeleteStockStatu(int id)
        {
            StockStatu stockStatu = db.StockStatus.Find(id);
            if (stockStatu == null)
            {
                return NotFound();
            }

            db.StockStatus.Remove(stockStatu);
            db.SaveChanges();

            return Ok(stockStatu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockStatuExists(int id)
        {
            return db.StockStatus.Count(e => e.StockStatusId == id) > 0;
        }
    }
}