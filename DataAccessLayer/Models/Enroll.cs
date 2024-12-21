using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Enroll:ModelBase
    {
        [Range(0,100)]
        public int Grade { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int OfferedCourseId { get; set; }
        public int Year { get; set; }
        public OfferedCourse OfferedCourse { get; set; }

    }
}
