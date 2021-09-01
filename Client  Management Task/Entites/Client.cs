using Client__Management_Task.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client__Management_Task.Entites
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "first Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Required]
        public DateTime DateofBirth{ get; set; }
        [Required]
        [Display(Name = "Marital Status")]
        
        public string MaritalStatus { get; set; }
        [Required]
        [Display(Name ="Mobile Number")]
        public string MobileNumber { get; set; }
        [Required]
        public string  Email { get; set; }

        public string  ImagePath { get; set; }



    }
}
