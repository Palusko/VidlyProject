using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
  public class MembershipType
  {
    public byte Id { get; set; }
    public string Name { get; set; }
    public short SignUpFee { get; set; }
    public byte DurationInMonths { get; set; }
    public byte DiscountRate { get; set; }

    //these static fields are set up to avoid using magic numbers in the logic (in Min18YearsIfMember class)
    public static readonly byte Unknown = 0; 
    public static readonly byte PayAsYouGo = 1;
  }  
}