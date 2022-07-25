using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Data
{
    public partial class Customer
    {
        public CustomerDTO ConverToDTO()
        {
            return new CustomerDTO
            {
                BirthDate = this.BirthDate,
                FirstName = this.FirstName,
                Id = this.Id,
                IsDeleted = this.IsDeleted,
                LastName = this.LastName,
                NationalIdNumber = this.NationalIdNumber
            };
        }
        public CustomerSearchResultData ConvertToCustomerSearchResultData()
        {
            return new CustomerSearchResultData
            {
                BirthDate = this.BirthDate.Year + "-**-**",
                FirstName = this.FirstName.Substring(0, 2) + "*****",
                Id = this.Id,
                IsDeleted = this.IsDeleted,
                LastName = this.LastName.Substring(0, 2) + "*****",
                NationalIdNumber = "*******" + this.NationalIdNumber.ToString().Substring(7, 4)
            };
        }
    }
}
