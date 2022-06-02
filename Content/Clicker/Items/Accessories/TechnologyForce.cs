using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using ClickerClass;

namespace AbsolutionCore.Content.Clicker.Items.Accessories
{
    public class TechnologyForce : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";
        public override void SetStaticDefaults()
        {
            ClickerCompat.RegisterClickerItem(this);
            DisplayName.SetDefault("Force of Technology");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault($"[i:{ ModContent.ItemType<MiceEnchantment>()}]Reduces the amount of clicks required for a click effect by 10%\n[i:{ ModContent.ItemType<MiceEnchantment>()}]Right clicking a position within your clicker radius will teleport you to it\n" +
                $"[i:{ ModContent.ItemType<MotherboardEnchantment>()}]If the above is disabled, right click to place a radius extending sensor\n[i:{ ModContent.ItemType<MotherboardEnchantment>()}]Every 25 clicks causes a large, fiery explosion\n" +
                $"[i:{ ModContent.ItemType<PrecursorEnchantment>()}]While in combat, your cursor constantly leaves behind damaging afterimages and clicks every half-second\n" +
                $"[i:{ ModContent.ItemType<RGBEnchantment>()}]Every 20 clicks propels a chromatic burst from your cursor\n[i:{ ModContent.ItemType<RGBEnchantment>()}]While equipped, empowering circles will rotate around you\n" +
                $"[i:{ ModContent.ItemType<RGBEnchantment>()}]Keeping your cursor within the circles will build up clicker critical strikes, clicker radius, and clicker effects\n" +
                $"[i:{ ModContent.ItemType<OverclockEnchantment>()}]Every 100 clicks briefly grants you \"Overclock\", making every click trigger all active click effects with reduced damage\n" +
                $"[i:{ ModContent.ItemType<OverclockEnchantment>()}]Collects enemy matter as you click on enemies\n[i:{ ModContent.ItemType<OverclockEnchantment>()}]Creates a burst of gouging paperclips when enough matter is collected\n" +
                "'All the world's progress in your hands'");
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            foreach (TooltipLine line in tooltips)
            {
                if (line.Mod == "Terraria" && line.Name == "ItemName")
                {
                    line.OverrideColor = new Color(116, 198, 242);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
            clickerPlayer.setMice = true;
            clickerPlayer.clickerBonusPercent -= 0.10f;
            clickerPlayer.setRGB = true;
            ClickerCompat.SetAccessoryItem(player, "SMedal", Item);
            clickerPlayer.setPrecursor = true;
            ClickerCompat.SetAccessory(player, "RegalClickingGlove");
            clickerPlayer.EnableClickEffect(ClickEffect.BigRedButton);
            clickerPlayer.setMotherboard = true;
            clickerPlayer.setOverclock = true;
            ClickerCompat.SetAccessoryItem(player, "BottomlessBoxOfPaperclips", Item);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(Mod.Find<ModItem>("MotherboardEnchantment").Type)
                .AddIngredient(Mod.Find<ModItem>("RGBEnchantment").Type)
                .AddIngredient(Mod.Find<ModItem>("OverclockEnchantment").Type)
                .AddIngredient(Mod.Find<ModItem>("PrecursorEnchantment").Type)
                .AddIngredient(Mod.Find<ModItem>("MiceEnchantment").Type)
                .AddTile(ModLoader.GetMod("Fargowiltas").Find<ModTile>("CrucibleCosmosSheet").Type)
                .Register();
        }
    }
}
