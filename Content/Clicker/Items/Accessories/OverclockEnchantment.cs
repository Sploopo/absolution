using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;

namespace AbsolutionCore.Content.Clicker.Items.Accessories
{
    public class OverclockEnchantment : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";
        public override void SetStaticDefaults()
        {
            ClickerCompat.RegisterClickerItem(this);
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Every 100 clicks briefly grants you \"Overclock\", making every click trigger all active click effects with reduced damage\n" +
                "Collects enemy matter as you click on enemies\nCreates a burst of gouging paperclips when enough matter is collected");
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 3, 50, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "ItemName")
                {
                    line.OverrideColor = new Color(216, 61, 58);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ClickerCompat.SetAccessoryItem(player, "BottomlessBoxOfPaperclips", Item);

            // there's no setsetbonus in clicker so z troll
            int overclockType = ClickerCompat.ClickerClass.Find<ModBuff>("OverclockBuff").Type;
            if (ClickerCompat.GetClickAmount(player) % 100 == 0 && ClickerCompat.GetClickAmount(player) != 0)
            {
                SoundEngine.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 94);
                player.AddBuff(overclockType, 180, false);
                for (int i = 0; i < 25; i++)
                {
                    int num6 = Dust.NewDust(player.position, 20, 20, DustID.GemRuby, 0f, 0f, 150, default(Color), 1.35f);
                    Main.dust[num6].noGravity = true;
                    Main.dust[num6].velocity *= 0.75f;
                    int num7 = Main.rand.Next(-50, 51);
                    int num8 = Main.rand.Next(-50, 51);
                    Dust dust = Main.dust[num6];
                    dust.position.X = dust.position.X + num7;
                    Dust dust2 = Main.dust[num6];
                    dust2.position.Y = dust2.position.Y + num8;
                    Main.dust[num6].velocity.X = -num7 * 0.075f;
                    Main.dust[num6].velocity.Y = -num8 * 0.075f;
                }
            }
        }
    }
}
