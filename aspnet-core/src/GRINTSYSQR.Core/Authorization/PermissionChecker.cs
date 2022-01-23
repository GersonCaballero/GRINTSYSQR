using Abp.Authorization;
using GRINTSYSQR.Authorization.Roles;
using GRINTSYSQR.Authorization.Users;

namespace GRINTSYSQR.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
