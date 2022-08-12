using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyConverter.Models
{
    public class Country
    {

        public int CountryId { get; set; } 

        [Required]
        public string Name { get; set; }
        public object CountryRate { get; set; }
        public Country Country { get; set; }
    }
}
