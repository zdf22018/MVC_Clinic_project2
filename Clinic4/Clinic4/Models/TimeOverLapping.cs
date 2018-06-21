using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinic4.Models
{
    public class TimeOverLapping : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ModelClinic context = new ModelClinic();
            var a = (availability)validationContext.ObjectInstance;
            // this function need validation to check the one being added is not overlaping with existing ones.
            //code???
            //check the sTime if is overlapping with existing availabilities
            bool CanAddAvailability = true;
            var list = (from av in context.availabilities where av.DoctorId == a.DoctorId select av).ToList();
            foreach (availability x in list)
            {
                if (a.AvailableFrom >= x.AvailableFrom && a.AvailableFrom <= x.AvailableTo) {
                    CanAddAvailability = false;
                 
                }
                else
                {
                    CanAddAvailability = true;
                   
                }


            }

           
        
            return (CanAddAvailability)? 
                ValidationResult.Success:
            new ValidationResult("The time entered is overlaping with exiting time");
        }

    }
       
    }
