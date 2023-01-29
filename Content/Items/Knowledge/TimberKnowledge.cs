using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace AbsolutionCore.Content.Items.Knowledge
{
    public class TimberKnowledge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knowledge of the World, Vol. 1");
            Tooltip.SetDefault("A compendium written in an unknown language\nThis could be deciphered by someone old enough to read it...");
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 18;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 58;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(0, 0, 5);
        }
    }
}
