using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.Clicker;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AbsolutionCore.Common.Systems
{
    public class RecipeChangeSystem : ModSystem
    {
        public static List<int> ModifiedRecipes = new List<int>
        {
            ItemID.PDA
        };
        public override void PostAddRecipes()
        {
            for(int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if(recipe.TryGetResult(ItemID.PDA, out Item result))
                {
                    recipe.AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("ButtonMasher").Type);
                }
            }
        }
    }
}
