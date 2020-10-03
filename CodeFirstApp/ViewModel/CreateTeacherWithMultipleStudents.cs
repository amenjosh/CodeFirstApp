using CodeFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApp.ViewModel
{
    public class CreateTeacherWithMultipleStudents
    {
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
