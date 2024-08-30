using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SignUp.Models
{
    public class Signup
    {
        [Display(Name = "User ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "DOB is required.")]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "email is required.")]
        [Display(Name = "email")]
        public string email { get; set; }

        [Required(ErrorMessage = "address is required.")]
        [Display(Name = "address")]
        public string address { get; set; }

        [Required(ErrorMessage = "password is required.")]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}