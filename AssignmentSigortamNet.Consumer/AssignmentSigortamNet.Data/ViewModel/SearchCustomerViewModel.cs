using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSigortamNet.Data
{
    public class SearchCustomerViewModel
    {
        public SearchCustomerViewModel()
        {
            Result = new Result<List<CustomerSearchResultData>>();
        }
        public long? NationalIdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Result<List<CustomerSearchResultData>> Result { get; set; }
    }
}
