using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using FargowiltasSouls;

namespace AbsolutionCore.Content.Buffs
{
    public class GuardianPresence : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Champion's Presence");
            Description.SetDefault("Defense, damage reduction, and life regen reduced; dodges and Supersonic Soul disabled; effects of Chaos State");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Terraria.ID.BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<FargoSoulsPlayer>().noDodge = true;
            player.GetModPlayer<FargoSoulsPlayer>().noSupersonic = true;
            player.chaosState = true;
            player.bleed = true;
            player.statDefense = (int)(player.statDefense * 0.75);
            player.endurance -= 0.3f;
        }
    }
}
