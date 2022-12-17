using PlayerRoles;
using System.ComponentModel;

namespace AntiSCP096
{
    public class Config
    {
        [Description("取消生成SCP096")]
        public bool AntiSCP096 { get; set; } = true;
    }
}
