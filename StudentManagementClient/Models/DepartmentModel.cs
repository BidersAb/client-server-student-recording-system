using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementClient.Models
{
	public class DepartmentModel
	{

		public int DepartmentID { get; set; }
		[Required(ErrorMessage = "This field is Required")]
		public string DepartmentName { get; set; }
		[Required(ErrorMessage = "This field is Required")]
		public string DepartmentCode { get; set; }
	}
}