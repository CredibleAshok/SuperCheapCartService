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
    public class PackageSizesController : ApiController
    {
        private SuperCheapCartEntities db = new SuperCheapCartEntities();

        [HttpGet]
        [Route("api/getPackageSizes")]
        // GET: api/PackageSizes
        public IList<PackageSize> GetPackageSizes()
        {
            return db.PackageSizes.ToList();
        }

        // GET: api/PackageSizes/5
        [ResponseType(typeof(PackageSize))]
        public IHttpActionResult GetPackageSize(int id)
        {
            PackageSize packageSize = db.PackageSizes.Find(id);
            if (packageSize == null)
            {
                return NotFound();
            }

            return Ok(packageSize);
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