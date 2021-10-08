using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Incoming
{
    public class ReviewDtoIn : BaseDto
    {
        public double? Rating { get; set; }

        public bool? IsCriticRated { get; set; }

        public string? Text { get; set; }

        public long? MovieId { get; set; }
    }

    public class ReviewDtoInProfile : Profile
    {
        public ReviewDtoInProfile()
        {
            CreateMap<ReviewDtoIn, Models.Review>().ReverseMap();
        }
    }
}
