using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using static Terraria.ModLoader.ModContent;


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
                .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like); // placeholder for calamitas
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
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
            return NPC.downedSlimeKing;
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
                "???",
                "Greg"
            };
        }

        public override string GetChat()
        {
            List<string> chat = new List<string>
            {
                "What am I guarding, you may ask? ... I'm not entirely sure.",
                "You ever been in a Turkish prison?",
                "I remember a time when this world was unified. Granted, it was under a brutal dictator, so not the best of times.",
                "A jungle tyrant, a nightmare lord, and a bearer of the end of reality. It's probably bad that all of them are so powerful.",
                "The world is in balance. Don't do anything to change that, alright?",
                "I've been in this world for many, many years... since what your kind call 2011.",
                "Do you know where I could find a space kazoo?",
                "A friend of mine once said, \"What's your favorite color? My favorite colors are white and black.\""
            };
            if (Main.hardMode) chat.Add("I'm going to warn you... I've been told I act a little weird during solar eclipses. Just watch out for that, okay?");

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
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Help";
        }

        public List<string> helpChat = new List<string>
        {
            "... maybe I should take a world tour, that'll help me jog my memory.",
            "... last time I saw it, it was going to be a Blood Moon that night."
        };

/*        public void AddHelp(string message, bool condition)
        {
            if (condition) helpChat.Add(message);
        }
        public string GetHelp()
        {
            if (Main.eclipse)
            {
                AddHelp("... maybe I should take a world tour, that'll help me jog my memory.", Main.rand.NextBool(3));
                AddHelp("... last time I saw it, it was going to be a Blood Moon that night.", Main.LocalPlayer.ZoneJungle);
                AddHelp("... there were a lot of sunflowers around it. Made me happy. It was a great time.", Main.LocalPlayer.ZoneBeach);
                AddHelp($"... someone who looked like {Main.npc[NPC.FindFirstNPC(NPCID.Painter)]} was there. Could he have... taken it or something? He's gotta be dead now, though.", (Main.LocalPlayer.ZoneCorrupt || Main.LocalPlayer.ZoneCrimson) && NPC.AnyNPCs(NPCID.Painter));
                AddHelp("... right. They had it in the capital of the Underworld. Before the... incident.", Main.LocalPlayer.Center.Y >= Main.rockLayer);
                AddHelp("... think I had to leave because of that giant space worm thing attacking the place. Not sure how they got that under control.", Main.LocalPlayer.ZoneDesert);
                AddHelp("... what was I wearing? Think it was some black lunar-themed shirt and a big red thing on my back, also pretty lunar.", Main.LocalPlayer.ZoneNormalSpace);
                AddHelp("... how many people did I have with me? Five? Yeah, I think it was five.", Main.LocalPlayer.ZoneForest);
                AddHelp("... huh, my mind's drawing a blank.", true);
                return Main.rand.Next(helpChat);
            }

            return Main.rand.Next(helpChat);
        }*/

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton) shop = true; else Main.npcChatText = Main.rand.Next(helpChat);
        }
    }
}
