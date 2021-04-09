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




    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CourseRepository(ApplicationDbContext applicationDbContext) :base(applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Course> GetCourseWithAuthors(int pageIndex, int pageSize)
        {
            return _applicationDbContext
                    .Courses
                        .Include(v => v.Author)
                            .OrderBy(c=>c.Name)
                                .Skip((pageIndex-1)*pageSize)
                                    .Take(pageSize)
                                        .ToList();
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return _applicationDbContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }
    }











}