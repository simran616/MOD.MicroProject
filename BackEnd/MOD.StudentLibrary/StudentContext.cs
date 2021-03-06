﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MOD.StudentLibrary
{
    public class StudentContext : IdentityDbContext
    {
        public StudentContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }


        public DbSet<MODUser> MODUsers { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<AvailableCourses> AvailableCourses { get; set; }

        public DbSet<EnrolledCourses> EnrolledCourses { get; set; }


    }
}
