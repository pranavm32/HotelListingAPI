using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelListingAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HotelListingAPI.Repository;
using AutoMapper;
using HotelListingAPI.Models;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        private CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryDTO>>(countries);    
                return Ok(countries);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels"});
                var result = _mapper.Map<IList<CountryDTO>>(country);
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
    