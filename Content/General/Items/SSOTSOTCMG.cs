using Microsoft.Xna.Framework;
using FargowiltasSouls;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Audio;
using CalamityMod.World;
using AbsolutionCore.Common.Systems;
using System.Collections.Generic;

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
            Item.width = 38;
            Item.height = 86;
            Item.maxStack = 1;
            Item.noMelee = true;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Zombie92;
            Item.rare = ItemRarityID.Master;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            if (!FargoSoulsUtil.AnyBossAlive())
            {
                if(Main.GameMode != 3) Main.GameMode = 1;
                FargoSoulsWorld.ShouldBeEternityMode = true;
                CalamityWorld.revenge = true;
                CalamityWorld.death = true;

                if (Main.netMode != NetmodeID.MultiplayerClient && FargoSoulsWorld.ShouldBeEternityMode && !FargoSoulsWorld.spawnedDevi
                    && ModContent.TryFind("Fargowiltas", "Deviantt", out ModNPC deviantt) && !NPC.AnyNPCs(deviantt.Type))
                {
                    FargoSoulsWorld.spawnedDevi = true;

                    if (ModContent.TryFind("Fargowiltas", "SpawnProj", out ModProjectile spawnProj)) {
                        Projectile.NewProjectile(player.GetSource_ItemUse(Item), player.Center - 1000 * Vector2.UnitY, Vector2.Zero, spawnProj.Type, 0, 0, Main.myPlayer, deviantt.Type);
                        Main.NewText("Deviantt has awoken!", new Color(175, 75, 255));
                    }

                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.WorldData); //sync world
                }
                Main.NewText("Revengeance is active.", new Color(220, 20, 60));
                Main.NewText("Death is active, enjoy the fun.", new Color(220, 20, 60));
                AbsolutionWorld.UsedSSOTSOTCMG = true;
            }
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Color[] specialColors = { new Color(211, 53, 53), new Color(167, 38, 229) };

            foreach (TooltipLine line2 in tooltips)
            {
                if (line2.Mod == "Terraria" && line2.Name == "ItemName")
                {
                    float fade = (Main.GameUpdateCount % 60) / 60f;
                    int index = (int)((Main.GameUpdateCount / 60) % 2);
                    int nextIndex = (index + 1) % 2;

                    line2.OverrideColor = Color.Lerp(specialColors[index], specialColors[nextIndex], fade);
                }
            }
        }
    }
}
