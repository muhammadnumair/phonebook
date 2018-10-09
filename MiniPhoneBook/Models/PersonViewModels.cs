using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniPhoneBook.Models
{
    public class PersonViewModels
    {
        public int PersonId { get; set; }

        [Required]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Please Enter Valid Name ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Please Enter Valid Name ")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [RegularExpression("[A-Za-z ]*", ErrorMessage = "Please Enter Valid Name ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public DateTime AddedOn { get; set; }

        public string AddedBy { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Required]
        [Display(Name = "Home City")]
        public string HomeCity { get; set; }

        [Display(Name = "Facebook Account ID")]
        public string FaceBookAccountId { get; set; }

        [Display(Name = "LinkedIn ID")]
        public string LinkedInId { get; set; }

        public DateTime UpdateOn { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Twitter ID")]
        public string TwitterId { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ID")]
        public string EmailId { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}