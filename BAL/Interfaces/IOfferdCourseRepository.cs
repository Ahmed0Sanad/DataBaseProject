﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IOfferdCourseRepository:IGenericRepository<OfferedCourse>
    {
        public  OfferedCourse GetWithYear(int id, int year);
    }
    
}