using AssignmentSigortamNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Integration
{
    public interface ICustomerService
    {
        Result<List<CustomerDTO>> GetAllCustomer();
        Result<CustomerDTO> GetCustomer(Guid customerId);
        Result<List<CustomerSearchResultData>> SearchCustomer(string firstName, string lastName, long? nationalIdNumber);
        Result<CustomerDTO> AddCustomer(CustomerDTO customer);
        Result<CustomerDTO> DeleteCustomer(Guid customerId);
    }
}
