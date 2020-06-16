using MelissaWare.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MelissaWare.Context
{
    public partial class MelissaWareDBContext: DbContext
    {
        public MelissaWareDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public MelissaWareDBContext()
        {
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = ClassroomAssignment; Trusted_Connection = True;");
        }

        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Student> Students { get; set; }
    }
}
