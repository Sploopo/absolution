using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using AbsolutionCore.Common.Globals;

namespace AbsolutionCore.Content.General.NPCs.GuardianBoss
{
    [AutoloadBossHead]
    public class GuardianBoss : ModNPC
    {
        public int timer;
        public int attackType = -3;
        public int attackTier;

        public bool reachedTopOfThing;
        public Vector2 targetPos;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian");

            Main.npcFrameCount[NPC.type] = 6;
            NPCID.Sets.NoMultiplayerSmoothingByType[NPC.type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(NPC.type);
            NPCID.Sets.DebuffImmunitySets.Add(NPC.type, new Terraria.DataStructures.NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.Confused,
                    BuffID.Chilled,
                    BuffID.OnFire,
                    BuffID.Suffocation,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("Lethargic").Type,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("ClippedWings").Type,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("MutantNibble").Type,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("OceanicMaul").Type,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("LightningRod").Type,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("Sadism").Type,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("GodEater").Type,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("TimeFrozen").Type,
                    ModLoader.GetMod("FargowiltasSouls").Find<ModBuff>("LeadPoison").Type
                }
            });
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("A master of balance, one of the oldest beings in the world, and your final test before you take on Terraria's truly powerful enemies.")
            });
        }

        public override void SetDefaults()
        {
            NPC.width = 120;
            NPC.height = 120;
            NPC.damage = 69;
            NPC.defense = 220;
            NPC.lifeMax = 2;
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
        }

        public override void FindFrame(int frameHeight)
        {
            if (++NPC.frameCounter > 6)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                    NPC.frame.Y = 0;
            }
        }

        public override bool CanHitPlayer(Player target, ref int CooldownSlot)
        {
            return false;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }

        public override void AI()
        {
            NPC.TargetClosest();
            Player player = Main.player[NPC.target];
            NPC.direction = NPC.spriteDirection = Math.Sign(player.Center.X - NPC.Center.X);

            switch(attackType)
            {
                case -2: // death animation
                    NPC.velocity *= 0.75f;
                    NPC.dontTakeDamage = true;
                    if(timer % 6 == 0)
                    {
                        SoundEngine.PlaySound(SoundID.Item43);
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), new Vector2(NPC.Center.X, NPC.Center.Y + 25f), new Vector2(Main.rand.Next(-8, 8), Main.rand.Next(-8, 8)), ProjectileID.ShadowBeamFriendly, 0, 0f);
                    }
                    if(++timer > 180)
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
                case 0: // holy spears
                    Main.NewText("holy spear walls", 128, 0, 255);
                    NPC.velocity = timer++ <= 80 ? MoveTo(new Vector2(player.Center.X - 350f, player.Center.Y), 1.5f) : MoveTo(new Vector2(player.Center.X + 350f, player.Center.Y), 1.5f);
                    if(timer == 80)
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Shadowflame, 0f, 0f, 0, default(Color), 1f);
                            Main.dust[d].noGravity = true;
                            Main.dust[d].velocity *= 4f;
                        }
                        NPC.position = new Vector2((int)player.Center.X + 350f, (int)NPC.Center.Y);
                        SoundEngine.PlaySound(SoundID.Item130);
                        for (int i = 0; i < 25; i++)
                        {
                            int d = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Shadowflame, 0f, 0f, 0, default(Color), 1f);
                            Main.dust[d].noGravity = true;
                            Main.dust[d].velocity *= 4f;
                        }
                    }
                    if (timer >= 160) attackType = -3; // get new attack
                    break;
                case 1: // sword rifts
                    Main.NewText("sword rifts", 128, 0, 255);
                    SoundEngine.PlaySound(SoundID.Roar);
                    attackType = -3;
                    break;
                case 2: // pumpkin rings
                    Main.NewText("pumpkin rings", 128, 0, 255);
                    if (((NPC.Center.Y - player.Center.Y > -425f && NPC.Center.Y - player.Center.Y < -375f) || timer > 120) && !reachedTopOfThing)
                    {
                        targetPos = new Vector2(NPC.Center.X + 700f, NPC.Center.Y);
                        reachedTopOfThing = true;
                    }
                    NPC.velocity = reachedTopOfThing ? new Vector2(8f, 0f) : MoveTo(new Vector2(player.Center.X - 350f, player.Center.Y - 400f), 1.5f);
                    if (timer++ > 175 && reachedTopOfThing) attackType = -3;
                    break;
                default:
                    reachedTopOfThing = false;
                    NPC.velocity = MoveTo(new Vector2(player.Center.X - 350f, player.Center.Y), 1.5f);
                    if((NPC.Center.X - player.Center.X > -400f && NPC.Center.X - player.Center.X < -300f && NPC.Center.Y - player.Center.Y > -25f && NPC.Center.Y - player.Center.Y < 25f) || timer++ > 300)
                    {
                        timer = 0;
                        attackType = Main.rand.Next(0, 3);
                    }
                    break;
            }
        }

        public override bool CheckDead()
        {
            if (attackType == -2 && timer >= 180) return true;
            NPC.life = 1;
            timer = 0;
            NPC.active = true;
            attackType = -2;
            return false;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = (int) (0.5 * NPC.lifeMax * ((numPlayers + 1)*0.5));
            NPC.damage = (int) (0.5 * NPC.damage);
        }

        public Vector2 MoveTo(Vector2 target, float speed)
        {
            Vector2 toDestination = target - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float vel = toDestination.Length();
            return toDestinationNormalized * vel / (30 / speed);
        }

        public int GetNextAttack()
        {
            if(attackTier == 1 || attackTier == 2)
            {
                return Main.rand.Next(0, 7);
            } else if(attackTier == 3)
            {
                return Main.rand.Next(8, 11);
            }
            return Main.rand.Next(12, 15);
        }
    }
}
