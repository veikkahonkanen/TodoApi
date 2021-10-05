using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.DataTransferObjects.Outgoing
{
    public class ReviewDto
    {
        public long? Id { get; set; }

        public double? Rating { get; set; }

        public bool? IsCriticRated { get; set; }

        public string? Text { get; set; }

        public long? MovieId { get; set; }

        public Movie? Movie { get; set; }
    }

    public class ReviewDtoProfile : Profile
    {
        public ReviewDtoProfile()
        {
            CreateMap<Models.Review, ReviewDto>().ReverseMap(); // Goes both ways with reverse map
        }
    }
}
