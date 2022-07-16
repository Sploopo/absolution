using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.General.Tiles;
using Terraria.GameContent.Personalities;
using CalamityMod.World;
using FargowiltasSouls;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public override void SetStaticDefaults()
        {
            int guardianType = ModContent.NPCType<Content.General.NPCs.Guardian>();

            NPCHappiness.Get(ModLoader.GetMod("CalamityMod").Find<ModNPC>("WITCH").Type).SetNPCAffection(guardianType, AffectionLevel.Like);
            NPCHappiness.Get(ModLoader.GetMod("Fargowiltas").Find<ModNPC>("Mutant").Type).SetNPCAffection(guardianType, AffectionLevel.Like);
            NPCHappiness.Get(ModLoader.GetMod("Fargowiltas").Find<ModNPC>("Abominationn").Type).SetNPCAffection(guardianType, AffectionLevel.Like);
            NPCHappiness.Get(ModLoader.GetMod("Fargowiltas").Find<ModNPC>("Deviantt").Type).SetNPCAffection(guardianType, AffectionLevel.Like);
        }
        public override void SetDefaults(NPC npc)
        {
            base.SetDefaults(npc);
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
            } else if(npc.type == ModLoader.GetMod("CalamityMod").Find<ModNPC>("PhantomSpirit").Type)
            {
                CalamityMod.CalamityMod.ghostKillCount--;
            }
            switch(npc.type)
            {
                case NPCID.KingSlime:
                case NPCID.EyeofCthulhu:
                case NPCID.EaterofWorldsHead:
                case NPCID.BrainofCthulhu:
                case NPCID.QueenBee:
                case NPCID.SkeletronHead:
                case NPCID.Deerclops:
                case NPCID.WallofFlesh:
                case NPCID.QueenSlimeBoss:
                case NPCID.TheDestroyer:
                case NPCID.Spazmatism: // no retinazer because things break otherwise
                case NPCID.SkeletronPrime:
                case NPCID.Plantera:
                case NPCID.Golem:
                case NPCID.HallowBoss:
                case NPCID.DukeFishron:
                case NPCID.CultistBoss:
                case NPCID.MoonLordCore:
                    CalamityWorld.revenge = true;
                    CalamityWorld.death = true;
                    if (FargoSoulsWorld.MasochistModeReal) CalamityWorld.malice = true;
                    break;
                default:
                    break;
            }
            base.OnKill(npc);
        }
        public override void PostAI(NPC npc)
        {
            switch(npc.type)
            {
                case NPCID.KingSlime:
                case NPCID.EyeofCthulhu:
                case NPCID.EaterofWorldsHead:
                case NPCID.BrainofCthulhu:
                case NPCID.QueenBee:
                case NPCID.SkeletronHead:
                case NPCID.Deerclops:
                case NPCID.WallofFlesh:
                case NPCID.QueenSlimeBoss:
                case NPCID.TheDestroyer:
                case NPCID.Retinazer:
                case NPCID.Spazmatism:
                case NPCID.SkeletronPrime:
                case NPCID.Plantera:
                case NPCID.Golem:
                case NPCID.HallowBoss:
                case NPCID.DukeFishron:
                case NPCID.CultistBoss:
                case NPCID.MoonLordCore:
                    CalamityWorld.revenge = false;
                    CalamityWorld.death = false;
                    CalamityWorld.malice = false;
                    break;
                default:
                    break;
            }
        }
    }
}
