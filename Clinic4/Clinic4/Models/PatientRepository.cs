using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinic4.Models
{
    public class PatientRepository
    {
        ModelClinic context = new ModelClinic();

        public patient GetPatientByID(int id)
        {
            return (from p in context.patients where p.Id == id select p).SingleOrDefault();
        }
    }
}