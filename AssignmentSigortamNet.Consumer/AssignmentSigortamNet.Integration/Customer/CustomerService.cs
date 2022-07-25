using AssignmentSigortamNet.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AssignmentSigortamNet.Integration
{
    public class CustomerService : ICustomerService
    {
        private readonly IApiManager _apiManager;
        private string apiBaseUrl = "http://localhost:59491";
        public CustomerService()
        {
            _apiManager = new ApiManager();
        }
        public Result<CustomerDTO> AddCustomer(CustomerDTO customer)
        {
            try
            {
                var serviceUrl = "/Customer/AddCustomer";
                var jsonResponse = _apiManager.MakePostRequest(apiBaseUrl + serviceUrl, null, JsonConvert.SerializeObject(customer));

                if (jsonResponse.Result.IsSuccess == false) return new Result<CustomerDTO> { IsSuccess = false, Message = jsonResponse.Result.Message };

                return JsonConvert.DeserializeObject<Result<CustomerDTO>>(jsonResponse.Result.Data);
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
                var serviceUrl = "/Customer/DeleteCustomer?customerId=" + customerId;


                var jsonResponse = _apiManager.MakePostRequest(apiBaseUrl + serviceUrl, null, null);

                if (jsonResponse.Result.IsSuccess == false) return new Result<CustomerDTO> { IsSuccess = false, Message = jsonResponse.Result.Message };

                return JsonConvert.DeserializeObject<Result<CustomerDTO>>(jsonResponse.Result.Data);
            }
            catch (Exception ex)
            {
                return Result<CustomerDTO>.FromException(ex, null);
            }
        }

        public Result<List<CustomerDTO>> GetAllCustomer()
        {
            try
            {
                var serviceUrl = "/Customer/GetAllCustomer";

                var httpResponse = _apiManager.MakeGetRequest(apiBaseUrl + serviceUrl, null, null);
                var jsonResponse = httpResponse.Result.Data.Content.ReadAsStringAsync().Result;

                if (httpResponse.Result.IsSuccess == false) return new Result<List<CustomerDTO>> { IsSuccess = false, Message = httpResponse.Result.Message };

                return JsonConvert.DeserializeObject<Result<List<CustomerDTO>>>(jsonResponse);
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
                var serviceUrl = "/Customer/GetCustomer?customerId=" + customerId;

                var httpResponse = _apiManager.MakeGetRequest(apiBaseUrl + serviceUrl, null, null);
                var jsonResponse = httpResponse.Result.Data.Content.ReadAsStringAsync().Result;

                if (httpResponse.Result.IsSuccess == false) return new Result<CustomerDTO> { IsSuccess = false, Message = httpResponse.Result.Message };

                return JsonConvert.DeserializeObject<Result<CustomerDTO>>(jsonResponse);
            }
            catch (Exception ex)
            {
                return Result<CustomerDTO>.FromException(ex, null);
            }
        }

        public Result<List<CustomerSearchResultData>> SearchCustomer(string firstName, string lastName, long? nationalIdNumber)
        {
            try
            {
                var serviceUrl = string.Format("/Customer/SearchCustomer?firstName={0}&lastName={1}&nationalIdNumber={2}", firstName, lastName, nationalIdNumber);

                var jsonResponse = _apiManager.MakePostRequest(apiBaseUrl + serviceUrl, null, null);

                if (jsonResponse.Result.IsSuccess == false) return new Result<List<CustomerSearchResultData>> { IsSuccess = false, Message = jsonResponse.Result.Message };

                return JsonConvert.DeserializeObject<Result<List<CustomerSearchResultData>>>(jsonResponse.Result.Data);
            }
            catch (Exception ex)
            {
                return Result<List<CustomerSearchResultData>>.FromException(ex, null);
            }
        }
    }
}
