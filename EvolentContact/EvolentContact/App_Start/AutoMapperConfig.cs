using AutoMapper;

using EvolentContact.DAL.DataObjects;
using EvolentContact.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolentContact.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ContactDTO, ContactVM>();
                cfg.CreateMap<ContactDTO, ContactVM>();
                cfg.CreateMap<ContactVM, ContactDTO>();

            });
        }
    }
}