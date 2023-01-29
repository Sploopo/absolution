using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AbsolutionCore.Content.NPCs;
using AbsolutionCore.Content.NPCs.GuardianBoss;
using CalamityMod;

namespace AbsolutionCore.Content.Items
{
    public class GuardianSummon : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Immortality Aura");
            Tooltip.SetDefault("The source of the Auric Bar's power\nCalls immortal beings when using certain items");
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ModContent.RarityType<CalamityMod.Rarities.Violet>();
            Item.maxStack = 20;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.value = Item.buyPrice(0, 55);
        }
    }
}
