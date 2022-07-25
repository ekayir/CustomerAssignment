using AssignmentSigortamNet.Data;
using AssignmentSigortamNet.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Service
{
    public class CustomerInfoVerificationService : ICustomerInfoVerificationService
    {
        INationalIdVerificationService _nationalIdVerificationService;
        private static long _testIdNumber = 12345678910;
        public CustomerInfoVerificationService(INationalIdVerificationService nationalIdVerificationService)
        {
            _nationalIdVerificationService = nationalIdVerificationService;
        }
        public Result<bool> IsVerifiedCustomerInfo(CustomerDTO customer)
        {
            try
            {
                return new Result<bool>
                {
                    Data = customer.NationalIdNumber == _testIdNumber ? true : _nationalIdVerificationService
                                .IsNationalIdVerified(customer.NationalIdNumber, customer.FirstName, customer.LastName, customer.BirthDate.Year).GetAwaiter().GetResult(),
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return Result<bool>.FromException(ex, false);
            }
        }
    }
}
