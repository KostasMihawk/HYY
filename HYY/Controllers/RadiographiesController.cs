using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HYY.Models;
using HYY.Viewmodels;
using Microsoft.AspNet.Identity;

namespace HYY.Controllers
{
    public class RadiographiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Radiographies
        public ActionResult Index()
        {
            return View(db.Radiographies.Include(x=>x.Patient).Include(x=>x.Appointment).ToList());
        }

        // GET: Radiographies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiography radiography = db.Radiographies.Find(id);
            if (radiography == null)
            {
                return HttpNotFound();
            }
            return View(radiography);
        }

        // GET: Radiographies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Radiographies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RadiographyVM vm)
        {
            if (ModelState.IsValid)
            {
                var random = new Random();
                var Patient = new Patient
                {
                    PatientCode = random.Next().ToString(),
                    Name = vm.PatientName,
                    Surname = vm.PatientSurname,
                    NameOfFather = vm.PatientsFatherName,
                    NameOfMother = vm.PatientsMotherName,
                    AMKA = vm.AMKA,
                    Birthdate = vm.Birthdate,
                    Address = vm.Address,
                    HomePhone = vm.Phone1,
                    WorkPhone = vm.Phone2,
                    MobilePhone = vm.Phone3
                };
                db.Patients.Add(Patient);
                db.SaveChanges();

                var Radiograpgy = new Radiography()
                {
                    RadiographyCode = random.Next().ToString(),
                    IssueDate = DateTime.Now,
                    Details = vm.Details,
                    RadiographyActions = vm.RadiographyActions,
                    Doctor = db.Users.Find(User.Identity.GetUserId()),
                    Priority = vm.Priority,
                    Status = Enums.Enums.Status.Created,
                    Patient = db.Patients.Find(Patient.Id)
                };
                db.Radiographies.Add(Radiograpgy);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(vm);
        }

        // GET: Radiographies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiography radiography = db.Radiographies.Find(id);
            if (radiography == null)
            {
                return HttpNotFound();
            }
            return View(radiography);
        }

        // POST: Radiographies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RadiographyCode,IssueDate,Details,RadiographyActions,Status")] Radiography radiography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radiography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(radiography);
        }

        // GET: Radiographies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiography radiography = db.Radiographies.Find(id);
            if (radiography == null)
            {
                return HttpNotFound();
            }
            return View(radiography);
        }

        // POST: Radiographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Radiography radiography = db.Radiographies.Find(id);
            db.Radiographies.Remove(radiography);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles="Administrator,Doctor")]
        public ActionResult Appointment(int? id)
        {
            var rad = db.Radiographies
                .Include(x => x.Patient)
                .Include(x => x.Appointment)
                .Include(x=>x.Doctor)
                .ToList();
            return View(rad);
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
