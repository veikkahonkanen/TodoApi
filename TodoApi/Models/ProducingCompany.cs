using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class ProducingCompany : BaseModel
    {
        public string Name { get; set; }

        public string Nationality { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
