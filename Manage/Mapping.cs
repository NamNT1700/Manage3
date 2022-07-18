using AutoMapper;
using Manage.Model.DTO.Allwance;
using Manage.Model.DTO.User;
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
            //map HuAllwance
            CreateMap<HuAllwance, AllwanceDTO>();
            CreateMap<AllwanceDTO, HuAllwance>();
            CreateMap<ListAllwanceDTO,HuAllwance>();
            CreateMap<HuAllwance, ListAllwanceDTO>();
            CreateMap<UpdateData,HuAllwance>();

            CreateMap<UserDTO,SeUser>();
            CreateMap<SeUser, UserDTO>();
        }
    }
}
