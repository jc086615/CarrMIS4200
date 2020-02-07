using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrMIS4200.Models
{
    public class Doctor
    {
        public int doctorId { get; set; }

        public string docLastName { get; set; }
        public string docFirstName { get; set; }
        public string docPhone { get; set; }

        public ICollection<DoctorAppointment> DoctorAppointment { get; set; }
    }
}