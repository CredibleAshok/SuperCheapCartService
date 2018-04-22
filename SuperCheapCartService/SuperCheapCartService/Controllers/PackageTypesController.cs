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
    public class PackageTypesController : ApiController
    {
        private SuperCheapCartEntities db = new SuperCheapCartEntities();

        [HttpGet]
        [Route("api/getPackageTypes")]
        // GET: api/PackageTypes
        public IList<PackageType> GetPackageTypes()
        {
            return db.PackageTypes.ToList();
        }

        // GET: api/PackageTypes/5
        [ResponseType(typeof(PackageType))]
        public IHttpActionResult GetPackageType(int id)
        {
            PackageType packageType = db.PackageTypes.Find(id);
            if (packageType == null)
            {
                return NotFound();
            }

            return Ok(packageType);
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