using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.AdminModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.AdminProfile
{
    public class AdminProfiles:Profile
    {
        public AdminProfiles()
        {
            CreateMap<Admin, AuthenticateRequest>();
            CreateMap<RegisterModel, Admin>();
            CreateMap<UpdateModel, Admin>();
        }
    }
}
