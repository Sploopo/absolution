using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace AbsolutionCore.Content.Items.Knowledge
{
    public class CosmosKnowledge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Knowledge of the World, Complete Edition");
            Tooltip.SetDefault("All of the ancient world's knowledge condensed into one book\nTake this to the Guardian to decipher it");
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 18;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 58;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(0, 0, 50);
        }
    }
}
