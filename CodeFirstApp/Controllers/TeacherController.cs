using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeFirstApp.Models;
using CodeFirstApp.Services.Interfaces;
using CodeFirstApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApp.Controllers
{
    //[Authorize]
    [Route("api/student")]
    [ApiController]
    public class TeacherController : Controller
    { 
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherService teacherService,IMapper mapper)
        { 
            _teacherService = teacherService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("{id}")]

        public async Task<Teacher> GetTeacher(int id)
        {
            return await this._teacherService.GetAsync(id);
        }

        [HttpGet]
        [Route("GetAll")] 
        public async Task<IEnumerable<Teacher>> GetAllTeacher()
        { 
            return await this._teacherService.GetAllAsync();
        }

        [HttpPost]
        [Route("AddTeacherFromPerson")]

        public Teacher AddTeacher([FromForm] PersonVM person)
        {
            // Property to Property Direct Mapping
            Teacher teacher = new Teacher()
            {
                Name = person.Name,
                Age = person.Age,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                Course = "Dotnet core",
                Salary = 20000
            };

            // Using Auto Mapper

            var t = _mapper.Map<Teacher>(person);

            //var newteacher = await this._teacherService.AddAsync(teacher);
            return teacher;
        }
    }
}