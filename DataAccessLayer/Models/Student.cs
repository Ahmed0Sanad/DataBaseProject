using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public  class Student:Person
    {
        [Range(1,5)]
        public int Year { get; set; }
        //public Program StudentProgram { get; set; }
        [ValidateNever]
        public ICollection<Enroll> StudentCourses { get; set; }=new HashSet<Enroll>();
    }
    //public enum Program { cridet,Vip,Free}
}
