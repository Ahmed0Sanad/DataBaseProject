﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Prequestes
    {
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey(nameof(Prerequisit))]

        public int PrerequisitId { get; set; }
        public Course Prerequisit { get; set; }
    }
}
