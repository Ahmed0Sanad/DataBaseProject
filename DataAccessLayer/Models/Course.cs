using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Course:ModelBase
    {
        public string Syllabus { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public ICollection<OfferedCourse> OfferedCourses { get; set; } = new HashSet<OfferedCourse>();
        [ValidateNever]
        public ICollection<Prequestes> Prerequisites { get; set; }= new HashSet<Prequestes>();
        [ValidateNever]
        public ICollection<Prequestes> IsPrerequisiteFor { get; set; }=new HashSet<Prequestes>();
    }
}
