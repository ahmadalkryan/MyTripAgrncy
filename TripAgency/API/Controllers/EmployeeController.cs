﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    using Application.DTOs.Employee;
    using Application.IApplicationServices.Authentication;
    using Application.IApplicationServices.Employee;
    using Application.Serializer;
    using Domain.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Application.DTOs.Actions;
    using Application.DTOs.Customer;
    using Application.Common;
    using Application.IApplicationServices.Customer;

    namespace API.Controllers
    {
        [ApiController]
        [Authorize(Roles = ApiConsts.AdminRoleName)]
        public class EmployeeController : BaseAuthenticatedController
        {
            private readonly IEmployeeService _employeeService;
            private readonly ICustomerService _customerService; 

            public EmployeeController(
                IAuthenticationService authenticationService,
                IJsonFieldsSerializer jsonFieldsSerializer,
                IEmployeeService employeeService,
                ICustomerService customerService) : base(authenticationService, jsonFieldsSerializer)
            {
                _employeeService = employeeService;
                _customerService = customerService;
            }

            [HttpGet]
            [ProducesResponseType(typeof(ApiResponse<EmployeesDto>), StatusCodes.Status200OK)]
            public async Task<IActionResult> GetAllEmployeesAsync()
            {
                var result = await _employeeService.GetEmployeesAsync();
                return new RawJsonActionResult(_jsonFieldsSerializer.Serialize(new ApiResponse(true, "", StatusCodes.Status200OK, result), string.Empty));
            }

            [HttpPost]
            [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status201Created)]
            [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto dto)
            {
                dto.Id = await _authenticationService.RegisterAsync(dto.UserDto);
                await _customerService.CreateCustomerAsync(new CreateCustomerDto() { UserDto = dto.UserDto, Id = dto.Id});
                var result = await _employeeService.CreateEmployeeAsync(dto);
                return new RawJsonActionResult(_jsonFieldsSerializer.Serialize(new ApiResponse(true, "Employee created successfully", StatusCodes.Status201Created, result), string.Empty));
            }

            [HttpPut]
            [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> UpdateEmployeeAsync([FromBody] UpdateEmployeeDto dto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResponse(false, "Invalid request", StatusCodes.Status400BadRequest));

                var result = await _employeeService.UpdateEmployeeAsync(dto);
                return new RawJsonActionResult(_jsonFieldsSerializer.Serialize(new ApiResponse(true, "Employee updated successfully", StatusCodes.Status200OK, result), string.Empty));
            }

            [HttpDelete]
            [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> DeleteEmployeeAsync([FromBody] BaseDto<long> dto)
            {
                if (dto == null || dto.Id <= 0)
                    return BadRequest(new ApiResponse(false, "Invalid employee ID", StatusCodes.Status400BadRequest));

                await _employeeService.DeleteEmployeeAsync(dto);
                return new RawJsonActionResult(_jsonFieldsSerializer.Serialize(new ApiResponse(true, "Employee deleted successfully", StatusCodes.Status200OK), string.Empty));
            }
        }
    }
}
