using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentContact.DAL.DataObjects
{
    public class ContactDTO
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public System.DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
