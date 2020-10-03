namespace CodeFirstApp.Models
{
    public class Student : BaseEntity
    {
        public int Grade { get; set; }

        public string MothersName { get; set; }

        public int? TeacherID { get; set; } 

        public Teacher Teacher { get; set; }

    }
}
