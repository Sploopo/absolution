using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.Tiles;
using Terraria.GameContent.Personalities;
using CalamityMod.World;
using FargowiltasSouls;
using AbsolutionCore.Content.NPCs;
using AbsolutionCore.Common.Systems;
using FargowiltasSouls.Toggler;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        int guardianType = ModContent.NPCType<Guardian>();
        public override void SetDefaults(NPC npc)
        {
            base.SetDefaults(npc);
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            int g = NPC.FindFirstNPC(guardianType);
            if (npc.type == ModLoader.GetMod("CalamityMod").Find<ModNPC>("WITCH").Type)
            {
                if (Main.rand.NextBool(16) && NPC.AnyNPCs(ModContent.NPCType<Guardian>())) chat = Main.npc[g].GivenName + " has not changed a bit even after all these years... so those rumors about immortality were true.";
            }
        }

        public override void OnKill(NPC npc)
        {
            if(npc.type == ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("ShadowChampion").Type)
            {
                NPC.SetEventFlagCleared(ref AbsolutionWorld.DownedShadowChamp, -1);
            } else if(npc.type == ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("WillChampion").Type)
            {
                NPC.SetEventFlagCleared(ref AbsolutionWorld.DownedWillChamp, -1);
            } else if(npc.type == ModLoader.GetMod("FargowiltasSouls").Find<ModNPC>("TrojanSquirrel").Type)
            {
                NPC.SetEventFlagCleared(ref AbsolutionWorld.DownedTrojanSquirrel, -1);
            } else if(npc.type == ModLoader.GetMod("CalamityMod").Find<ModNPC>("PhantomSpirit").Type && !AbsolutionConfig.Instance.UnboundMode)
            {
                CalamityMod.CalamityMod.ghostKillCount--;
            }
        }

        public override void PostAI(NPC npc)
        {
            switch(npc.type)
            {
                case NPCID.VoodooDemon:
                    if (!FargoSoulsWorld.downedDevi && !AbsolutionConfig.Instance.UnboundMode) npc.life = 0;
                    break;
                default:
                    break;
            }
            if(npc.type == ModLoader.GetMod("CalamityMod").Find<ModNPC>("OldDuke").Type || npc.type == ModLoader.GetMod("CalamityMod").Find<ModNPC>("StormWeaverHead").Type) // perma rain during old duke/storm weaver
            {
                if (!Main.raining || Main.maxRaining < 0.7f)
                {
                    CalamityMod.CalamityUtils.StartRain(false, true);
                    Main.cloudBGActive = 1f;
                    Main.numCloudsTemp = 160;
                    Main.numClouds = Main.numCloudsTemp;
                    if(npc.type == ModLoader.GetMod("CalamityMod").Find<ModNPC>("StormWeaverHead").Type) // ALSO thunderstorm during storm weaver
                    {
                        Main.windSpeedCurrent = 1.04f;
                        Main.windSpeedTarget = Main.windSpeedCurrent;
                    }
                    Main.maxRaining = 0.96f;
                }
            }
            // kill true eyes during providence
            Toggle t = Main.player[Main.myPlayer].GetModPlayer<FargoSoulsPlayer>().Toggler.Toggles["MasoTrueEye"];
            if (npc.type == ModContent.NPCType<CalamityMod.NPCs.Providence.Providence>() && (Main.player[Main.myPlayer].GetModPlayer<FargoSoulsPlayer>().MutantPresence ? false : t.ToggleBool))
            {
                SoulCheck.SetToggleValue(Main.player[Main.myPlayer], "MasoTrueEye", false);
                Main.NewText("The True Eyes of Cthulhu left due to Providence's presence!", 255, 33, 0);
            }
        }
    }
}
