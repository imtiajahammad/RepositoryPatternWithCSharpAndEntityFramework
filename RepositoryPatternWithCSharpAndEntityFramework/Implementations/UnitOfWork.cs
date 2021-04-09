using RepositoryPatternWithCSharpAndEntityFramework.DataLayer;
using RepositoryPatternWithCSharpAndEntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryPatternWithCSharpAndEntityFramework.Implementations
{







    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
            Courses = new CourseRepository(applicationDbContext);
            Authors = new AuthorRepository(applicationDbContext);
        }
        public bool Complete()
        {
            try
            {
                int resutl=_applicationDbContext.SaveChanges();
                if (resutl > 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }













}