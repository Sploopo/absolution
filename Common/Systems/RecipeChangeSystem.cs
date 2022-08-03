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
        void DisableRecipe(int result, ref Recipe z)
        {
            if (z.TryGetResult(result, out Item g)) z.DisableRecipe();
        }
        void AddIngredient(int result, int ingredient, ref Recipe z, int amount = 1, bool extraRequirement = true)
        {
            if (z.TryGetResult(result, out Item g) && extraRequirement) z.AddIngredient(ingredient, amount);
        }
        void AddTile(int tile, int result, ref Recipe z)
        {
            if (z.TryGetResult(result, out Item g)) z.AddTile(tile);
        }
        public override void AddRecipes()
        {
            for(int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                DisableRecipe(ItemID.GuideVoodooDoll, ref recipe);
                DisableRecipe(souls.Find<ModItem>("SigilOfChampions").Type, ref recipe);
                AddIngredient(souls.Find<ModItem>("TrawlerSoul").Type, calamity.Find<ModItem>("SupremeBaitTackleBoxFishingStation").Type, ref recipe);
                AddIngredient(souls.Find<ModItem>("DevisCurse").Type, calamity.Find<ModItem>("PurifiedGel").Type, ref recipe, 5);
                AddIngredient(calamity.Find<ModItem>("JungleDragonEgg").Type, souls.Find<ModItem>("AbomEnergy").Type, ref recipe, 5);
                if (recipe.TryGetResult(calamity.Find<ModItem>("DecapoditaSprout").Type, out Item g)) recipe.RemoveTile(TileID.DemonAltar);
                AddTile(TileID.Solidifier, calamity.Find<ModItem>("DecapoditaSprout").Type, ref recipe);
                AddIngredient(calamity.Find<ModItem>("OverloadedSludge").Type, ItemID.Bone, ref recipe, 10);
                AddIngredient(calamity.Find<ModItem>("CosmicWorm").Type, souls.Find<ModItem>("Eridanium").Type, ref recipe, 5, recipe.TryGetIngredient(calamity.Find<ModItem>("TwistingNether").Type, out g));
                if (recipe.TryGetResult(calamity.Find<ModItem>("CosmicWorm"), out g)  && recipe.TryGetIngredient(ItemID.IronBar, out g)) recipe.DisableRecipe();
            }
        }
    }
}
