using Application.Frontal.Configuration.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Frontal.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new UserAndRolesProfile());

            });
        }
    }



}