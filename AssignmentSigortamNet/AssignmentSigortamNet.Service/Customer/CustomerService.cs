using AssignmentSigortamNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentSigortamNet.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly AssignmentSigortamNetDBContext _context;
        private readonly ICustomerInfoVerificationService _customerInfoVerificationService;
        public CustomerService(AssignmentSigortamNetDBContext context, ICustomerInfoVerificationService customerInfoVerificationService)
        {
            _context = context;
            _customerInfoVerificationService = customerInfoVerificationService;
        }
        public Result<CustomerDTO> AddCustomer(CustomerDTO customerDTO)
        {
            try
            {
                var isNationalIdVerified = _customerInfoVerificationService.IsVerifiedCustomerInfo(customerDTO);
                if (isNationalIdVerified.Data == false) return new Result<CustomerDTO> { IsSuccess = false, Data = customerDTO, Message = ActionMessage.NationalIdVerificationFalse };

                if (HasAlreadyInsertCustomer(customerDTO.NationalIdNumber) == true) return new Result<CustomerDTO> { IsSuccess = false, Data = customerDTO, Message = ActionMessage.AlreadyAddedCustomer };

                var customer = customerDTO.ConvertToDAO();

                _context.Customers.Add(customer);
                _context.SaveChanges();

                return new Result<CustomerDTO> { Data = customer.ConverToDTO(), IsSuccess = true, Message = ActionMessage.AddCustomerSuccess };
            }
            catch (Exception ex)
            {
                return Result<CustomerDTO>.FromException(ex, null);
            }
        }

        public Result<CustomerDTO> DeleteCustomer(Guid customerId)
        {
            try
            {
                var customer = GetCustomerDAO(customerId);

                if (customer == null) return new Result<CustomerDTO> { IsSuccess = false, Message = string.Format(ActionMessage.NoCustomerRelatedToId, customerId) };

                customer.IsDeleted = true;
                customer.LastUpdateDate = DateTime.UtcNow;

                _context.SaveChanges();

                return new Result<CustomerDTO> { Data = customer.ConverToDTO(), IsSuccess = true, Message = ActionMessage.DeleteCustomerSuccess };
            }
            catch (Exception ex)
            {
                return Result<CustomerDTO>.FromException(ex, null);
            }
        }

        public Result<List<CustomerDTO>> GetAllCustomers()
        {
            try
            {
                return new Result<List<CustomerDTO>> { Data = _context.Customers.Select(x => x.ConverToDTO()).ToList(), IsSuccess = true };
            }
            catch (Exception ex)
            {
                return Result<List<CustomerDTO>>.FromException(ex, null);
            }
        }

        public Result<CustomerDTO> GetCustomer(Guid customerId)
        {
            try
            {
                return new Result<CustomerDTO> { IsSuccess = true, Data = GetCustomerDAO(customerId)?.ConverToDTO() };
            }
            catch (Exception ex)
            {
                return Result<CustomerDTO>.FromException(ex, null);
            }
        }

        public Result<List<CustomerSearchResultData>> GetCustomers(string firstName, string lastName, long? nationalIdNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(firstName) == true && string.IsNullOrEmpty(lastName) == true && nationalIdNumber == null)
                    return new Result<List<CustomerSearchResultData>> { IsSuccess = false, Message = ActionMessage.FillAtLeastNameOrNationalId };

                if (nationalIdNumber == null && (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)))
                    return new Result<List<CustomerSearchResultData>> { IsSuccess = false, Message = ActionMessage.FillBothNames };

                if (nationalIdNumber.HasValue == true) return new Result<List<CustomerSearchResultData>>
                {
                    Data = new List<CustomerSearchResultData> { GetCustomer(nationalIdNumber.Value)?.ConvertToCustomerSearchResultData() },
                    IsSuccess = true
                };

                return new Result<List<CustomerSearchResultData>> { IsSuccess = true, Data = GetCustomers(firstName, lastName).Select(x => x.ConvertToCustomerSearchResultData()).ToList() };
            }
            catch (Exception ex)
            {
                return Result<List<CustomerSearchResultData>>.FromException(ex, null);
            }
        }
        private bool HasAlreadyInsertCustomer(long nationalIdNumber)
        {
            return _context.Customers.Any(x => x.NationalIdNumber == nationalIdNumber);
        }
        private Customer GetCustomerDAO(Guid customerId)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == customerId);
        }
        private Customer GetCustomer(long nationalIdNumber)
        {
            return _context.Customers.FirstOrDefault(x => x.NationalIdNumber == nationalIdNumber);
        }
        private List<Customer> GetCustomers(string firstName, string lastName)
        {
            return _context.Customers.Where(x => x.FirstName == firstName && x.LastName == lastName).ToList();
        }

        public Result<bool> DeleteAllCustomers()
        {
            try
            {
                var customers = _context.Customers.ToList();

                _context.Customers.RemoveRange(customers);
                _context.SaveChanges();

                return new Result<bool> { Data = true, IsSuccess = true };
            }
            catch (Exception ex)
            {
                return Result<bool>.FromException(ex, false);
            }
        }
    }
}
