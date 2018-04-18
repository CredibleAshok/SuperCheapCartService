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
    public class CategoriesController : ApiController
    {
        private SuperCheapCartEntities db = new SuperCheapCartEntities();

        // GET: api/Categories
        [Route("api/categories")]
        [HttpGet]
        public IList<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        [HttpPost]
        [Route("api/saveCategory")]
        public IHttpActionResult PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(category);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}