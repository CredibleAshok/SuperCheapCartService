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
using SuperCheapCartService.Models;

namespace SuperCheapCartService.Controllers
{
    public class SubCategoriesController : ApiController
    {
        private SuperCheapCartEntities db = new SuperCheapCartEntities();

        // GET: api/SubCategories
        [HttpGet]
        [Route("api/getSubcategories")]
        public IList<SubCategory> GetSubCategories()
        {
            return db.SubCategories.ToList();
        }

        // GET: api/SubCategories
        [HttpGet]
        [Route("api/getSubcategoriesByCategoryId")]
        public IList<SubCategory> GetSubcategoriesByCategoryId(int CategoryId)
        {
            //todo: correct it after ui is done
            //return db.SubCategories.Where(x => x.CategoryId = CategoryId).ToList();
            return db.SubCategories.ToList();
        }

        // POST: api/SubCategories
        [HttpPost]
        [Route("api/saveSubcategory")]
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult PostSubCategory([FromBody] SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCategories.Add(subCategory);
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