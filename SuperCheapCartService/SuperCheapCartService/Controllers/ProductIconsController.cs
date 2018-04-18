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
    public class ProductIconsController : ApiController
    {
        private SuperCheapCartEntities db = new SuperCheapCartEntities();

        // GET: api/ProductIcons
        [HttpGet]
        [Route("api/ProductIcons")]
        public IQueryable<ProductIcon> GetProductIcons()
        {
            return db.ProductIcons;
        }

        // GET: api/ProductIcons/5
        [ResponseType(typeof(ProductIcon))]
        public IHttpActionResult GetProductIcon(int id)
        {
            ProductIcon productIcon = db.ProductIcons.Find(id);
            if (productIcon == null)
            {
                return NotFound();
            }

            return Ok(productIcon);
        }

        // PUT: api/ProductIcons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductIcon(int id, ProductIcon productIcon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productIcon.ProductIconId)
            {
                return BadRequest();
            }

            db.Entry(productIcon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductIconExists(id))
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

        // POST: api/ProductIcons
        [ResponseType(typeof(ProductIcon))]
        public IHttpActionResult PostProductIcon(ProductIcon productIcon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductIcons.Add(productIcon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productIcon.ProductIconId }, productIcon);
        }

        // DELETE: api/ProductIcons/5
        [ResponseType(typeof(ProductIcon))]
        public IHttpActionResult DeleteProductIcon(int id)
        {
            ProductIcon productIcon = db.ProductIcons.Find(id);
            if (productIcon == null)
            {
                return NotFound();
            }

            db.ProductIcons.Remove(productIcon);
            db.SaveChanges();

            return Ok(productIcon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductIconExists(int id)
        {
            return db.ProductIcons.Count(e => e.ProductIconId == id) > 0;
        }
    }
}