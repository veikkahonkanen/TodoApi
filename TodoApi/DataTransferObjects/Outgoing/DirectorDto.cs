using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class DirectorDto
    {
        public long? Id { get; set; }

        public PersonDto? Person { get; set; }

        public ICollection<CrewDto>? Crews { get; set; }
    }

    public class DirectorDtoProfile : Profile
    {
        public DirectorDtoProfile()
        {
            CreateMap<Models.Director, DirectorDto>().ReverseMap();
        }
    }
}
