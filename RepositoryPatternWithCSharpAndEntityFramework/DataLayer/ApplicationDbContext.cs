using RepositoryPatternWithCSharpAndEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepositoryPatternWithCSharpAndEntityFramework.DataLayer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("name=ApplicationDbContext")
        {

        }
        public virtual DbSet<Course> Courses{ get; set; }

        public virtual DbSet<Author> Authors { get; set; }
    }
}