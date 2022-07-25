using System;
using System.Collections.Generic;

#nullable disable

namespace AssignmentSigortamNet.Data
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public long NationalIdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
