using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace AbsolutionCore.Common.Systems
{
    public class RecipeChangeSystem : ModSystem
    {
        Mod souls = ModLoader.GetMod("FargowiltasSouls");
        Mod calamity = ModLoader.GetMod("CalamityMod");
        public override void PostAddRecipes()
        {
            for(int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if (recipe.TryGetIngredient(ItemID.GuideVoodooDoll, out Item g)) recipe.DisableRecipe();
                if (recipe.TryGetResult(souls.Find<ModItem>("TrawlerSoul"), out g)) recipe.AddIngredient(calamity.Find<ModItem>("SupremeBaitTackleBoxFishingStation").Type);
                if (recipe.TryGetResult(souls.Find<ModItem>("SigilOfChampions"), out g)) recipe.DisableRecipe();
                if (recipe.TryGetResult(souls.Find<ModItem>("DevisCurse"), out g)) recipe.AddIngredient(calamity.Find<ModItem>("PurifiedGel").Type, 5);
		if (recipe.TryGetResult(calamity.Find<ModItem>("JungleDragonEgg"), out g)) recipe.AddIngredient(souls.Find<ModItem>("AbomEnergy").Type, 5);
                if (recipe.TryGetResult(calamity.Find<ModItem>("DecapoditaSprout"), out g))
                {
                    recipe.RemoveTile(TileID.DemonAltar);
                    recipe.AddTile(TileID.Solidifier);
                }
                if (recipe.TryGetResult(calamity.Find<ModItem>("OverloadedSludge"), out g)) recipe.AddIngredient(ItemID.Bone, 10);
                if (recipe.TryGetResult(calamity.Find<ModItem>("CosmicWorm"), out g)  && recipe.TryGetIngredient(ItemID.IronBar, out g)) recipe.DisableRecipe();
                if (recipe.TryGetResult(calamity.Find<ModItem>("CosmicWorm"), out g) && recipe.TryGetIngredient(calamity.Find<ModItem>("TwistingNether").Type, out g)) recipe.AddIngredient(souls.Find<ModItem>("Eridanium").Type, 5);
            }
        }
    }
    public class ModifiedRecipeGlobalItem : GlobalItem
    {
        static Mod souls = ModLoader.GetMod("FargowiltasSouls");
        static Mod calamity = ModLoader.GetMod("CalamityMod");
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        List<int> ModifiedItems = new List<int>
        {
            souls.Find<ModItem>("TrawlerSoul").Type,
            souls.Find<ModItem>("DevisCurse").Type,
            calamity.Find<ModItem>("DecapoditaSprout").Type,
            calamity.Find<ModItem>("OverloadedSludge").Type,
            calamity.Find<ModItem>("CosmicWorm").Type,
        };
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModifiedItems.Contains(entity.type);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Color[] colors = { new Color(128, 0, 255), new Color(255, 0, 255) };
            int index = (int)(Main.GameUpdateCount / 60) % 2;
            TooltipLine line = new TooltipLine(Mod, "ModifiedRecipe", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] Recipe modified by Absolution");
            line.OverrideColor = Color.Lerp(colors[index], colors[(index + 1)%2], (Main.GameUpdateCount % 60) / 60f);
            tooltips.Add(line);
        }
    }
}
