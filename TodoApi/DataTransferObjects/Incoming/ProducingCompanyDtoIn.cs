using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Incoming
{
    public class ProducingCompanyDtoIn : BaseDto
    {
        public string? Name { get; set; }

        public string? Nationality { get; set; }
    }

    public class ProducingCompanyDtoInProfile : Profile
    {
        public ProducingCompanyDtoInProfile()
        {
            CreateMap<ProducingCompanyDtoIn, Models.ProducingCompany>().ReverseMap();
        }
    }
}
