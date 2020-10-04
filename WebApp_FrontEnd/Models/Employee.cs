using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_FrontEnd.Models
{
    public class Employee
    {
        public int EID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DID { get; set; }
        public virtual Department Department { get; set; }
    }
}
