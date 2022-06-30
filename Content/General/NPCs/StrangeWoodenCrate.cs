using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using AbsolutionCore.Common.Globals;

namespace AbsolutionCore.Content.General.NPCs
{
    public class StrangeWoodenCrate : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Wooden Crate");
        }
        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.width = 44;
            NPC.height = 70;
            NPC.lifeMax = 130;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCHit7;
            NPC.knockBackResist = 0f;
            NPC.npcSlots = 0f;
        }
        
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!AbsolutionWorld.GuardianFreed && !NPC.AnyNPCs(ModContent.NPCType<StrangeWoodenCrate>())) return 0.15f;
            return 0f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.DropNothing());
        }

        public override bool CheckDead()
        {
            AbsolutionWorld.GuardianFreed = true;
            int n = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Guardian>());
            AbsolutionWorld.GuardianName = Main.npc[n].GivenName;
            return true;
        }
    }
}
