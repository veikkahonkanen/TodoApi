using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class MovieDto : BaseDto
    {
        public string? Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public ICollection<GenreDto>? Genres { get; set; }

        public string? Description { get; set; }

        public long? ProducingCompanyId { get; set; }

        public ProducingCompanyDto? ProducingCompany { get; set; }

        public ICollection<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();

        public ICollection<PersonDto> Actors { get; set; } = new List<PersonDto>();

        public ICollection<PersonDto> Directors { get; set; } = new List<PersonDto>();
    }

    public class MovieDtoProfile : Profile
    {
        public MovieDtoProfile()
        {
            CreateMap<Models.Movie, MovieDto>().ReverseMap(); //.ForMember(x => x.Description, s => s.MapFrom(d => d.Reviews.First().Text));
        }
    }
}
