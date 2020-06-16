using System;
using System.Collections.Generic;
using System.Text;

namespace MelissaWare.Entities
{
    public class Student
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int StudentKey { get; set; }
        public string StudentName { get; set; }
        public char Gender { get; set; }

        public Classroom Classroom { get; set; }
    }
}
