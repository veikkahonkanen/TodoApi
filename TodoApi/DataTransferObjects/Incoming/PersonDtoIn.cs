using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.DataTransferObjects.Incoming
{
    public class PersonDtoIn : BaseDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public MovieDirectorDtoIn? Director { get; set; }

        public MovieActorDtoIn? Actor { get; set; }
    }
}
