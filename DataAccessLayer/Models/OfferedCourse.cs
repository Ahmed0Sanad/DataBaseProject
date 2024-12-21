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
    public class OfferedCourse:ModelBase
    {
        [Range(1,5)]
        public int Year { get; set; }
        [Range(1,3)]
        public int Semester { get; set; }
        public int SectionNum { get; set; }
        public TimeOnly Time { get; set; }
        public int ClassRoom { get; set; }
        [ValidateNever]
        public ICollection<Enroll> StudentCourses { get; set; } = new HashSet<Enroll>();

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        [ValidateNever]

        public Course Course { get; set; }

        [ValidateNever]
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    }
}
