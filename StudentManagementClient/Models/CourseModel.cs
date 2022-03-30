using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementClient.Models
{
	public class CourseMod
	{
		public int CourseID { get; set; }
		[Required(ErrorMessage = "This field is Required")]
		public string CourseName { get; set; }
		[Required(ErrorMessage = "This field is Required")]
		public string CourseCode { get; set; }
	}
}