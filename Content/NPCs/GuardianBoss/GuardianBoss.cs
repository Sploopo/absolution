using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ReLogic.Content;
using ReLogic.Graphics;
using FargowiltasSouls;
using AbsolutionCore.Common.Systems;
using AbsolutionCore.Content.Items;
using AbsolutionCore.Content.Buffs;
using Redemption;
using Redemption.BaseExtension;
using Redemption.Globals;
using Redemption.UI;
using System.IO;

namespace AbsolutionCore.Content.NPCs.GuardianBoss
{
    [AutoloadBossHead]
    public class GuardianBoss : ModNPC
    {
        public bool playerInvulTriggered = false;
        public bool doneWithStartAnim = false;
        public int exhausted = 1;

        public Vector2 targetPos;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Champion of Terraria");

            Main.npcFrameCount[NPC.type] = 6;
            NPCID.Sets.NoMultiplayerSmoothingByType[NPC.type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(NPC.type);
            NPCID.Sets.DebuffImmunitySets.Add(NPC.type, new Terraria.DataStructures.NPCDebuffImmunityData
            {
                ImmuneToAllBuffsThatAreNotWhips = true
            });
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Though immortality is his only power, infinite time grants infinite potential. His title is a misnomer, as championhood was recently passed down.")
            });
        }

        public override void SetDefaults()
        {
            NPC.width = 120;
            NPC.height = 120;
            NPC.damage = 45;
            NPC.defense = 220;
            NPC.lifeMax = 400000;
            NPC.value = Item.buyPrice(3);
            NPC.HitSound = SoundID.NPCHit1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.aiStyle = -1;
            NPC.timeLeft = NPC.activeTime * 30;

            Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/depot");
            SceneEffectPriority = SceneEffectPriority.BossHigh;
        }
        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            damage *= exhausted == 1 ? 0.8f : 0.25f;
            return true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.damage = (int)(NPC.damage * 0.5f);
            NPC.lifeMax = (int)(NPC.lifeMax * bossLifeScale);
        }

        public override void FindFrame(int frameHeight)
        {
            if (exhausted == 1 ? ++NPC.frameCounter > 6 : ++NPC.frameCounter > 2)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                    NPC.frame.Y = 0;
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(exhausted);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            exhausted = (int) reader.ReadSingle();
        }

        public override bool CanHitPlayer(Player target, ref int CooldownSlot)
        {
            return false;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }

        // ai
        public override void AI()
        {
            NPC.TargetClosest();

            Player player = Main.player[NPC.target];
            if((!player.active || player.dead || Vector2.Distance(NPC.Center, player.Center) > 2400f) && NPC.ai[0] != -3) {
                NPC.TargetClosest(false);
                if (NPC.timeLeft > 30) NPC.timeLeft = 30;
                NPC.velocity.Y += 0.3f;
                if(NPC.timeLeft < 5)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        if (ModContent.TryFind("AbsolutionCore", "Guardian", out ModNPC m) && !NPC.AnyNPCs(m.Type))
                        {
                            int n = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, m.Type);
                            if (n != Main.maxNPCs)
                            {
                                Main.npc[n].homeless = true;
                                Main.npc[n].GivenName = AbsolutionWorld.GuardianName;
                                if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, n);
                            }
                        }
                    }
                    NPC.life = 0;
                    NPC.dontTakeDamage = false;
                    for (int i = 0; i < 50; i++)
                    {
                        int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Shadowflame, 0f, 0f, 0, default(Color), 4f);
                        Main.dust[d].noGravity = true;
                        Main.dust[d].velocity *= 3f;
                    }
                }
            }
            NPC.direction = NPC.spriteDirection = Math.Sign(player.Center.X - NPC.Center.X);
            if(doneWithStartAnim) Main.time = 16200;
            if (player.immune || player.hurtCooldowns[0] != 0 || player.hurtCooldowns[1] != 0) playerInvulTriggered = true;
            if (!doneWithStartAnim) NPC.ai[0] = -3;

            Texture2D bubble = ModContent.Request<Texture2D>("AbsolutionCore/Assets/Textures/TextBubble_Guardian", (AssetRequestMode)2).Value;
            SoundStyle voice2 = CustomSounds.Voice4;
            voice2.Pitch = -0.4f;
            SoundStyle voice = voice2;

            if(NPC.ai[0] >= 0 && !Main.dedServ)
            {
                targetPos = player.Center + NPC.DirectionFrom(player.Center) * 300f;
                if (NPC.Distance(targetPos) > 50) MoveTo(targetPos, 0.23f, 26f);
                if (Main.player[Main.myPlayer].active && NPC.Distance(Main.player[Main.myPlayer].Center) < 3000f) Main.player[Main.myPlayer].AddBuff(ModContent.BuffType<GuardianPresence>(), 2);
            }

            switch ((int)NPC.ai[0])
            {
                case -4: // exhausted, super damageable state
                    NPC.velocity.X *= 0.98f;
                    NPC.velocity.Y *= 0.98f;
                    exhausted = 1;
                    NPC.dontTakeDamage = false;
                    if(NPC.ai[3] >= 300)
                    {
                        exhausted = 0;
                        NPC.ai[3] = 0;
                        NPC.ai[0] = Main.rand.Next(0, 3);
                    }
                    break;
                case -3: // start animation
                    Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/silence");
                    NPC.dontTakeDamage = true;
                    NPC.GivenName = AbsolutionWorld.GuardianName;

                    if (NPC.ai[3] == 31)
                    {
                        NPC.Center = new Vector2(NPC.Center.X < player.Center.X ? player.Center.X - 200 : player.Center.X + 200, player.Center.Y);
                        SoundEngine.PlaySound(SoundID.Item72);
                        for (int i = 0; i < 15; i++)
                        {
                            int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Shadowflame, 0f, 0f, 0, default(Color), 4f);
                            Main.dust[d].noGravity = true;
                            Main.dust[d].velocity *= 16f;
                        }
                        doneWithStartAnim = true;
                    }
                    // monologue
                    if(AbsolutionWorld.GuardianMonologue || true)
                    {
                        if(NPC.ai[3] >= 90)
                        {
                            player.RedemptionScreen().ScreenFocusPosition = base.NPC.Center;
                            player.RedemptionScreen().lockScreen = true;
                            player.RedemptionScreen().cutscene = true;
                            NPC.LockMoveRadius(player);
                        }
                        if (NPC.ai[3] == 90)
                        {
                            DialogueChain chain = new DialogueChain();
                            chain.Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianBossDialogue.PreFight1"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, boxFade: false, ModContent.Request<Texture2D>("AbsolutionCore/Content/General/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble))
                                .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianBossDialogue.PreFight2"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 0, boxFade: false, ModContent.Request<Texture2D>("AbsolutionCore/Content/General/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble))
                                .Add(new Dialogue(NPC, Language.GetTextValue("Mods.AbsolutionCore.GuardianBossDialogue.PreFight3"), new Color(128, 0, 255), new Color(67, 0, 135), voice, 2, 100, 30, boxFade: true, ModContent.Request<Texture2D>("AbsolutionCore/Content/General/NPCs/GuardianBoss/GuardianBoss_Head_Boss", (AssetRequestMode)2).Value, bubble, endID: 1));
                            TextBubbleUI.Visible = true;
                            TextBubbleUI.Add(chain);
                            chain.OnEndTrigger += Chain_OnEndTrigger;
                        }
                    } else
                    {
                        if (NPC.ai[3] >= 60)
                        {
                            RedeSystem.Instance.TitleCardUIElement.DisplayTitle(AbsolutionWorld.GuardianName, 60, 90, 0.8f, 0, new Color(128, 0, 255), "Champion of Terraria");
                            NPC.dontTakeDamage = false;
                            NPC.ai[0] = -127;
                        }
                    }
                    break;
                case -2: // death animation
                    NPC.velocity *= 0.75f;
                    NPC.dontTakeDamage = true;
                    if(++NPC.ai[1] > 180)
                    {
                        if(Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            if(ModContent.TryFind("AbsolutionCore", "Guardian", out ModNPC m) && !NPC.AnyNPCs(m.Type))
                            {
                                int n = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, m.Type);
                                if(n != Main.maxNPCs)
                                {
                                    Main.npc[n].homeless = true;
                                    Main.npc[n].GivenName = AbsolutionWorld.GuardianName;
                                    if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, n);
                                }
                            }
                        }
                        NPC.life = 0;
                        NPC.dontTakeDamage = false;
                        SoundEngine.PlaySound(SoundID.Item67);
                        for (int i = 0; i < 50; i++)
                        {
                            int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Shadowflame, 0f, 0f, 0, default(Color), 4f);
                            Main.dust[d].noGravity = true;
                            Main.dust[d].velocity *= 16f;
                        }
                        NPC.checkDead();
                    }
                    break;
                case 0: // timber
                    Main.NewText("timber attack", 128, 0, 255);
                    NPC.ai[0] = Main.rand.Next(3, 6);
                    break;
                case 1: // terra
                    Main.NewText("terra attack", 128, 0, 255);
                    NPC.ai[0] = Main.rand.Next(3, 6);
                    break;
                case 2: // earth
                    Main.NewText("earth attack", 128, 0, 255);
                    NPC.ai[0] = Main.rand.Next(3, 6);
                    break;
                case 3: // nature
                    Main.NewText("nature attack", 128, 0, 255);
                    NPC.ai[0] = Main.rand.Next(6, 8);
                    break;
                case 4: // life
                    Main.NewText("life attack", 128, 0, 255);
                    NPC.ai[0] = Main.rand.Next(6, 8);
                    break;
                case 5: // spirit
                    Main.NewText("spirit attack", 128, 0, 255);
                    NPC.ai[0] = Main.rand.Next(6, 8);
                    break;
                case 6: // shadow
                    Main.NewText("shadow attack", 128, 0, 255);
                    if(NPC.ai[3] % 80 == 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(player.Center.X + ((float)Math.Cos(i * Math.PI / 5f) * 400), player.Center.Y + ((float)Math.Sin(i * Math.PI / 5f)) * 400), Vector2.Zero, ModContent.ProjectileType<GuardianOrb>(), 250, 0f);
                        }
                    }
                    if (NPC.ai[3] % 80 == 40)
                    {
                        for (int i = 0; i < 11; i++)
                        {
                            Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(player.Center.X + ((float)Math.Cos(i * Math.PI / 5.5f) * 400), player.Center.Y + ((float)Math.Sin(i * Math.PI / 5.5f)) * 400), Vector2.Zero, ModContent.ProjectileType<GuardianOrb>(), 250, 0f);
                        }
                    }
                    if (NPC.ai[3] >= 260) NPC.ai[0] = Main.rand.Next(8, 18);
                    break;
                case 7: // will
                    Main.NewText("will attack", 128, 0, 255);
                    NPC.ai[0] = Main.rand.Next(8, 18);
                    break;
                case 8: // cosmos, solar + vortex
                    Main.NewText("SV attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 9: // solar + nebula
                    Main.NewText("SN attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 10: // solar + stardust
                    Main.NewText("Ss attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 11: // solar + meteor
                    Main.NewText("SM attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 12: // vortex + nebula
                    Main.NewText("VN attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 13: // vortex + stardust
                    Main.NewText("Vs attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 14: // vortex + meteor
                    Main.NewText("VM attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 15: // nebula + stardust
                    Main.NewText("Ns attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 16: // nebula + meteor
                    Main.NewText("NM attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                case 17: // stardust + meteor
                    Main.NewText("sM attack", 128, 0, 255);
                    NPC.ai[0] = -4;
                    break;
                default:
                    Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/depot");
                    NPC.ai[3] = 0;
                    // get next attack
                    if(NPC.ai[0] < 3) NPC.ai[0] = Main.rand.Next(3, 6); // nature = 3, life = 4, spirit = 5
                    else if(NPC.ai[0] >= 3 && NPC.ai[0] < 6) NPC.ai[0] = Main.rand.Next(6, 8); // shadow = 6, will = 7
                    else if (NPC.ai[0] >= 6 && NPC.ai[0] < 8) NPC.ai[0] = Main.rand.Next(8, 18); // SV = 8, SN = 9, Ss = 10, SM = 11, VN = 12, Vs = 13, VM = 14, Ns = 15, NM = 16, sM = 17
                    else NPC.ai[0] = Main.rand.Next(0, 3); // timber = 0, terra = 1, earth = 2
                    NPC.ai[0] = Main.rand.Next(0, 3);
                    break;
            }

            NPC.ai[3]++;
        }

        private void Chain_OnEndTrigger(Dialogue dialogue, int id)
        {
            switch(id)
            {
                case 1:
                    if (!Main.dedServ)
                    {
                        RedeSystem.Instance.TitleCardUIElement.DisplayTitle(AbsolutionWorld.GuardianName, 60, 90, 0.8f, 0, new Color(128, 0, 255), "Champion of Terraria");
                    }
                    NPC.ai[0] = -127;
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        AbsolutionWorld.GuardianMonologue = false;
                    }
                    break;
            }
        }

        public override bool CheckDead()
        {
            if (NPC.ai[0] == -2 && NPC.ai[1] >= 180) return true;
            NPC.life = 1;
            NPC.ai[1] = 0;
            NPC.active = true;
            NPC.ai[0] = -2;
            return false;
        }

        private void MoveTo(Vector2 targetPos, float speedModifier, float cap = 16f) // stolen from souls
        {
            if (Math.Abs(NPC.Center.X - targetPos.X) > 10)
            {
                if (NPC.Center.X < targetPos.X)
                {
                    NPC.velocity.X += speedModifier;
                    if (NPC.velocity.X < 0)
                        NPC.velocity.X += speedModifier * 2;
                }
                else
                {
                    NPC.velocity.X -= speedModifier;
                    if (NPC.velocity.X > 0)
                        NPC.velocity.X -= speedModifier * 2;
                }
            }
            if (NPC.Center.Y < targetPos.Y)
            {
                NPC.velocity.Y += speedModifier;
                if (NPC.velocity.Y < 0)
                    NPC.velocity.Y += speedModifier * 2;
            }
            else
            {
                NPC.velocity.Y -= speedModifier;
                if (NPC.velocity.Y > 0)
                    NPC.velocity.Y -= speedModifier * 2;
            }
            if (Math.Abs(NPC.velocity.X) > cap)
                NPC.velocity.X = cap * Math.Sign(NPC.velocity.X);
            if (Math.Abs(NPC.velocity.Y) > cap)
                NPC.velocity.Y = cap * Math.Sign(NPC.velocity.Y);
        }

        private Vector2 AltMoveTo(Vector2 target, float speed)
        {
            Vector2 toDestination = target - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float vel = toDestination.Length();
            return toDestinationNormalized * vel / (30 / speed);
        }
    }
}
