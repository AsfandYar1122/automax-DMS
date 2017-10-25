using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMax.Common.Enums
{
    public static class Contants
    {
        public static int DRAFT = 111;
        public static int CREATED = 222;
        public static int DELETED = 333;
        public static int CANCLED = 444;
    }

    public enum PostingSites
    {
        HARAJ,
        OPENSOUQ
    }

    public static class UserRolesConst
    {
        public static string ADMIN = "Admin";
        public static string SUPER_ADMIN = "Super Admin";
        public static string DataOP = "Data OP";
        public static string USER = "User";
        public static string Marketing = "Marketing";
        public static string Finance = "Finance";
    }
}
