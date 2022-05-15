using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using AbsolutionCore.Common.Systems;
using ClickerClass;

namespace AbsolutionCore.Content.Clicker.Items.Accessories
{
    public class RGBEnchantment : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";
        public override void SetStaticDefaults()
        {
            ClickerCompat.RegisterClickerItem(this);
            DisplayName.SetDefault("RGB Enchantment");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Every 20 clicks propels a chromatic burst from your cursor\nWhile equipped, empowering circles will rotate around you\n" +
                "Keeping your cursor within the circles will build up clicker critical strikes, clicker radius, and clicker effects\n'RRRAAAIIINNNBBBOOOWWWSSS'");
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Color[] rgb =
            {
                new Color(255, 0, 0),
                new Color(0, 255, 0),
                new Color(0, 0, 255)
            };
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "ItemName")
                {
                    float fade = (Main.GameUpdateCount % 180) / 180f;
                    int index = (int)((Main.GameUpdateCount / 180) % 3);
                    int nextIndex = (index + 1) % 3;

                    line.OverrideColor = Color.Lerp(rgb[index], rgb[nextIndex], fade);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
            clickerPlayer.setRGB = true;
            ClickerCompat.SetAccessoryItem(player, "SMedal", Item);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("RGBHelm").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("RGBBreastplate").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("RGBGreaves").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("SMedal").Type)
                .AddRecipeGroup("AnyCobaltClicker")
                .AddRecipeGroup("AnyMythrilClicker")
                .AddRecipeGroup("AnyAdamantiteClicker")
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
