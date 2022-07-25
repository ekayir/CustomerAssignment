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

        public Customer ConvertToDAO()
        {
            return new Customer
            {
                NationalIdNumber = Convert.ToInt64(this.NationalIdNumber),
                BirthDate = Convert.ToDateTime(this.BirthDate),
                FirstName = this.FirstName,
                LastName = this.LastName,
                Id = Guid.NewGuid(),
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                IsDeleted = false
            };
        }
    }
}
