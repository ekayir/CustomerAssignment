using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.Data
{
    public class CustomerDTO
    {
        public Guid Id { get; set; }
        public long NationalIdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
