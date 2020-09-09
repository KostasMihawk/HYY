using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HYY.Viewmodels
{
    public class RadiographyVM
    {
        public string Doctor { get; set; }
        public string Details { get; set; }
        [Display(Name = ("Radiography Actions"))]
        public string RadiographyActions { get; set; }
        [Display(Name=("Patient Name"))]
        public string PatientName { get; set; }
        [Display(Name=("Patient Surname"))]
        public string PatientSurname { get; set; }
        [DisplayName("Patients Father Name")]
        public string PatientsFatherName { get; set; }
        [DisplayName("Patients Mother Name")]
        public string PatientsMotherName { get; set; }
        public string AMKA { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        [DisplayName("Work Number")]
        public string Phone1 { get; set; }
        [DisplayName("Home Number")]
        public string Phone2 { get; set; }
        [DisplayName("Mobile Number")]
        public string Phone3 { get; set; }
        public Enums.Enums.Priority Priority { get; set; }
    }
}