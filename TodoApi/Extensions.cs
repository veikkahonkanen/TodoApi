using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi
{
    public static class Extensions // Extension method
    {
        public static bool OnkoYkkonen(this int numero) // this, tyyppi joka laajennetaan, tuotu muuttuja; OnkoYkkonen extends int
        {
            return numero == 1;
        }
    }
}
