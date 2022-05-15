using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.Clicker;
using AbsolutionCore.Content.ThoriumExpansion.Items.Bard;
using AbsolutionCore.Common.Systems;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalItem : GlobalItem
    {
        public override void UpdateInventory(Item item, Player player)
        {
            base.UpdateInventory(item, player);

            if(item.type == ItemID.CellPhone || item.type == ItemID.PDA)
            {
                ClickerCompat.SetAccessory(player, "ButtonMasher");
            }
        }
    }

    public class ModifiedRecipeGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return RecipeChangeSystem.ModifiedRecipes.Contains(entity.type);
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "ModifiedRecipe", $"[i:{ModContent.ItemType<CosmiliteKazoo>()}] Recipe modified by Absolution");
            line.OverrideColor = new Color(188, 102, 255);
            tooltips.Add(line);
        }
    }
}
