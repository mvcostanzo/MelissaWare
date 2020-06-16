using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MelissaWare.Entities
{
    public partial class Classroom
    {
        [Key]
        public int ClassroomKey { get; set; }
        public string ClassroomNumber { get; set;  }
        public int ClassroomMaxStudents { get; set; }
        public string ClassroomGradeLevel { get; set; }
        public Teacher Teacher { get; set; }

    }
}
