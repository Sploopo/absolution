using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using ClickerClass;

namespace AbsolutionCore.Content.Clicker.Items.Accessories
{
    public class MiceEnchantment : ModItem
    {
        public override void SetStaticDefaults()
        {
            ClickerCompat.RegisterClickerItem(this);
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Reduces the amount of clicks required for a click effect by 10%\nRight clicking a position within your clicker radius will teleport you to it\n" +
                "'Lennie, for God' sakes, don't drink so much'");
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
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MiceMask").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MiceSuit").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MiceBoots").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MouseTrap").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MiceClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("AstralClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("LordsClicker").Type)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
