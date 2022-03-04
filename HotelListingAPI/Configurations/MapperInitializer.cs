using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelListingAPI.Data;
using HotelListingAPI.Models;

namespace HotelListingAPI.Configurations
{
    public class MapperInitializer: Profile
    {
        public MapperInitializer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            // CreateMap<ApiUser, LoginUserDTO>().ReverseMap();
        }
    }
}
