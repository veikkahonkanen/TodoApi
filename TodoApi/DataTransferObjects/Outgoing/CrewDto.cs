using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class CrewDto : BaseDto
    {
        public long? ActorId { get; set; }

        public MovieActorDto? Actor { get; set; }

        public long? DirectorId { get; set; }

        public DirectorDto? Director { get; set; }

        public long? MovieId { get; set; }

        public MovieDto? Movie { get; set; }
    }

    public class CrewDtoProfile : Profile
    {
        public CrewDtoProfile()
        {
            // CreateMap<Models.Crew, CrewDto>().ReverseMap();
        }
    }
}
