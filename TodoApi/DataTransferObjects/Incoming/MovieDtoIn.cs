using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DataTransferObjects.Incoming
{
    public class MovieDtoIn : BaseDto
    {
        public string? Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string? Description { get; set; }

        public long? ProducingCompanyId { get; set; }
    }

    public class MovieDtoInProfile : Profile
    {
        public MovieDtoInProfile()
        {
            CreateMap<MovieDtoIn, Models.Movie>().ReverseMap();
        }
    }
}
