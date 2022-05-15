using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace AbsolutionCore.Content.ThoriumExpansion.Items.Bard
{
    public class CosmiliteKazoo : ModItem
    {
        public override string Texture => "AbsolutionCore/Assets/CosmiliteKazoo";
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'The Devourer weeps'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
    }
}
