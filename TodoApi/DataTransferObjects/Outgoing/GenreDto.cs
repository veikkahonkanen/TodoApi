using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class GenreDto : BaseDto
    {
        public string? Name { get; set; }

        public ICollection<MovieDto>? Movies { get; set; }
    }

    public class GenreDtoProfile : Profile
    {
        public GenreDtoProfile()
        {
            CreateMap<Models.Genre, GenreDto>().ReverseMap();
        }
    }
}
