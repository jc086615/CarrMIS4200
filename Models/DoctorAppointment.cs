using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrMIS4200.Models
{
    public class DoctorAppointment
    {
        public int doctorAppointmentId { get; set; }

        public string docLastName { get; set; }

        public int doctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public int patientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}