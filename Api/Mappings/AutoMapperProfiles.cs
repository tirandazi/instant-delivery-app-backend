using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;
using Api.Model.DTO;
using AutoMapper;

namespace Api.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductHomeDTO,Product>().ReverseMap();
        }
    }
}