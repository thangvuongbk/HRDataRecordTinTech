using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HRDataRecordTinTech.Models
{
    public class Employee
    {      
        [Key]              
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Number is required")]
        //[Range(00000, 99999, ErrorMessage = "Employee Id should be of 5 digits.")]
        [DisplayName("Employee Number")]       
        public string EmployeeNumber { get; set; }

        [Required(ErrorMessage = "Employee ID is required")]
        [Range(000000000, 999999999, ErrorMessage = "Employee Id should be of 9 digits only.")]
        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        //[StringLength(30)]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name cannot contain numbers or special characters.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
      

        [Required(ErrorMessage = "Phone is required")]
        [Range(0000000000, 9999999999, ErrorMessage = "Phone no. is not valid")]
        [DataType(DataType.PhoneNumber)]
        //public Nullable<long> Phone { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email address is required")]        
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail address is not valid")]
        [DisplayName("Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Position is required")]       
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Position cannot contain numbers or special characters.")]
        public string Position { get; set; }
       
        [Range(0, 99999999999, ErrorMessage = "Salary is not within range.")]
        public Nullable<long> Salary { get; set; }

        [DisplayName("TOEIC")]
        public bool bTOEIC { get; set; }
        public bool bEducation { get; set; }
        public bool bJapanese { get; set; }
    }


}
