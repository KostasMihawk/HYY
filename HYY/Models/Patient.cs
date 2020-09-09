using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HYY.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NameOfFather { get; set; }
        public string NameOfMother { get; set; }
        public string AMKA { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
    }
}