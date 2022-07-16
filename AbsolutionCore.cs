using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.General.NPCs;
using AbsolutionCore.Content.General.NPCs.GuardianBoss;
using AbsolutionCore.Content.General.Items;
using AbsolutionCore.Common.Globals;

namespace AbsolutionCore
{
	public class AbsolutionCore : Mod
	{
        public override void PostSetupContent()
        {
            /*Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                bossChecklist.Call("AddBoss", 18.25f, ModContent.NPCType<GuardianBoss>(), this, "Guardian", AbsolutionWorld.DownedGuardian, ModContent.ItemType<GuardiansCurse>(), ModContent.ItemType<GuardiansCurse>(), ModContent.ItemType<GuardiansCurse>(),
                    "Press \"Fight\" when interacting with him after defeating Erazor and Yharon.", $"[c/8000ff:Good fight. Come back if you're ready to win.]");
            }*/
        }
    }
}