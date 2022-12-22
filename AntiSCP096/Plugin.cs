using MEC;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Log = PluginAPI.Core.Log;
using Random = UnityEngine.Random;

namespace AntiSCP096
{
    public class Plugin
    {

        List<RoleTypeId> roles = new List<RoleTypeId> { RoleTypeId.Scp079,RoleTypeId.Scp049,RoleTypeId.Scp106
        ,RoleTypeId.Scp173,RoleTypeId.Scp939};

        [PluginEntryPoint("AntiSCP096","Avoid the bug of SCP096","1.0.1","X小左(XLittleLeft)")]
        void LoadPlugin()
        {
            EventManager.RegisterEvents(this);
        }

        [PluginEvent(ServerEventType.PlayerSpawn)]
        void onPlayerSpawn(Player player,RoleTypeId roleTypeId)
        {
            Timing.CallDelayed(0.5f, () =>
            {
                if (roleTypeId == RoleTypeId.Scp106)
                    roles.Remove(RoleTypeId.Scp106);
                if (roleTypeId == RoleTypeId.Scp079)
                    roles.Remove(RoleTypeId.Scp079);
                if (roleTypeId == RoleTypeId.Scp173)
                    roles.Remove(RoleTypeId.Scp173);
                if (roleTypeId == RoleTypeId.Scp939)
                    roles.Remove(RoleTypeId.Scp939);
                if (roleTypeId == RoleTypeId.Scp049)
                    roles.Remove(RoleTypeId.Scp049);
            });

            Timing.CallDelayed(2f, () =>
            {
                if (roleTypeId == RoleTypeId.Scp096)
                {
                    Log.Debug("Changed");
                    /*player.SetRole((RoleTypeId)Random.Range
                        (0, Enum.GetValues(typeof(RoleTypeId)).ToArray<RoleTypeId>().Count
                        (x => x != RoleTypeId.Scp096 && x.ToString().Contains("scp") && 
                        ReferenceHub.AllHubs.All(y => y.roleManager.CurrentRole.RoleTypeId != x))));*/
                    if (roles.Count > 0)
                    player.SetRole(Anti.GetRandom(roles));
                    else
                        player.SetRole(RoleTypeId.FacilityGuard);
                }
            });
        }

        [PluginConfig]
        public Config Config;
    }
}
