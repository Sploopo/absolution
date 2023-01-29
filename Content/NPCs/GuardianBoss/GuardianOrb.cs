using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using FargowiltasSouls.Projectiles;

namespace AbsolutionCore.Content.NPCs.GuardianBoss
{
    public class GuardianOrb : ModProjectile
    {
        Vector2 vel = new Vector2();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Orb");
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.alpha = 0;
            CooldownSlot = 1;
            Projectile.GetGlobalProjectile<FargoSoulsGlobalProjectile>().TimeFreezeImmune = true;
            Projectile.GetGlobalProjectile<FargoSoulsGlobalProjectile>().DeletionImmuneRank = 2;
        }

        public override void OnSpawn(Terraria.DataStructures.IEntitySource source)
        {
            for (int i = 0; i < 3; i++)
            {
                int index = Dust.NewDust(Projectile.position, (int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale), 27, Projectile.velocity.X, Projectile.velocity.Y, 100, new Color(), 2.5f);
                Main.dust[index].position = (Main.dust[index].position + Projectile.Center) / 2f;
                Main.dust[index].noGravity = true;
                Main.dust[index].velocity = Main.dust[index].velocity * 0.3f;
                Main.dust[index].velocity = Main.dust[index].velocity - Projectile.velocity * 0.1f;
            }
            SoundEngine.PlaySound(SoundID.Item8, Projectile.Center);
        }
        public override void AI()
        {
            if(Projectile.ai[1] == 0)
            {
                vel = Projectile.DirectionTo(Main.player[Player.FindClosest(Projectile.Center, 0, 0)].Center);
            }
            Projectile.velocity = vel * 2;
            for(int i = 0; i < Projectile.ai[1]; i++) Projectile.velocity *= 1.015f;
            Projectile.netUpdate = true;

            if (Projectile.ai[1] >= 90)
            {
                for (int i = 0; i < 3; i++)
                {
                    int index = Dust.NewDust(Projectile.position, (int)(Projectile.width * Projectile.scale), (int)(Projectile.height * Projectile.scale), 27, Projectile.velocity.X, Projectile.velocity.Y, 100, new Color(), 2.5f);
                    Main.dust[index].position = (Main.dust[index].position + Projectile.Center) / 2f;
                    Main.dust[index].noGravity = true;
                    Main.dust[index].velocity = Main.dust[index].velocity * 0.3f;
                    Main.dust[index].velocity = Main.dust[index].velocity - Projectile.velocity * 0.1f;
                }
                SoundEngine.PlaySound(SoundID.Item73, Projectile.Center);
                Projectile.Kill();
            }
            Projectile.ai[1]++;
        }
    }
}
