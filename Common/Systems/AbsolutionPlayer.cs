using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CalamityMod.CalPlayer;
using CalamityMod;
using Microsoft.Xna.Framework;

namespace AbsolutionCore.Common.Systems
{
    public class AbsolutionPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            if (Main.GameMode == 3) CalamityUtils.DisplayLocalizedText("Mods.AbsolutionCore.JourneyModeMessage", Main.creativeModeColor);
            if (ModLoader.TryGetMod("WingSlotExtra", out Mod bad) && AbsolutionConfig.Instance.WingSlotWarning)
            {
                CalamityUtils.DisplayLocalizedText("Mods.AbsolutionCore.WingSlotWarning1", Color.LightSkyBlue);
                CalamityUtils.DisplayLocalizedText("Mods.AbsolutionCore.WingSlotWarning2", Color.LightSkyBlue);
            }
        }
    }
}
