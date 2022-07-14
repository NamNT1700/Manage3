using AutoMapper;
using Manage.Model.DTO.Allwance;
using Manage.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.API
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<HuAllwance, AllwanceDTO>();
            CreateMap<AllwanceDTO, HuAllwance>();
        }
    }
}
