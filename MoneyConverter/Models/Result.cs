using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyConverter.Models
{
    public class Result
    {
        public int ResultId { get; set; }

        [Required]
        public string Name { get; set; }


        //foreign key 
        public string CountryId { get; set; }

        public int CountryRateId { get; set; }
        //

        public int Send { get; set; }
        
        public int Receive { get; set; }

        // parent model refrences
        public Country country { get; set; }
        public CountryRate CountryRate { get; set; }


    }
}
