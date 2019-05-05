
using Application.bbdd.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Frontal.Configuration.Profiles
{
    public class UserAndRolesProfile:Profile
    {
        public UserAndRolesProfile()
        {

            CreateMap<ApplicationUser, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.UserName));
                    
            CreateMap<ApplicationRole, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));

        }

       
    }
}