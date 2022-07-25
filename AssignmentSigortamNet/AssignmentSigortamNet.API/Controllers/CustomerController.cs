using AssignmentSigortamNet.Data;
using AssignmentSigortamNet.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AssignmentSigortamNet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("GetAllCustomer")]
        public Result<List<CustomerDTO>> GetAllCustomer()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet]
        [Route("GetCustomer")]
        public Result<CustomerDTO> GetCustomer(Guid customerId)
        {
            return _customerService.GetCustomer(customerId);
        }

        [HttpPost]
        [Route("SearchCustomer")]
        public Result<List<CustomerSearchResultData>> SearchCustomer(string firstName, string lastName, long? nationalIdNumber)
        {
            return _customerService.GetCustomers(firstName, lastName, nationalIdNumber);
        }

        [HttpPost]
        [Route("AddCustomer")]
        public Result<CustomerDTO> AddCustomer([FromBody] CustomerDTO customer)
        {
            return _customerService.AddCustomer(customer);
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public Result<CustomerDTO> DeleteCustomer(Guid customerId)
        {
            return _customerService.DeleteCustomer(customerId);
        }
    }
}
