using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace AbsolutionCore.Content
{
    public class CosmiliteKazoo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The Devourer weeps'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
    }
}
