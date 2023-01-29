using Microsoft.Xna.Framework;
using FargowiltasSouls;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AbsolutionCore.Common.Systems;
using Terraria.Audio;
using FargowiltasSouls.NPCs;
using CalamityMod;
using CalamityMod.CalPlayer;

namespace AbsolutionCore.Content.Items
{
    public class BrokenTerminus : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terminus");
            Tooltip.SetDefault("A ritualistic artifact, thought to have brought about The End many millenia ago?\nThousands of years of dormancy have stripped it of its power, it must be reactivated to be used again");
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 58;
            Item.rare = ItemRarityID.Gray;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(1);
        }

        public override void AddRecipes()
        {
            if(AbsolutionConfig.Instance.UnboundMode)
            Recipe.Create(ModContent.ItemType<CalamityMod.Items.SummonItems.Terminus>())
                .AddIngredient(this)
                .AddTile(ModContent.TileType<CalamityMod.Tiles.Furniture.CraftingStations.DraedonsForge>())
                .Register();
            else
                Recipe.Create(ModContent.ItemType<CalamityMod.Items.SummonItems.Terminus>())
                .AddIngredient(this)
                .AddIngredient(ModContent.ItemType<FargowiltasSouls.Items.Materials.EternalEnergy>(), 22)
                .AddTile(ModContent.TileType<CalamityMod.Tiles.Furniture.CraftingStations.DraedonsForge>())
                .Register();
        }
    }
}
