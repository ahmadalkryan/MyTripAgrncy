﻿using Application.DTOs.Actions;
using Application.DTOs.Booking;
using Application.DTOs.Common;
using Application.Filter;
using Application.IApplicationServices.Booking;
using Application.Serializer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class BookingController : ControllerBase
    {
        /// <summary>
        /// The booking service
        /// </summary>
        private readonly IBookingService _bookingService;
        /// <summary>
        /// The json fields serializer
        /// </summary>
        private readonly IJsonFieldsSerializer _jsonFieldsSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController"/> class.
        /// </summary>
        /// <param name="bookingService">The booking service.</param>
        /// <param name="jsonFieldsSerializer">The json fields serializer.</param>
        public BookingController(
            IBookingService bookingService,
            IJsonFieldsSerializer jsonFieldsSerializer)
        {
            _bookingService = bookingService;
            _jsonFieldsSerializer = jsonFieldsSerializer;
        }

        #region Get
        /// <summary>
        /// Gets all bookings.
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<BookingDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingService.GetByFilterAsync(null);

            if (result == null)
                return new RawJsonActionResult(
                    _jsonFieldsSerializer.Serialize(
                        new ApiResponse(true, "There are no bookings", StatusCodes.Status200OK),
                        string.Empty));

            return new RawJsonActionResult(
                    _jsonFieldsSerializer.Serialize(
                        new ApiResponse(true, "", StatusCodes.Status200OK, result),
                        string.Empty));
            
        }


        /// <summary>
        /// Gets all bookings by filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<BookingDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBookingsByFilter([FromQuery] BookingFilter filter)
        {

            var result = await _bookingService.GetByFilterAsync(filter);

            if (result == null)
                return new RawJsonActionResult(
                    _jsonFieldsSerializer.Serialize(
                        new ApiResponse(true, "There are no bookings", StatusCodes.Status200OK),
                        string.Empty));

            return new RawJsonActionResult(
                    _jsonFieldsSerializer.Serialize(
                        new ApiResponse(true, "", StatusCodes.Status200OK, result),
                        string.Empty));
        }


        /// <summary>
        /// Gets the booking by identifier.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<BookingDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] BaseDto<int> dto)
        {
            try
            {
                var result = await _bookingService.GetByIdAsync(dto);

                return new RawJsonActionResult(
                        _jsonFieldsSerializer.Serialize(
                            new ApiResponse(true, "", StatusCodes.Status200OK, result),
                            string.Empty));

            }

            catch (Exception)
            {
                return new RawJsonActionResult(
                    _jsonFieldsSerializer.Serialize(
                        new ApiResponse(false, "There are no such booking", StatusCodes.Status400BadRequest),
                        string.Empty));
            }
        }

        #endregion

        /// <summary>
        /// Updates the booking.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        //[Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(ApiResponse<List<BookingDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBooking([FromQuery] UpdateBookingDto dto)
        {
            var result = await _bookingService.UpdateAsync(dto);

            return new RawJsonActionResult(
                _jsonFieldsSerializer.Serialize(
                    new ApiResponse(true, "", StatusCodes.Status200OK, result),
                    string.Empty));
        }


        /// <summary>
        /// Creates the booking.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<List<BookingDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBooking([FromQuery] CreateBookingDto dto)
        {
            await _bookingService.CreateAsync(dto);

            return new RawJsonActionResult(
                    _jsonFieldsSerializer.Serialize(
                        new ApiResponse(true, "", StatusCodes.Status200OK),
                        string.Empty));
        }

        /// <summary>
        /// Deletes the booking by identifier.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        //[Authorize]
        [HttpDelete]
        [ProducesResponseType(typeof(ApiResponse<List<BookingDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteBookingById([FromQuery] BaseDto<int> dto)
        {

            _bookingService.DeleteByIdAsync(dto);
            return new RawJsonActionResult(
                _jsonFieldsSerializer.Serialize(
                    new ApiResponse(true, "", StatusCodes.Status200OK),
                    string.Empty));

        }
    }
}
