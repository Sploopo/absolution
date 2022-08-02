using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AbsolutionCore.Content.General.NPCs;
using AbsolutionCore.Content.General.NPCs.GuardianBoss;
using AbsolutionCore.Content.General.Items;
using AbsolutionCore.Common.Globals;
using Mono.Cecil.Cil;
using MonoMod.Cil;

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
                    "Press \"Fight\" when interacting with him after defeating Erazor and Yharon.", $"[c/8000ff:Come back if you're ready to win.]");
            }*/
        }

        public override void Load()
        {
            IL.CalamityMod.NPCs.CalamityGlobalNPC.PreAI += DestroyCalamityVanillaBossChanges;
        }
        
        // il editing
        private static void DestroyCalamityVanillaBossChanges(ILContext il)
        {
            ILCursor mario = new ILCursor(il);
            if (mario.TryGotoNext(MoveType.After, x => x.MatchLdsfld("CalamityMod.World.CalamityWorld", "revenge")))
            {
                mario.Emit(OpCodes.Pop);
                mario.Emit(OpCodes.Ldc_I4_0);
            }
        }
    }
}