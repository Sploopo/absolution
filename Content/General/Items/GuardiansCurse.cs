using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using AbsolutionCore.Content.General.NPCs;
using AbsolutionCore.Content.General.NPCs.GuardianBoss;

namespace AbsolutionCore.Content.General.Items
{
    public class GuardiansCurse : ModItem
    {
        public override string Texture => "AbsolutionCore/Placeholder";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian's Curse");
            ItemID.Sets.ItemNoGravity[Item.type] = true;
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 20;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 2);
        }

        public override bool CanUseItem(Player player)
        {
            return NPC.AnyNPCs(ModContent.NPCType<Guardian>());
        }

        public override bool? UseItem(Player player)
        {
            NPC npc = Main.npc[NPC.FindFirstNPC(ModLoader.GetMod("AbsolutionCore").Find<ModNPC>("Guardian").Type)];
            if(npc != null)
            {
                Vector2 pos = npc.Bottom;
                npc.life = 0;
                npc.active = false;
                if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.SyncNPC, number: npc.whoAmI);

                int boss = NPC.NewNPC(NPC.GetBossSpawnSource(player.whoAmI), (int) pos.X, (int) pos.Y, ModContent.NPCType<GuardianBoss>());
                if(boss != Main.maxNPCs)
                {
                    Main.npc[boss].Bottom = pos;
                    if (Main.netMode == NetmodeID.Server) NetMessage.SendData(MessageID.SyncNPC, number: boss);
                    Main.NewText(Language.GetTextValue("Announcement.HasAwoken", Main.npc[boss].TypeName), new Color(175, 75, 255));
                }
            } else
            {
                Main.NewText("someone fucked up", new Color(175, 75, 255));
            }
            return true;
        }
    }
}
