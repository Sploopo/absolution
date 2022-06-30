using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.General.Tiles;
using Terraria.GameContent.Personalities;

namespace AbsolutionCore.Common.Globals
{
    public class AbsolutionGlobalNPC : GlobalNPC
    {
        public override void SetStaticDefaults()
        {
            int guardianType = ModContent.NPCType<Content.General.NPCs.Guardian>();

            NPCHappiness.Get(ModLoader.GetMod("CalamityMod").Find<ModNPC>("WITCH").Type).SetNPCAffection(guardianType, AffectionLevel.Like);
            NPCHappiness.Get(ModLoader.GetMod("Fargowiltas").Find<ModNPC>("Mutant").Type).SetNPCAffection(guardianType, AffectionLevel.Like);
        }
    }
}
