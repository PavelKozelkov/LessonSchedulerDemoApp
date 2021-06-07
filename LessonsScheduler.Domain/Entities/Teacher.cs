using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsScheduler.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
    }
}
