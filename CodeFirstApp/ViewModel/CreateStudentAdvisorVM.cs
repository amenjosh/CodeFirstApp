using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApp.ViewModel
{
    public class CreateStudentAdvisorVM
    { 
        public string StudentName { get; set; }
        public string StudentGender { get; set; }
        public int StudentAge { get; set; }
        public DateTime StudentDateOfBirth { get; set; }
        public int StudentGrade { get; set; }
        public string StudentMothersName { get; set; }  
        public string TeacherName { get; set; }
        public string TeacherGender { get; set; }
        public int TeacherAge { get; set; }
        public DateTime TeacherDateOfBirth { get; set; }

        public string Course { get; set; }

        public int Salary { get; set; }
    }
}

