using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ReLogic.Content;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using static Terraria.ModLoader.ModContent;
using Fargowiltas;
using AbsolutionCore.Content.NPCs.GuardianBoss;
using AbsolutionCore.Common.Systems;
using Terraria.DataStructures;
using Terraria.Audio;
using Redemption;
using Redemption.BaseExtension;
using Redemption.Globals;
using Redemption.UI;

namespace AbsolutionCore.Content.NPCs
{
    [AutoloadHead]
    public class Guardian : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian");
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = -1f,
                Direction = -1
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
                .SetNPCAffection(ModLoader.GetMod("CalamityMod").Find<ModNPC>("DILF").Type, AffectionLevel.Love)
                .SetNPCAffection(ModLoader.GetMod("CalamityMod").Find<ModNPC>("WITCH").Type, AffectionLevel.Like)
                .SetNPCAffection(ModLoader.GetMod("Fargowiltas").Find<ModNPC>("LumberJack").Type, AffectionLevel.Hate);
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 12345;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            NPC.dontTakeDamage = true;

            AnimationType = NPCID.Guide;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (AbsolutionWorld.GuardianName == "ERROR") AbsolutionWorld.GuardianName = NPC.GivenName; else NPC.GivenName = AbsolutionWorld.GuardianName;

            if (Main.drunkWorld) NPC.GivenName = "Drunn";
            if (Main.notTheBeesWorld) NPC.GivenName = "Notb";
            if (Main.getGoodWorld) NPC.GivenName = "Tworth";
            if (Main.tenthAnniversaryWorld) NPC.GivenName = "Marten";
            if (Main.dontStarveWorld) NPC.GivenName = "Cons";
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                new FlavorTextBestiaryInfoElement("While he doesn't look very old, his knowledge of history tells a different story. His age may be uncertain, but he's sure to help you thrive in this world.")
            });
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return AbsolutionWorld.GuardianFreed && !NPC.AnyNPCs(NPCType<GuardianBoss.GuardianBoss>());
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Golph",
                "Vian",
                "Omname",
                "Walt",
                "Smirl",
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
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = NPC.downedMoonlord ? 160 : (Main.hardMode ? 40 : 20);
            knockback = 4f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = NPC.downedMoonlord ? 4 : (Main.hardMode ? 7 : 10);
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.ShadowBeamFriendly;
            attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return toKingStatue;
        }
        public override string GetChat()
        {
            if (!AbsolutionWorld.GuardianGivenThanks)
            {
                AbsolutionWorld.GuardianGivenThanks = true;
                return "Hello, and thank you for freeing me from that crate. " +
                    $"You must be the Terrarian. My name is {AbsolutionWorld.GuardianName}, and I am here to guide you through this incredibly convoluted world created by you mixing multiple content mods. " +
                    "Just ask me for help if you need it.";
            }

            List<string> chat = new List<string>
            {
                "I remember a time when this world was unified. Granted, it was under a brutal dictator, so not the best of times.",
                "A jungle tyrant, a light manipulator, and a harbinger of the end of reality. It is probably bad that all of them are so powerful.",
                "I have been in this world for many, many years... since what your kind call 2011.",
                "Do you know where I could find a space kazoo?",
            };
            if(!Main.dayTime)
            {
                chat.Add("It is dark out. Do not look out into the darkness, or it will look back into you.");
            }
            if(!NPC.downedMoonlord && !AbsolutionConfig.Instance.UnboundMode)
            {
                chat.Add("What? You want to fight me? ... maybe one day.");
            }
            if (Main.hardMode)
            {
                chat.Add("I once got in the way of the Jungle Tyrant while he was still in his prime. I will let my hand show you why that is a bad idea.");
                chat.Add("I have been told that I \"look like someone's cringe edgy OC.\" Can you tell me what that means?");
            }
            if (Main.bloodMoon)
            {
                chat.Add("Ah, blood moons. I have had the misfortune of being outside during one of these many times. I may be immortal, but I can still feel pain.");
                if(!NPC.homeless) chat.Add("Considering our current circumstances, I must thank you again for this house. Those monsters are vicious.");
            }
            if (Terraria.GameContent.Events.BirthdayParty.PartyIsUp) chat.Add("I admit, I am not the first person to jump at the idea of these festivities, but I try to enjoy them before the other attendees are gone.");
            if (AbsolutionConfig.Instance.UnboundMode) chat.Add("What? You want to fight me? ... not with your current config options.");
            if (NPC.GivenName == "Updig") chat.Add("Please, do not ask me what \"updig\" is. I cannot remember the last time I went two weeks without hearing that joke.");
            return Main.rand.Next(chat);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Help";
            if(!AbsolutionConfig.Instance.UnboundMode)
            {
                if (Main.LocalPlayer.HasItem(ItemType<Items.Knowledge.TimberKnowledge>())) button = $"[c/BEFF9E:Read Knowledge]";
            }
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (Main.LocalPlayer.HasItem(ItemType<Items.Knowledge.TimberKnowledge>()))
            {
                int npc = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, NPCType<CutsceneGuardian>());
                Main.npc[npc].GivenName = AbsolutionWorld.GuardianName;
                Main.npc[npc].ai[1] = 1;
                if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc);
                NPC.life = 0;
            }

            List<string> helpChat = new();
            void AddHelp(string text, bool condition)
            {
                if (condition) helpChat.Add(text);
            }
            AddHelp("The only powerful enemy that I have seen recently is a squirrel piloting a giant wooden mechanical version of itself. Taking it down should probably be your first task.", !AbsolutionWorld.DownedTrojanSquirrel);
            if (helpChat.Count <= 0) helpChat.Add("There is nothing more that I can help you with right now. What you are doing is beyond anything that I have ever experienced. Good luck.");
            if (firstButton && Main.rand.NextBool(DateTime.Now.Year)) Main.npcChatText = "This message is lore.";
            if (firstButton) Main.npcChatText = Main.rand.Next(helpChat);
        }
    }
} 