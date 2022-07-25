using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Data
{
    public class CustomerSearchResultData
    {
        public Guid Id { get; set; }
        public string NationalIdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
