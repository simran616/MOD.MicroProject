using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace MOD.UserLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        UserContext context;
        public UserRepository(UserContext context)
        {
            this.context = context;
        }
        public List<Courses> SearchCourse(string criteria)
        {
            if (int.TryParse(criteria, out int result))
            {
                return (from c in context.Courses
                        where c.Id == result
                        select c).ToList();
            }

            return (from c in context.Courses
                    where c.CName.Contains(criteria)
                    select c).ToList();
        }
    }
}
