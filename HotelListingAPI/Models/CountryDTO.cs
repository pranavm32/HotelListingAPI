using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListingAPI.Models
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "CountryName is Too Long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "ShortName is Too Long")]
        public string ShortName { get; set; }
    }
    public class UpdateCountryDTO : CreateCountryDTO
    {
        public IList<CreateHotelDTO> Hotel { get; set; }
    }
    public class CountryDTO: CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotel { get; set; }
        //[Required]
        //[StringLength(maximumLength:50, ErrorMessage = "CountryName is Too Long")]
        //public string Name { get; set; }

        //[Required]
        //[StringLength(maximumLength: 2, ErrorMessage = "ShortName is Too Long")]
        //public string ShortName { get; set; }
    }

    
}
