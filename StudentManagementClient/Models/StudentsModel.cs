using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementClient.Models
{
	public class StudentsModel
	{
     
        public int StudentID { get; set; }
           [Required(ErrorMessage ="This field is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Semester { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Year { get; set; }

        public string Email { get; set; }
       
        public string PhoneNember { get; set; }
        public DateTime Date { get; set; }
    }
}