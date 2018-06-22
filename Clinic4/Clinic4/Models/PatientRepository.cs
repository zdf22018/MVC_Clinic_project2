using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinic4.Models;

namespace Clinic4.Models
{
    public class PatientRepository
    {
        ModelClinic context = new ModelClinic();

        public patient GetPatientByID(int id)
        {
            return (from p in context.patients where p.Id == id select p).SingleOrDefault();
        }

        public List<display_appointements_for_Patient> GetPatientAppointmentsById(int id)
        {

            var apt = (from x in context.display_appointements_for_Patient where x.PatientId == id select x).ToList();


            return apt;

        }
    }
}