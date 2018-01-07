﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
  public class Movie
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public int GenreId { get; set; }
    public Genre Genre { get; set; }

    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Date Added")]
    public DateTime DateAdded { get; set; }

    [Display(Name = "Number In Stock")]
    public int NumberInStock { get; set; }
  }
}