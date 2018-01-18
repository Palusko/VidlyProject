using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Dtos;
using VidlyProject.Models;

namespace VidlyProject.App_Start
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      /*
      var config = new MapperConfiguration(cfg => {
        cfg.CreateMap<Customer, CustomerDto>();
        cfg.CreateMap<CustomerDto, Customer>();
      });

      var mapper = config.CreateMapper();
      */
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>();
      
    }
  }
}