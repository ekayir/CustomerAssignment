using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSigortamNet.Data
{
    public class AddCustomerViewModel
    {
        public AddCustomerViewModel()
        {
            ActionResult = new Result { IsSuccess = true };
            Customer = new CustomerDTO();
        }
        public Result ActionResult { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
