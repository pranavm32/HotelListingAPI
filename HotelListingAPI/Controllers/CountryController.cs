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
using Microsoft.AspNetCore.Authorization;
using HotelListingAPI.Data;

namespace HotelListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetCountry")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels" });
                var result = _mapper.Map<IList<CountryDTO>>(country);
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDTO cntryDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"Invalid POST attempt in {nameof(CreateCountry)} ");
                return BadRequest(ModelState);
            }

            try
            {
                var country = _mapper.Map<Country>(cntryDTO);
                await _unitOfWork.Countries.Insert(country);
                await _unitOfWork.Save();
                return CreatedAtRoute("GetCountry", new { id = country.Id }, country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateCountry)}");
                return StatusCode(500, $"Internal Server Error. Plase try again later");
            }
        }

        // [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountryDTO cntryDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCountry)}");
                return BadRequest(ModelState);
            }
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id);
                if (country == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCountry)}");
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(cntryDTO, country);
                _unitOfWork.Countries.Update(country);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateCountry)}");
                return StatusCode(500, $"Internal Server Error. Plase try again later");
            }
        }

        // [Authorize]
        [HttpDelete("id:int")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCountry)}");
                return BadRequest();
            }
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id);
                if (country == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCountry)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Countries.Delete(id);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteCountry)}");
                return StatusCode(500, $"Internal Server Error. Plase try again later");
            }
        }
    }
}
    