using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HYY.Models;

namespace HYY.Controllers
{
    public class AppointController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult Update(int id)
        {
            var rad = db.Radiographies.Find(id);
            return Ok();
        }
    }
}
