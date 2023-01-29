using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FargowiltasSouls.Projectiles;

namespace AbsolutionCore.Content.NPCs.GuardianBoss
{
    public class GuardianTree : ModProjectile
    {
        Vector2 position = new Vector2();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 218;
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.damage = 250;
            Projectile.alpha = 0;
            Projectile.timeLeft = 60;
            CooldownSlot = 1;
            Projectile.GetGlobalProjectile<FargoSoulsGlobalProjectile>().TimeFreezeImmune = true;
            Projectile.GetGlobalProjectile<FargoSoulsGlobalProjectile>().DeletionImmuneRank = 2;
        }

        public override void AI()
        {
            NPC npc = Main.npc[(int)Projectile.ai[0]];
            if (Projectile.ai[1] < 90)
            {
                if (npc.active && npc.type == ModContent.NPCType<GuardianBoss>())
                {
                    Projectile.Center = npc.Center;
                    if (Projectile.localAI[0] == 0) //ensure it faces the right way on tick 1
                        Projectile.rotation = npc.DirectionTo(Main.player[npc.target].Center).ToRotation();

                    if (Projectile.ai[1] > 1)
                    {
                        if (!(Projectile.ai[1] == 4 && Projectile.timeLeft < System.Math.Abs(Projectile.localAI[1]) + 5))
                            Projectile.rotation = Projectile.rotation.AngleLerp(npc.DirectionTo(Main.player[npc.target].Center + Main.player[npc.target].velocity * 30).ToRotation(), 0.2f);
                    }
                    else
                    {
                        Projectile.rotation = npc.DirectionTo(Main.player[npc.target].Center).ToRotation();
                    }
                }
                else
                {
                    Projectile.Kill();
                }
            } else if(Projectile.ai[1] < 135)
            {
                Vector2 toDestination = Main.player[npc.target].Center - npc.Center;
                Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
                float vel = toDestination.Length();
                Projectile.velocity = toDestinationNormalized * vel / 3;
            } else // explode
            {
                Projectile.Kill();
            }

            if(Projectile.ai[1] >= 90 && Projectile.ai[1] <= 93)
            {
                position = Main.player[npc.target].Center;
            }
        }
    }
}
