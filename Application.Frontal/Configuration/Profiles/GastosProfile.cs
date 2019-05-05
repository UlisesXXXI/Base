using Application.bbdd.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Configuration.Profiles
{
    public class GastosProfile:Profile
    {

        public GastosProfile()
        {

            #region Gasto
            CreateMap<Gasto, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()));
            #endregion

        }
    }
}