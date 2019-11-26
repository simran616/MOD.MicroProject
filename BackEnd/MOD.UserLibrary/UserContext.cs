using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MOD.UserLibrary
{
    public class UserContext : DbContext
    {
        public UserContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }


        //public DbSet<MODUser> MODUsers { get; set; }
        public DbSet<Courses> Courses { get; set; }


    }
}
