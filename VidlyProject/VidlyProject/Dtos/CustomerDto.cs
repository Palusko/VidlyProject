using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.Dtos
{
  public class CustomerDto
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter customer's name.")]
    [StringLength(255)]
    public string Name { get; set; }

    public bool IsSubscribedToNewsletter { get; set; }
    //public MembershipType MembershipType { get; set; } --we remove this so it doesn't create dependency

    public byte MembershipTypeId { get; set; }
    
    //[Min18YearsIfMember] //--this would not work with API because it conflict with the old mvc approach that was used to create a customer
    //we have 2 different ways to create customer, API and MVC. We should only have one, but we are leaving it as is for now
    public DateTime? Birthday { get; set; }
  }
}