using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstApp.ViewModel;
using CodeFirstApp.Models;

namespace CodeFirstApp.Helper
{
    public class CodeFirstAppProfile : Profile
    {
        public CodeFirstAppProfile()
        {
            CreateMap<PersonVM, Teacher>()
                .AfterMap((src, dst) =>
                {
                    dst.Salary = 20000;
                    dst.Course = "dotnet core";
                }
                ); 
        }
    }
}
