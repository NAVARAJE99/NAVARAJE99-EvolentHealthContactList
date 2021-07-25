using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvolentContact.ViewModel
{
    public class ContactVM
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Active")]
        public bool Active { get; set; }
        public System.DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}