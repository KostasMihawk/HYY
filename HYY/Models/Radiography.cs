using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace HYY.Models
{
    public class Radiography
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Radiography Code")]
        public string RadiographyCode { get; set; }
        [DisplayName("Issue Date")]
        public DateTime IssueDate { get; set; }
        public string Details { get; set; }
        [DisplayName("Radiography Actions")]
        public string RadiographyActions { get; set; }
        public ApplicationUser Doctor { get; set; }
        public string AssignedDoctor { get; set; }
        public Enums.Enums.Priority Priority { get; set; }
        public Enums.Enums.Status Status { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual Patient  Patient { get; set; }
    }
}