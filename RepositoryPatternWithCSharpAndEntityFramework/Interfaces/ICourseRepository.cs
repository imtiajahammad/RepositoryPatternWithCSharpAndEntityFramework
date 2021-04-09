using RepositoryPatternWithCSharpAndEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithCSharpAndEntityFramework.Interfaces
{





    public interface ICourseRepository:IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCourseWithAuthors(int pageIndex, int pageSize);
    }








}
