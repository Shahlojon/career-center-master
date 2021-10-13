using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCenter.Core.Permissions
{
    public static class BasicPermissions
    {
        public static string Admin = nameof(Admin);
        public static string Moderator = nameof(Moderator);
        public static string Student = nameof(Student);
        public static string Teacher = nameof(Teacher);
        public static string Partner = nameof(Partner);
    }
}
