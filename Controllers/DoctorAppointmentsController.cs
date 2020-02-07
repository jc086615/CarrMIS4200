using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarrMIS4200.DAL;
using CarrMIS4200.Models;

namespace CarrMIS4200.Controllers
{
    public class DoctorAppointmentsController : Controller
    {
        private MIS4200Context db = new MIS4200Context();

        // GET: DoctorAppointments
        public ActionResult Index()
        {
            var doctorAppointments = db.DoctorAppointments.Include(d => d.Doctor).Include(d => d.Patient);
            return View(doctorAppointments.ToList());
        }

        // GET: DoctorAppointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorAppointment doctorAppointment = db.DoctorAppointments.Find(id);
            if (doctorAppointment == null)
            {
                return HttpNotFound();
            }
            return View(doctorAppointment);
        }

        // GET: DoctorAppointments/Create
        public ActionResult Create()
        {
            ViewBag.doctorId = new SelectList(db.Doctors, "doctorId", "docLastName");
            ViewBag.patientId = new SelectList(db.Patients, "patientId", "patientLastName");
            return View();
        }

        // POST: DoctorAppointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "doctorAppointmentId,docLastName,doctorId,patientId")] DoctorAppointment doctorAppointment)
        {
            if (ModelState.IsValid)
            {
                db.DoctorAppointments.Add(doctorAppointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctorId = new SelectList(db.Doctors, "doctorId", "docLastName", doctorAppointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patients, "patientId", "patientLastName", doctorAppointment.patientId);
            return View(doctorAppointment);
        }

        // GET: DoctorAppointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorAppointment doctorAppointment = db.DoctorAppointments.Find(id);
            if (doctorAppointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctorId = new SelectList(db.Doctors, "doctorId", "docLastName", doctorAppointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patients, "patientId", "patientLastName", doctorAppointment.patientId);
            return View(doctorAppointment);
        }

        // POST: DoctorAppointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "doctorAppointmentId,docLastName,doctorId,patientId")] DoctorAppointment doctorAppointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorAppointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctorId = new SelectList(db.Doctors, "doctorId", "docLastName", doctorAppointment.doctorId);
            ViewBag.patientId = new SelectList(db.Patients, "patientId", "patientLastName", doctorAppointment.patientId);
            return View(doctorAppointment);
        }

        // GET: DoctorAppointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorAppointment doctorAppointment = db.DoctorAppointments.Find(id);
            if (doctorAppointment == null)
            {
                return HttpNotFound();
            }
            return View(doctorAppointment);
        }

        // POST: DoctorAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorAppointment doctorAppointment = db.DoctorAppointments.Find(id);
            db.DoctorAppointments.Remove(doctorAppointment);
            db.SaveChanges();
            return RedirectToAction("Index");
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
