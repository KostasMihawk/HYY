using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HYY.Models;

namespace HYY.Viewmodels
{
    public class AppointmentVM
    {
        
        public List<Radiography> Radiographies { get; set; }
        public List<Patient> Patients { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}