using System;

namespace CodeFirstApp.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
