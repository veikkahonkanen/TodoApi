using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Actor : BaseModel
    {
        public long PersonId { get; set; }

        public Person Person { get; set; }
    }
}
