using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class ProducingCompanyDto
    {
        public long? Id { get; set; }

        public string? Name { get; set; }

        public string? Nationality { get; set; }

        public ICollection<MovieDto>? Movies { get; set; }
    }

    public class ProducingCompanyDtoProfile : Profile
    {
        public ProducingCompanyDtoProfile()
        {
            CreateMap<Models.ProducingCompany, ProducingCompanyDto>().ReverseMap();
        }
    }
}
