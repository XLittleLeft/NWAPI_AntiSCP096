using MEC;
using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using System;
using System.Linq;
using Log = PluginAPI.Core.Log;

namespace AntiSCP096
{
    public class Plugin
    {
        [PluginEntryPoint("AntiSCP096","Avoid the bug of SCP096","1.0.0","X小左(XLittleLeft)")]
        void LoadPlugin()
        {
            EventManager.RegisterEvents(this);
        }
        [PluginEvent(ServerEventType.PlayerSpawn)]
        void onPlayerSpawn(Player player,RoleTypeId roleTypeId)
        {
            Timing.CallDelayed(1f, () =>
            {
                if (roleTypeId == RoleTypeId.Scp096)
                {
                    Log.Debug("Changed");
                    player.SetRole((RoleTypeId)UnityEngine.Random.Range
                        (0, Enum.GetValues(typeof(RoleTypeId)).ToArray<RoleTypeId>().Count
                        (x => x != RoleTypeId.Scp096 && x.ToString().Contains("scp") && 
                        ReferenceHub.AllHubs.All(y => y.roleManager.CurrentRole.RoleTypeId != x))));
                }
            });
        }
        [PluginConfig]
        public Config Config;
    }
}
