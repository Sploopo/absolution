using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace AbsolutionCore.Content.Clicker.Items.Accessories
{
    public class TappersEssence : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";
        public override void SetStaticDefaults()
        {
            ClickerCompat.RegisterClickerItem(this);
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Tapper's Essence");
            Tooltip.SetDefault("'This is only the beginning...'\n18% increased clicker damage\n5% increased clicker crit\n15% increased clicker radius");
        }

        public override void SetDefaults()
        {
            Item.value = 3;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ClickerCompat.SetDamageAdd(player, 0.18f);
            ClickerCompat.SetClickerCritAdd(player, 5);
            ClickerCompat.SetClickerRadiusAdd(player, 0.3f);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("ClickerEmblem").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("BalloonClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("MyceliumClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("CandleClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("StarryClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("ShadowyClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("TorchClicker").Type)
                .AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("UmbralClicker").Type)
                .AddIngredient(ItemID.HallowedBar, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }

    }
}
