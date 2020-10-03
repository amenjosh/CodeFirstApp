using System.Collections.Generic;

namespace CodeFirstApp.Models
{
    public class Teacher : BaseEntity
    {
        public string Course { get; set; }
        public double Salary { get; set; }   
    }
}
