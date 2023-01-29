using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace AbsolutionCore
{
    class AbsolutionConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static AbsolutionConfig Instance => ModContent.GetInstance<AbsolutionConfig>();

        private const string ModName = "AbsolutionCore";

        [Label($"$Mods.{ModName}.Config.UnboundMode")]
        [Tooltip($"$Mods.{ModName}.Config.UnboundModeDesc")]
        [ReloadRequired]
        [DefaultValue(false)]
        public bool UnboundMode;

        [Label($"$Mods.{ModName}.Config.WingSlotWarning")]
        [DefaultValue(true)]
        public bool WingSlotWarning;
    }
}
