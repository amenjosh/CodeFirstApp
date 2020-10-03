using CodeFirstApp.Models;
using CodeFirstApp.Services.Interfaces;
using CodeFirstApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApp.Controllers
{
    //[Authorize]
    [Route("api/student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public StudentController(IStudentService studentService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
        }

         
        [HttpGet]
        [Route("GetAll")]

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await this._studentService.GetAllAsync();
        }

         
        [HttpGet]
        [Route("{id}")]

        public async Task<Student> GetStudent(int id)
        {
            return await this._studentService.GetAsync(id);
        }

         
        [HttpPost]
        [Route("AddStudent")]

        public async Task<Student> AddStudent([FromForm] CreateStudentAdvisorVM studentAdvisor)
        {
            Teacher teacher = new Teacher()
            {
                Name = studentAdvisor.TeacherName,
                Age = studentAdvisor.TeacherAge,
                Course = studentAdvisor.Course,
                DateOfBirth = studentAdvisor.TeacherDateOfBirth,
                Salary = studentAdvisor.Salary,
                Gender = studentAdvisor.TeacherGender
            };

            var newteacher = this._teacherService.AddAsync(teacher);
            Student student = new Student()
            {
                Name = studentAdvisor.StudentName,
                Age = studentAdvisor.StudentAge,
                DateOfBirth = studentAdvisor.StudentDateOfBirth,
                Gender = studentAdvisor.StudentGender,
                Grade = studentAdvisor.StudentGrade,
                MothersName = studentAdvisor.StudentMothersName,
                TeacherID = newteacher.Id
            }; 

            try
            { 
                await this._studentService.AddAsync(student);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return student;
        }
         
        [HttpPost]
        [Route("AddTeacherWithMultipleStudent")]

        public Teacher AddTeacherWithMultipleStudent([FromBody] CreateTeacherWithMultipleStudents studentAdvisor)
        {
            Teacher teacher = new Teacher()
            {
                Name = studentAdvisor.Teacher.Name,
                Course = studentAdvisor.Teacher.Course,
                Age = studentAdvisor.Teacher.Age,
                DateOfBirth = studentAdvisor.Teacher.DateOfBirth,
                Gender = studentAdvisor.Teacher.Gender,
                Salary = studentAdvisor.Teacher.Salary
            };

            var newteacher = this._teacherService.AddAsync(teacher);
            int teacherID = newteacher.Id;

            foreach (Student st in studentAdvisor.Students)
            {
                Student student = new Student()
                {
                    Name = st.Name,
                    Age = st.Age,
                    DateOfBirth = st.DateOfBirth,
                    Gender = st.Gender,
                    Grade = st.Grade,
                    MothersName = st.MothersName,
                    TeacherID = teacherID
                };
            }
            return teacher;

        }

    }
}
