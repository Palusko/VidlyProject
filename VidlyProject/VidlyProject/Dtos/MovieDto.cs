using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.Dtos
{
  public class MovieDto
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter the name of the movie")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please select a genre")]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    [Required(ErrorMessage = "Please enter release date")]
    public DateTime? ReleaseDate { get; set; }

    public DateTime DateAdded { get; set; }

    [Required(ErrorMessage = "Please enter number of copies in stock")]
    [Range(1, 20, ErrorMessage = "Stock must be between 1 and 20")]
    public int? NumberInStock { get; set; }
  }
}