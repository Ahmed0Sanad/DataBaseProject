﻿using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IEnrollRepository:IGenericRepository<Enroll>
    {
        public  List<Student> GetForCourse(int id);
    }
}
