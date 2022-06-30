using Microsoft.Xna.Framework;
using FargowiltasSouls;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Audio;

namespace AbsolutionCore.Content.General.Items
{
    public class SSOTSOTCMG : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Satanic Scepter of the Sigil of the Corrupted Mutant's Gift");
            Tooltip.SetDefault("Permanently enables Expert, Eternity, Death and True Mode\nDoes not enable Expert in Journey Mode\nCannot be used while a boss is alive");
        }

        public override void SetDefaults()
        {
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            if (!FargoSoulsUtil.AnyBossAlive())
            {
                if(Main.GameMode != 3) Main.GameMode = 1;
                FargoSoulsWorld.ShouldBeEternityMode = true;

                if (Main.netMode != NetmodeID.MultiplayerClient && FargoSoulsWorld.ShouldBeEternityMode && !FargoSoulsWorld.spawnedDevi
                    && ModContent.TryFind("Fargowiltas", "Deviantt", out ModNPC deviantt) && !NPC.AnyNPCs(deviantt.Type))
                {
                    FargoSoulsWorld.spawnedDevi = true;

                    if (ModContent.TryFind("Fargowiltas", "SpawnProj", out ModProjectile spawnProj)) {
                        Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.Center - 1000 * Vector2.UnitY, Vector2.Zero, spawnProj.Type, 0, 0, Main.myPlayer, deviantt.Type);
                        FargoSoulsUtil.PrintLocalization("Deviantt has awoken!", new Color(175, 75, 255));
                    }

                    SoundEngine.PlaySound(SoundID.Zombie92, player.Center);

                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData); //sync world
                }
            }
            return true;
        }
    }
}
