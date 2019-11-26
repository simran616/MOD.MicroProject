using MOD.ModelLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.UserLibrary.Repositories
{
    public interface IUserRepository
    {
        List<Courses> SearchCourse(string criteria);
    }
}
