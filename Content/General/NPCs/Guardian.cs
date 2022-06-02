using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using static Terraria.ModLoader.ModContent;
using AbsolutionCore.Common.Globals;

namespace AbsolutionCore.Content.General.NPCs
{
    [AutoloadHead]
    public class Guardian : ModNPC
    {
        public override string Texture => "AbsolutionCore/Assets/General/NPCs/Guardian";
        public override void SetStaticDefaults()
        {
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
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Like)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like)
                .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Dislike) // placeholder for calamitas
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

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("No one knows where exactly the Guardian came from, nor do they know what his commitment to balance entails. One thing's for certain: he's sure to help you navigate this world of content.")
            });
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return AbsolutionWorld.GuardianFreed;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Golph",
                "Fergus",
                "Vian",
                "Omname",
                "Shard",
                "Smirl",
                "Greg"
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

        public override string GetChat()
        {
            if(!AbsolutionWorld.GuardianGivenThanks && !Main.bloodMoon)
            {
                AbsolutionWorld.GuardianGivenThanks = true;
                return "Oh, hey! Thanks for freeing me from that cramped wooden structure. Sure hope I won't end up in one of those again, haha. ... Right? " +
                    $"Anyways, you must be the Terrarian. I'm {Main.npc[NPC.FindFirstNPC(NPCType<Guardian>())].GivenName} the Guardian, and I'm here to guide you through this incredibly convoluted world created by you mixing multiple content mods. " +
                    "Just ask me for help if you need it.";
            } else if(!AbsolutionWorld.GuardianGivenThanks && Main.bloodMoon)
            {
                AbsolutionWorld.GuardianGivenThanks = true;
                return "yooooooooooooooooo... btw thanks for letting me out of wood jail. i didn't like it there  . you the terrarian? well i guide you through world. ask help if need!";
            }

            List<string> chat = new List<string>
            {
                "What am I guarding, you may ask? ... I'm not entirely sure.",
                "You ever been in a Turkish prison?",
                "I remember a time when this world was unified. Granted, it was under a brutal dictator, so not the best of times.",
                "A jungle tyrant, a nightmare lord, and a bearer of the end of reality. It's probably bad that all of them are so powerful.",
                "The world is in balance. Don't do anything to change that, alright?",
                "I've been in this world for many, many years... since what your kind call 2011.",
                "Do you know where I could find a space kazoo?",
                "A friend of mine once said, \"What's your favorite color? My favorite colors are white and black.\"",
            };
            if(!Main.dayTime)
            {
                chat.Add("It's dark out. Better not look out into it, or it'll look back into you.");
            }
            if(!NPC.downedMoonlord)
            {
                chat.Add("What's that? You want to fight me? ... maybe one day.");
            }
            if(NPC.AnyNPCs(NPCID.Angler)) // erazor placeholder
            {
                chat.Add($"That {Main.npc[NPC.FindFirstNPC(NPCID.Angler)].GivenName} guy keeps saying that his daughter died 50 years ago. Well, I was there. Should I tell him that it's been a lot longer?");
            }
            if(Main.hardMode)
            {
                chat.Add("I once got in the way of the Jungle Tyrant while he was still in his prime. I'll let my left hand show you why that's a bad idea.");
            }
            if (Main.bloodMoon)
            {
                List<string> bloodChat = new List<string>();
                bloodChat.Add("yo can i get uuuuuuuuhhhhh");
                bloodChat.Add("DID YOU KNOW?");
                bloodChat.Add("how to undrunk yourself");
                bloodChat.Add("british people be like:\n\nbritish");
                bloodChat.Add("ga");
                bloodChat.Add("hi sorry i can get like this sometohimse on moon moons. moon moon moon moon moon moon mon mn m");
                bloodChat.Add($"So I had recently bought this game on Steam called \"Terraria\". I had heard the game was kind of like a 2d version of minecraft. I spawned into a world and there was this guy named {Main.npc[NPC.FindFirstNPC(NPCType<Guardian>())].GivenName} who had a bow and he killed slimes and stuff. I talked to him and seemed like a pretty cool guy.");
                return Main.rand.Next(bloodChat);
            }
            if (Main.eclipse) return "... I'm just thinking about a painting I saw once. Deep in thought.";
            return Main.rand.Next(chat);
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Help";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            List<string> helpChat = new();
            void AddHelp(string text, bool condition)
            {
                if (condition) helpChat.Add(text);
            }
            AddHelp("The evil forces of this world await! Unfortunately, all of them are protected by a squirrel piloting a giant wooden squirrel mech. If you ever want to make progress, you'll have to take it down.", true);
            AddHelp("... maybe I should take a world tour, that'll help me jog my memory.", Main.eclipse);
            AddHelp("... last time I saw it, it was going to be a Blood Moon that night.", Main.eclipse && Main.LocalPlayer.ZoneSnow);
            if (helpChat.Count <= 0) helpChat.Add("I've got nothing to help you with right now, and apparently this message is never meant to appear. You're also meant to contact the \"developers\", whoever they are. I'm also supposed to apologize for the fourth wall break."); // someone fucked up
            if (firstButton && Main.rand.NextBool(DateTime.Now.Year)) Main.npcChatText = "This message is lore.";
            if (firstButton && Main.bloodMoon) Main.npcChatText = "sorrrrrrrrrrrrrrrrry i can't help you    right now... come back later";
            if (firstButton) Main.npcChatText = Main.rand.Next(helpChat);
        }
    }
}