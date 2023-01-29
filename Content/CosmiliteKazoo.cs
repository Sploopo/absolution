using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using ThoriumMod;
using ThoriumMod.Items;
using AbsolutionCore.Content.Projectiles;

namespace AbsolutionCore.Content
{
    public class CosmiliteKazoo : BardItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The Devourer weeps'\nUnleashes a nightmarish combination of cosmic wrath, gods' souls, and annoyance");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Empowerments.AddInfo<ThoriumMod.Empowerments.ResourceGrabRange>(3);
            Empowerments.AddInfo<ThoriumMod.Empowerments.ResourceRegen>(3);
            Empowerments.AddInfo<ThoriumMod.Empowerments.ResourceMaximum>(3);
        }

        public override void SetBardDefaults()
        {
            Item.damage = 199;
            Item.crit = 15;
            InspirationCost = 2;
            Item.width = 25;
            Item.height = 40;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.holdStyle = 3;
            Item.useStyle = 5;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.channel = true;
            Item.knockBack = 4f;
            Item.value = Item.sellPrice(0, 35);
            Item.rare = ModContent.RarityType<CalamityMod.Rarities.PureGreen>();
            Item.UseSound = ThoriumMod.Sounds.ThoriumSounds.Kazoo_Sound;
            Item.shoot = ModContent.ProjectileType<CosmicKazooToot>();
            Item.shootSpeed = 3.2f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                 .AddIngredient(ModContent.ItemType<ThoriumMod.Items.BardItems.Kazoo>())
                 .AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.CoreofCalamity>(), 2)
                 .AddIngredient(ModContent.ItemType<CalamityMod.Items.Materials.CosmiliteBar>(), 10)
                 .AddTile(ModContent.TileType<CalamityMod.Tiles.Furniture.CraftingStations.CosmicAnvil>())
                 .Register();
        }
    }
}
