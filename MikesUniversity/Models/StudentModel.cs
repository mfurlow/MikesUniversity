using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MikesUniversity.Models
{
    public class StudentModel
    {
        public int Studentid { get; set; }
        [Required(ErrorMessage = "Please enter your  first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Pword { get; set; }
        [Required(ErrorMessage = "Please enter your MajorId")]
        public string MajorId { get; set; }

        [Required(ErrorMessage = "Please select student or administrator")]
        public bool? accType { get; set; }
    } 
}