using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Instructor:Person
    {
  
        public int Salary { get; set; }
        [ValidateNever]
        public ICollection<OfferedCourse> OfferedCourses { get; set; }=new HashSet<OfferedCourse>();
    }
}
