using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Director : BaseModel
    {
        public long PersonId { get; set; }

        public Person Person { get; set; }

        public ICollection<Crew>? Crews { get; set; } // Entity framework creates a new database in the background
    }
}
