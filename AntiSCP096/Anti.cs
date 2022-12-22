using PlayerRoles;
using System;
using System.Collections.Generic;

namespace AntiSCP096
{
    public class Anti
    {
        public static RoleTypeId GetRandom(List<RoleTypeId> roleTypeIds)
        {
            Random random = new Random();
            int index = random.Next(roleTypeIds.Count);
            return roleTypeIds[index];
        }
    }
}
