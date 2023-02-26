using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;
using ThoriumMod;
using ThoriumMod.Projectiles.Bard;
using ThoriumMod.Utilities;

namespace AbsolutionCore.Content.Projectiles
{
	public class CosmicKazooToot : BardProjectile // Code reused from the Thorium KazooToot projectile
	{
		public float Timer
		{
			get
			{
				return base.Projectile.ai[0];
			}
			set
			{
				base.Projectile.ai[0] = value;
			}
		}

		public float AmpCount
		{
			get
			{
				return base.Projectile.ai[1];
			}
			set
			{
				base.Projectile.ai[1] = value;
			}
		}

		public override BardInstrumentType InstrumentType => BardInstrumentType.Wind;

		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 20;
			ProjectileID.Sets.TrailingMode[base.Projectile.type] = 2;
		}

		public override void SetBardDefaults()
		{
			base.Projectile.width = 8;
			base.Projectile.height = 8;
			base.Projectile.penetrate = -1;
			base.Projectile.friendly = true;
			base.Projectile.timeLeft = 240;
			base.Projectile.extraUpdates = 2;
			base.DrawOffsetX = -9;
			base.DrawOriginOffsetX = 4f;
			base.Projectile.usesLocalNPCImmunity = true;
			base.Projectile.localNPCHitCooldown = 10;
		}

		public override void ModifyDamageHitbox(ref Rectangle hitbox)
		{
			hitbox.Inflate(8, 8);
		}

		public override bool PreDraw(ref Color lightColor)
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			Texture2D value = TextureAssets.Projectile[base.Projectile.type].Value;
			Vector2 val = new Vector2((float)((value.Width - base.Projectile.width) / 2 + base.Projectile.width / 2) + base.DrawOriginOffsetX, (float)(base.Projectile.height / 2));
			lightColor *= Math.Min(((Projectile.velocity)).Length() / 3f, 1f);
			for (int num = base.Projectile.oldPos.Length - 1; num > 0; num--)
			{
				Vector2 position = base.Projectile.oldPos[num] - Main.screenPosition + val + new Vector2((float)base.DrawOffsetX, base.Projectile.gfxOffY);
				Color color = base.Projectile.GetAlpha(lightColor * 0.4f) * ((float)(base.Projectile.oldPos.Length - num) / (float)base.Projectile.oldPos.Length);
				Main.EntitySpriteDraw(value, position, null, color, base.Projectile.oldRot[num], val, base.Projectile.scale, (SpriteEffects)0, 0);
			}
			return true;
		}

		public override void AI()
		{
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			float num = 0.225f;
			float num2 = 24f;
			float num3 = (float)Math.PI * 2f / num2;
			float num4 = 6f + this.AmpCount;
			float num5 = this.Timer * num3;
			if (this.Timer == 0f && base.Projectile.velocity.X > 0f)
			{
				num5 += (float)Math.PI;
			}
			float num6 = HeightMult(num5) * num4;
			float num7;
			float num8;
			if (this.Timer == 0f)
			{
				num7 = Projectile.velocity.Length();
				num8 = base.Projectile.velocity.ToRotation();
				if (base.Projectile.velocity.X > 0f)
				{
					this.Timer += num2 / 2f;
				}
			}
			else
			{
				float num9 = num6 - HeightMult(num5 - num3) * (num4 - num);
				num7 = (float)Math.Sqrt((double)(((Vector2)(Projectile.velocity)).LengthSquared() - num9 * num9));
				num8 = base.Projectile.velocity.RotatedBy(0f - Utils.ToRotation(new Vector2(num7, num9))).ToRotation();
			}
			ThoriumPlayer thoriumPlayer = Main.player[base.Projectile.owner].GetThoriumPlayer();
			NPC nPC = Help.FindNearestNPC(Projectile, 500f);
			if (nPC != null)
			{
				base.Projectile.velocity = num8.ToRotationVector2() * num7;
				Vector2 val = nPC.Center - Projectile.Center;
				val *= (4f + thoriumPlayer.bardHomingBonus) / (thoriumPlayer.accWindHoming ? 1.5f : 2.5f) / val.Length();
				Projectile.velocity *= 1f - 0.02f;
				Projectile.velocity += val * 0.02f;
				num7 = ((Vector2)(Projectile.velocity)).Length();
				num8 = base.Projectile.velocity.ToRotation();
			}
			base.Projectile.velocity = Utils.RotatedBy(new Vector2(Math.Min(num7 * 1.025f, 5f), HeightMult(num5 + num3) * (num4 + num) - num6), num8);
			base.Projectile.rotation = base.Projectile.velocity.ToRotation() + (float)Math.PI / 4f;
			this.Timer++;
			this.AmpCount += num;
			if (this.Timer % 2f == 0f)
			{
				Vector2 val = base.Projectile.velocity.SafeNormalize(Vector2.UnitY) * 8f;
				int num10 = ((!((this.Timer * num3 + (float)Math.PI / 2f) % ((float)Math.PI * 2f) >= (float)Math.PI)) ? 1 : (-1));
				Vector2 val2 = (num8 + (float)Math.PI / 2f * (float)num10).ToRotationVector2() * num7;
				Dust dust = Dust.NewDustPerfect(base.Projectile.Center + val, ModContent.DustType<CalamityMod.Dusts.CosmiliteBarDust>(), val2);
				dust.scale = 1f;
				dust.noGravity = true;
				Dust dust2 = Dust.NewDustPerfect(base.Projectile.Center - val, ModContent.DustType<CalamityMod.Dusts.CosmiliteBarDust>(), -val2);
				dust2.scale = 1f;
				dust2.noGravity = true;
			}
			static float HeightMult(float counter)
			{
				float num11 = (counter + (float)Math.PI / 2f) % ((float)Math.PI * 2f) / (float)Math.PI;
				return ((num11 < 1f) ? (num11 - 0.5f) : (0.5f - (num11 - 1f))) * 2f;
			}
		}

        public override void BardOnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(ModContent.BuffType<CalamityMod.Buffs.DamageOverTime.GodSlayerInferno>(), 180);
        }
    }

	internal static class Help
    {
		internal static bool CanHitLine(Point start, Point end)
		{
			if (!WorldGen.InWorld(start.X, start.Y) || !WorldGen.InWorld(end.X, end.Y) || WorldGen.SolidTile3(Framing.GetTileSafely(start)))
			{
				return false;
			}
			int num = Math.Abs(end.X - start.X);
			int num2 = Math.Abs(end.Y - start.Y);
			int num3 = ((end.X - start.X > 0) ? 1 : (-1));
			int num4 = ((end.Y - start.Y > 0) ? 1 : (-1));
			int num5 = 0;
			int num6 = 0;
			while (num5 < num || num6 < num2)
			{
				int num7 = ((1 + 2 * num5) * num2).CompareTo((1 + 2 * num6) * num);
				if (num7 == 0)
				{
					if (WorldGen.SolidTile3(Framing.GetTileSafely(start.X + num3, start.Y)) || WorldGen.SolidTile3(Framing.GetTileSafely(start.X, start.Y + num4)))
					{
						return false;
					}
					start.X += num3;
					start.Y += num4;
					num5++;
					num6++;
				}
				else if (num7 < 0)
				{
					start.X += num3;
					num5++;
				}
				else
				{
					start.Y += num4;
					num6++;
				}
				if (WorldGen.SolidTile3(Framing.GetTileSafely(start)))
				{
					return false;
				}
			}
			return true;
		}
		internal static NPC FindNearestNPC(this Projectile projectile, float maxRange, bool absoluteDistance = true, bool ignoreDontTakeDamage = false, Func<NPC, bool> isValidTarget = null)
		{
			NPC result = null;
			if (!absoluteDistance)
			{
				maxRange *= maxRange;
			}
			for (int i = 0; i < 200; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.CanBeChasedBy(projectile, ignoreDontTakeDamage) && (isValidTarget == null || isValidTarget(nPC)))
				{
					float num = ((!absoluteDistance) ? projectile.DistanceSQ(nPC.Center) : (Math.Abs(projectile.Center.X - nPC.Center.X) + Math.Abs(projectile.Center.Y - nPC.Center.Y)));
					if (num < maxRange && CanHitLine(projectile.Center.ToTileCoordinates(), nPC.Center.ToTileCoordinates()))
					{
						maxRange = num;
						result = nPC;
					}
				}
			}
			return result;
		}
	}
}