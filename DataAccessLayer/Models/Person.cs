using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Person:ModelBase
    {

        [Range(15,65)]
        public int Age { get; set; }
        
        public DateOnly Birth { get; set; }
        public DateTime CreationDate { get; set; }= DateTime.Now;
        public string Name { get; set; }
        
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }

    }
}
