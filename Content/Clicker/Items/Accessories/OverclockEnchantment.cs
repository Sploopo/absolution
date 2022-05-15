using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.Audio;
using ClickerClass;

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
                "Collects enemy matter as you click on enemies\nCreates a burst of gouging paperclips when enough matter is collected\n" +
                "'Even further beyond'");
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
            ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
            clickerPlayer.setOverclock = true;
            ClickerCompat.SetAccessoryItem(player, "BottomlessBoxOfPaperclips", Item);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("OverclockHelmet").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("OverclockSuit").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("OverclockBoots").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("BottomlessBoxofPaperclips").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("ArthursClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("FaultyClicker").Type)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
