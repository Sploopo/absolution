using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using AbsolutionCore.Common.Systems;
using Terraria.GameContent.Bestiary;

namespace AbsolutionCore.Content.NPCs
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

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("An exquisite-looking box of truly admirable quality, although the reason why a person was trapped inside is unknown.")
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!AbsolutionWorld.GuardianFreed && !NPC.AnyNPCs(ModContent.NPCType<StrangeWoodenCrate>())) return 0.075f;
            return 0f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.DropNothing());
        }

        public override bool CheckDead()
        {
            AbsolutionWorld.GuardianFreed = true;
            int n = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CutsceneGuardian>());
            List<string> names = new List<string>()
            {
                "Golph",
                "Vian",
                "Omname",
                "Walt",
                "Smirl",
                "John",
                "Greg",
                "Drunn",
                "Notb",
                "Tworth",
                "Marten",
                "Cons",
                "Trapp",
                "Updig",
                "Gefix"
            };
            AbsolutionWorld.GuardianName = Main.rand.Next(names);
            Main.npc[n].ai[1] = 0;
            return true;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }

            if (NPC.life <= 0)
            {
                int gore1 = Mod.Find<ModGore>("CrateGore1").Type;
                int gore2 = Mod.Find<ModGore>("CrateGore2").Type;
                int gore3 = Mod.Find<ModGore>("CrateGore3").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), gore1);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), gore2);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), gore3);
                }
            }
        }
    }
}
