using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniPhoneBook.Models
{
    public class ContactViewModels
    {
        public int ContactId { get; set; }

        [Required]
        [RegularExpression("[0-9]*", ErrorMessage = "Please Enter Valid Contact Number ")]
        [Display(Name = "Contact #")]
        public string ContactNumber { get; set; }

        [RegularExpression("[A-Za-z]*", ErrorMessage = "Please Enter Valid Type")]
        [Required]
        public string Type { get; set; }
        public int PersonId { get; set; }

    }
}