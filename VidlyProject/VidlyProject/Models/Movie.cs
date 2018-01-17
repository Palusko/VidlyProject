using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
  public class Movie
  {
    public int Id { get; set; }
    [Required(ErrorMessage ="Please enter the name of the movie")]
    public string Name { get; set; }

    [Required(ErrorMessage ="Please select a genre")]
    [Display(Name="Genre")]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    [Required(ErrorMessage ="Please enter release date")]
    [Display(Name = "Release Date")]
    public DateTime? ReleaseDate { get; set; }

    [Display(Name = "Date Added")]
    public DateTime DateAdded { get; set; }

    [Required(ErrorMessage ="Please enter number of copies in stock")]
    [Display(Name = "Number In Stock")]
    [Range(1,20,ErrorMessage ="Stock must be between 1 and 20")]
    public int? NumberInStock { get; set; }
  }
}