using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using ClickerClass;

namespace AbsolutionCore.Content.Clicker.Items.Accessories
{
    public class PrecursorEnchantment : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";
        public override void SetStaticDefaults()
        {
            ClickerCompat.RegisterClickerItem(this);
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("While in combat, your cursor constantly leaves behind damaging afterimages and clicks every half-second\n'Those who forget history are doomed to repeat it'");
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "ItemName")
                {
                    line.OverrideColor = new Color(160, 85, 16);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
            clickerPlayer.setPrecursor = true;
            ClickerCompat.SetAccessory(player, "RegalClickingGlove");
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("PrecursorHelmet").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("PrecursorBreastplate").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("PrecursorGreaves").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("RegalClickingGlove").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("LihzahrdClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("ChlorophyteClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("EclipticClicker").Type)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
