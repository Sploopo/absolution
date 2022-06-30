using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content;
using AbsolutionCore.Content.Clicker;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace AbsolutionCore.Common.Systems
{
    public class RecipeChangeSystem : ModSystem
    {
        public override void AddRecipeGroups()
        {
            // any cobalt clicker
            RecipeGroup.RegisterGroup("AnyCobaltClicker", new RecipeGroup(() => "Any Cobalt Clicker", new int[2] { ClickerCompat.ClickerClass.Find<ModItem>("CobaltClicker").Type,
            ClickerCompat.ClickerClass.Find<ModItem>("PalladiumClicker").Type}));
            // any mythril clicker
            RecipeGroup.RegisterGroup("AnyMythrilClicker", new RecipeGroup(() => "Any Mythril Clicker", new int[2] { ClickerCompat.ClickerClass.Find<ModItem>("MythrilClicker").Type,
            ClickerCompat.ClickerClass.Find<ModItem>("OrichalcumClicker").Type}));
            // any adamantite clicker
            RecipeGroup.RegisterGroup("AnyAdamantiteClicker", new RecipeGroup(() => "Any Adamantite Clicker", new int[2] { ClickerCompat.ClickerClass.Find<ModItem>("AdamantiteClicker").Type,
            ClickerCompat.ClickerClass.Find<ModItem>("TitaniumClicker").Type}));
        }
        public override void PostAddRecipes()
        {
            for(int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                if(recipe.TryGetResult(ItemID.PDA, out Item pda))
                {
                    recipe.AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("ButtonMasher").Type);
                }

                if (recipe.TryGetResult(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul"), out Item terrariaSoul))
                {
                    recipe.AddIngredient(Mod.Find<ModItem>("TechnologyForce").Type);
                }

                if (recipe.TryGetResult(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul"), out Item universeSoul))
                {
                    recipe.AddIngredient(Mod.Find<ModItem>("IdlistSoul").Type);
                }
            }
        }
    }
    public class ModifiedRecipeGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            return base.Clone(item, itemClone);
        }
        List<int> ModifiedItems = new List<int>
        {
            ItemID.PDA,
            ItemID.CellPhone,
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").Type,
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").Type,
        };
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return ModifiedItems.Contains(entity.type);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "ModifiedRecipe", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] Recipe modified by Absolution");
            line.OverrideColor = new Color(188, 102, 255);
            tooltips.Add(line);
        }
    }
}
