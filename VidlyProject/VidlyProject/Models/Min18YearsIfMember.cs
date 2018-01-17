using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
  public class Min18YearsIfMember : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var customer = (Customer)validationContext.ObjectInstance;
      if (customer.MembershipTypeId == MembershipType.Unknown || //0 -> nothing is selected;
        customer.MembershipTypeId == MembershipType.PayAsYouGo)  //1 -> pay as you go selected (so no membership is required)
        return ValidationResult.Success;

      if (customer.Birthday == null)
        return new ValidationResult("Birthday is required");

      var age = DateTime.Today.Year - customer.Birthday.Value.Year;
      return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old");
    }
  }
}