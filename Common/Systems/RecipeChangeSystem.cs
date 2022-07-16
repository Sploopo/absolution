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

                if (recipe.TryGetResult(ItemID.PDA, out Item g)) recipe.AddIngredient(ClickerCompat.ClickerClass.Find<ModItem>("ButtonMasher").Type);
                if (recipe.TryGetResult(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul"), out g)) recipe.AddIngredient(Mod.Find<ModItem>("TechnologyForce").Type);
                if (recipe.TryGetResult(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul"), out g)) recipe.AddIngredient(Mod.Find<ModItem>("IdlistSoul").Type);
                if (recipe.TryGetResult(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("SigilOfChampions"), out g)) recipe.DisableRecipe();
                if (recipe.TryGetResult(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("DevisCurse"), out g)) recipe.AddIngredient(ModLoader.GetMod("CalamityMod").Find<ModItem>("PurifiedGel").Type, 5);
                if (recipe.TryGetResult(ModLoader.GetMod("CalamityMod").Find<ModItem>("DecapoditaSprout"), out g))
                {
                    recipe.RemoveTile(TileID.DemonAltar);
                    recipe.AddTile(TileID.Solidifier);
                }
                if (recipe.TryGetResult(ModLoader.GetMod("CalamityMod").Find<ModItem>("OverloadedSludge"), out g)) recipe.AddIngredient(ItemID.Bone, 10);
                if (recipe.TryGetResult(ModLoader.GetMod("CalamityMod").Find<ModItem>("CosmicWorm"), out g)  && recipe.TryGetIngredient(ItemID.IronBar, out g)) recipe.DisableRecipe();
                if (recipe.TryGetResult(ModLoader.GetMod("CalamityMod").Find<ModItem>("CosmicWorm"), out g) && recipe.TryGetIngredient(ModLoader.GetMod("CalamityMod").Find<ModItem>("TwistingNether").Type, out g)) recipe.AddIngredient(ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("Eridanium").Type, 5);
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
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("UniverseSoul").Type,
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("TerrariaSoul").Type,
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("SigilOfChampions").Type,
            ModLoader.GetMod("FargowiltasSouls").Find<ModItem>("DevisCurse").Type,
            ModLoader.GetMod("CalamityMod").Find<ModItem>("DecapoditaSprout").Type,
            ModLoader.GetMod("CalamityMod").Find<ModItem>("OverloadedSludge").Type,
            ModLoader.GetMod("CalamityMod").Find<ModItem>("CosmicWorm").Type,
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
