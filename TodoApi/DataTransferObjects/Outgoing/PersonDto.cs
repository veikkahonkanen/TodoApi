using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class PersonDto
    {
        public long? PersonId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public MovieDirectorDto? Director { get; set; }

        public MovieActorDto? Actor { get; set; }
    }

    public class PersonDtoProfile : Profile
    {
        public PersonDtoProfile()
        {
            CreateMap<Models.Person, PersonDto>()
                .ForMember(x => x.PersonId, o => o.MapFrom(f => f.Id))
                .ReverseMap();
        }
    }
}
