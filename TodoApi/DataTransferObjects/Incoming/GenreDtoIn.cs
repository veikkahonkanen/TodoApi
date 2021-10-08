using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Incoming
{
    public class GenreDtoIn : BaseDto
    {
        public string? Name { get; set; }
    }

    public class GenreDtoProfile : Profile
    {
        public GenreDtoProfile()
        {
            CreateMap<GenreDtoIn, Models.Genre>().ReverseMap();
        }
    }
}
