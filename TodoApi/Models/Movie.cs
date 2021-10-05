using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Movie : BaseModel
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public string? Description { get; set; }

        public long ProducingCompanyId { get; set; }

        public ProducingCompany ProducingCompany { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public string SecretInfo { get; set; }
    }
}
