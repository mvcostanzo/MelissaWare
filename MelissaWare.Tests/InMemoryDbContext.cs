using MelissaWare.Context;
using MelissaWare.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MelissaWare.Tests
{
    class InMemoryDbContext : MelissaWareDBContext
    {
        public InMemoryDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected InMemoryDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MelissaWareUnitTestDB");
        }
    }
}
