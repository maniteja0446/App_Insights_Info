using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Logic.Model
{
    public class Department
    {
        [Key]
        public int DID  { get; set; }
        
        public string DepartmentName { get; set; }
    }
}
