using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using HYY.Models;

namespace HYY.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? id)
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;

            scheduler.Config.first_hour = 6;
            scheduler.Config.last_hour = 14;


            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            TempData["id"] = id;
            
            return View(scheduler);
        }

        public ContentResult Data()

        {
            var apps = db.Appointments.ToList();
            return new SchedulerAjaxData(apps);
        }

        public ActionResult Save(FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            var id = TempData["id"];
            try
            {
                var rad = db.Radiographies.Find(id);
                var changedEvent = DHXEventsHelper.Bind<Appointment>(actionValues);
                switch (action.Type)
                {
                        
                    case DataActionTypes.Insert:
                        db.Appointments.Add(changedEvent);
                        db.SaveChanges();
                        rad = db.Radiographies.Find(id);
                        if (rad != null)
                        {
                            rad.Appointment = db.Appointments.Find(changedEvent.Id);
                            changedEvent.Description = rad.RadiographyCode;
                            rad.Status = Enums.Enums.Status.Assigned;
                        }
                        break;
                    case DataActionTypes.Delete:
                        db.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:// "update"  
                        db.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
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