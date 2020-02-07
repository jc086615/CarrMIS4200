using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrMIS4200.Models
{
    public class Patient
    {
        public int patientId { get; set; }

        public string patientLastName { get; set; }
        public string patientFirstName { get; set; }
        public string patientPhone { get; set; }

        public ICollection<DoctorAppointment> DoctorAppointment { get; set; }
    }
}