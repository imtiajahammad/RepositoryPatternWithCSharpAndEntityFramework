using RepositoryPatternWithCSharpAndEntityFramework.DataLayer;
using RepositoryPatternWithCSharpAndEntityFramework.Interfaces;
using RepositoryPatternWithCSharpAndEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace RepositoryPatternWithCSharpAndEntityFramework.Implementations
{










    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AuthorRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public Author GetAuthorWithCourses(int id)
        {
            return _applicationDbContext.Authors.Where(a => a.Id == id)
                        .Include(i=>i.Courses)
                                .FirstOrDefault();
        }
    }


















}