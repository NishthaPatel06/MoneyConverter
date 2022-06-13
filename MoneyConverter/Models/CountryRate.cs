using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyConverter.Models
{
    public class CountryRate
    {
        public int CountryRateId { get; set; }

        [Required]

        public string Name { get; set; }

        //refer to one to many realtionship or option to have more countries

        // child model refrences
        public List<Country> Countries { get; set; }

        public int CountryId { get; set; }
      
      

        


    }
}
