using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class CrewDto
    {
        public long? Id { get; set; }

        public long? ActorId { get; set; }

        public Actor? Actor { get; set; }

        public long? DirectorId { get; set; }

        public Director? Director { get; set; }

        public long? MovieId { get; set; }

        public Movie? Movie { get; set; }
    }

    public class CrewDtoProfile : Profile
    {
        public CrewDtoProfile()
        {
            // CreateMap<Models.Crew, CrewDto>().ReverseMap();
        }
    }
}
