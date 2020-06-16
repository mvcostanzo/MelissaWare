using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MelissaWare.Entities
{
    public partial class Teacher
    {
        [Key]
        public int TeacherKey { get; set; }
        public string TeacherName { get; set; }
        public List<Classroom> Classrooms { get; set; }
    }
}
