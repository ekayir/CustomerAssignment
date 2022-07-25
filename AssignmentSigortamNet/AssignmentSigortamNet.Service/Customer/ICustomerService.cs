using AssignmentSigortamNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Service
{
    public interface ICustomerService
    {
        Result<bool> DeleteAllCustomers();
        Result<CustomerDTO> AddCustomer(CustomerDTO customerDTO);
        Result<CustomerDTO> GetCustomer(Guid customerId);
        Result<List<CustomerSearchResultData>> GetCustomers(string firstName, string lastName, long? nationalIdNumber);
        Result<List<CustomerDTO>> GetAllCustomers();
        Result<CustomerDTO> DeleteCustomer(Guid customerId);
    }
}
