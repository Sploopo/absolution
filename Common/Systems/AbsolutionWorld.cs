using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using FargowiltasSouls;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AbsolutionCore.Common.Systems
{
    public class AbsolutionWorld : ModSystem
    {
        public static bool GuardianFreed = false;
        public static bool GuardianGivenThanks = false;
        public static bool DownedGuardian = false;
        public static string GuardianName = "ERROR";
        public static bool GuardianMonologue = true;

        public static bool DownedShadowChamp = false;
        public static bool DownedWillChamp = false;
        public static bool DownedTrojanSquirrel = false;

        public static bool[] Knowledge = { false, false, false, false, false, false, false, false, false };

        public override void PreUpdateTime()
        {
            Player player = Main.LocalPlayer;
            if (Main.GameMode == 0)
            {
                Main.GameMode = 1;
                Main.NewText("Expert mode is now enabled!", new Color(175, 75, 255));
            }
            if (!FargoSoulsWorld.EternityMode && FargoSoulsUtil.WorldIsExpertOrHarder()) SoundEngine.PlaySound(SoundID.Roar, player.Center);
            if (!FargoSoulsUtil.AnyBossAlive() && FargoSoulsUtil.WorldIsExpertOrHarder())
            {
                FargoSoulsWorld.ShouldBeEternityMode = true;

                if (Main.netMode != NetmodeID.MultiplayerClient && FargoSoulsWorld.ShouldBeEternityMode && !FargoSoulsWorld.spawnedDevi && ModContent.TryFind("Fargowiltas", "Deviantt", out ModNPC deviantt) && !NPC.AnyNPCs(deviantt.Type))
                {
                    FargoSoulsWorld.spawnedDevi = true;

                    if (ModContent.TryFind("Fargowiltas", "SpawnProj", out ModProjectile spawnProj))
                        Projectile.NewProjectile(NPC.GetSource_NaturalSpawn(), player.Center - 1000 * Vector2.UnitY, Vector2.Zero, spawnProj.Type, 0, 0, Main.myPlayer, deviantt.Type);
                    Main.NewText("Deviantt has awoken!", new Color(175, 75, 255));
                }
            }
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData); //sync world
            if (!CalamityMod.World.CalamityWorld.revenge || !CalamityMod.World.CalamityWorld.death)
            { 
                CalamityMod.World.CalamityWorld.revenge = true;
                CalamityMod.World.CalamityWorld.death = true;
                Main.NewText("Revengeance and Death are active.", Color.MediumOrchid);
            }
        }
        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("guardianFreed", GuardianFreed);
            tag.Add("guardianGivenThanks", GuardianGivenThanks);
            tag.Add("downedGuardian", DownedGuardian);
            tag.Add("guardianName", GuardianName);
            tag.Add("guardianMonologue", GuardianMonologue);
            tag.Add("downedShadowChamp", DownedShadowChamp);
            tag.Add("downedWillChamp", DownedWillChamp);
            tag.Add("downedTrojanSquirrel", DownedTrojanSquirrel);
            
            for(int i = 0; i < Knowledge.Length; i++)
            {
                tag.Add($"knowledge{i}", Knowledge[i]);
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            GuardianFreed = tag.Get<bool>("guardianFreed");
            GuardianGivenThanks = tag.Get<bool>("guardianGivenThanks");
            DownedGuardian = tag.Get<bool>("downedGuardian");
            GuardianName = tag.Get<string>("guardianName");
            GuardianMonologue = tag.Get<bool>("guardianMonologue");
            DownedShadowChamp = tag.Get<bool>("downedShadowChamp");
            DownedWillChamp = tag.Get<bool>("downedWillChamp");
            DownedTrojanSquirrel = tag.Get<bool>("downedTrojanSquirrel");
            for (int i = 0; i < Knowledge.Length; i++)
            {
                Knowledge[i] = tag.Get<bool>($"knowledge{i}");
            }
        }
    }
}
