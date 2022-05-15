using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using ClickerClass;

namespace AbsolutionCore.Content.Clicker.Items.Accessories
{
    public class MotherboardEnchantment : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";
        public override void SetStaticDefaults()
        {
            ClickerCompat.RegisterClickerItem(this);
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Right click to place a radius extending sensor\nEvery 25 clicks causes a large, fiery explosion\n" +
                "'Hello and, again, welcome'");
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "ItemName")
                {
                    line.OverrideColor = new Color(217, 224, 204);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
            clickerPlayer.EnableClickEffect(ClickEffect.BigRedButton);
            clickerPlayer.setMotherboard = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MotherboardHelmet").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MotherboardSuit").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MotherboardBoots").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("BigRedButton").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("SlickClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MagnetClicker").Type)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
