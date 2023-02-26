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
using Redemption.Globals;

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
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
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
            List<string> funnyWords = new List<string>()
            {
                "kazoos are",
                "whips are",
                "consumable boss summons are",
                "cryonic ore is",
                "the Daedalus Stormbow is",
                "mods are",
                "perpetual war is",
                "bees are",
                "elections are",
                "boiling alive in lava is",
                "magic mirrors are",
                "Valentine's Day is",
                "vandalism is",
                "cardiac arrest is",
                "thought experiments are",
                "lore is",
                "the Jungle is",
                "secret seeds are",
            };
            string comedy = Main.rand.Next(funnyWords);
            List<string> chat = new List<string>
            {
                "I have been in this world for many, many years... since what you might call \"2011\".",
                "Do you know where I could find a space kazoo?",
                "A lot of people are saying that they get their information today from somewhere known as \"the Internet\". Forgive me for asking, but do you know where that is?",
                $"It has been a while since I effectively kept up with the times. You seem young, do you know if {comedy} still popular?",
                $"It has been a while since I effectively kept up with the times. You seem young, do you know if {comedy} still popular?", // added twice because FUCK unifiedrandom
                "I do not consider myself too happy with the gods, but attempting to kill them all just seems absurd.",
                "Have you seen those chickens? They used to be part of one, united kingdom. That all fell apart when the king disappeared.",
                "Did you know? If you cover yourself in thorium, you may undergo radioactive decay!",
                "In the beginning, four beings from beyond this realm created the gods. Some say their incarnations roam our towns or show up as pets to this day.",
                "What exactly is an \"early game desert boss\"?",
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
                chat.Add("There was a time where I had enough hubris to challenge the Godseeker to a duel. I will let my hand show you why that is a bad idea.");
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