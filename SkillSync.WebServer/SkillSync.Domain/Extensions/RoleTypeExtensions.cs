using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.Role;

namespace SkillSync.Domain.Extensions
{
    public static class RoleTypeExtensions
    {
        public static string ToString(this RoleType role)
        {
            switch (role)
            {
                case RoleType.Administrator:
                    return "Admin";
                case RoleType.Freelancer:
                    return "Freelancer";
                case RoleType.SkillScout:
                    return "SkillScout";
                default:
                    throw new InvalidRoleException();
            }
        }

        public static RoleType ToRoleType(this string role)
        {
            return role switch
            {
                "Admin" => RoleType.Administrator,
                "Freelancer" => RoleType.Freelancer,
                "SkillScout" => RoleType.SkillScout,
                _ => throw new InvalidRoleException()
            };
        }
    }
}