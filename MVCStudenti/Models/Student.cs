using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCStudenti.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name ="Ime studenta")]
        [Required]
        public string StudentName { get; set; }
        [Range(5,50)]
        public int Age { get; set; }
    }
}